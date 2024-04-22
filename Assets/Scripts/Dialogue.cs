using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DIalo : MonoBehaviour
{
    [SerializeField] private GameObject DialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines; 

    [SerializeField] private AudioClip clip;
    
    private float typingTime = 0.1f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))){
            if(!didDialogueStart){
                StartDialogue();
                ControladorSonido.Instance.EjecutarSonido(clip);
            } else if(dialogueText.text == dialogueLines[lineIndex] ){
            NextDialogueLine();
            }else{
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];   
            }
        }
        
    }

    private void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine()); 
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }
        else{
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
        isPlayerInRange = true;
        DialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
        isPlayerInRange = false;
        DialogueMark.SetActive(false);
        }
    }
}
