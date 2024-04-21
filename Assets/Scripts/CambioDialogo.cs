using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambioDialogo : MonoBehaviour
{
    [SerializeField] private GameObject DialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    // Matriz para almacenar los diálogos del NPC
    [SerializeField, TextArea(4,6)] private string[][] dialogueSets;

    private float typingTime = 0.1f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    public int conversationIndex; // Variable para realizar un seguimiento de cuántas veces ha hablado el jugador con el NPC

    // Inicializa la conversación actual y establece las referencias
    void Start()
    {
        conversationIndex = 0; // Inicializa el contador de conversaciones
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            } 
            else if (dialogueText.text == dialogueSets[conversationIndex][lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueSets[conversationIndex][lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueSets[conversationIndex].Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
            conversationIndex++; // Incrementa el índice de conversación para la próxima vez que hables con el NPC
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueSets[conversationIndex][lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
        }
    }
}
