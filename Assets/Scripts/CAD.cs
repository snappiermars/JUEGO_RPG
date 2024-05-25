using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAD : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    public float tiempoSigAtaque;
    public float tiempoEntreAtaques;
    public Transform puntoEmision;
    private Animator animator;
    public static int dirDisparo = 0;
    public static bool disparando = false;
    [SerializeField] private AudioClip clip;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0){
            disparando = false;
        }
        if (tiempoSigAtaque > 0){
            tiempoSigAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire2") && tiempoSigAtaque <=0){
            disparando = true;
            activaCapa("Ataque");
            Dispara();
            tiempoSigAtaque = tiempoEntreAtaques;
        }
    }
    private void Dispara(){
        if (MovPlayer.dirAtaque == 1){
            animator.SetTrigger("disparaFront");
        }else if (MovPlayer.dirAtaque == 2)
        {
             animator.SetTrigger("disparaBack");
        }else if (MovPlayer.dirAtaque == 3)
        {
             animator.SetTrigger("disparaLeft");
        }else if (MovPlayer.dirAtaque == 4)
        {
             animator.SetTrigger("disparaRight");
        }
        
        
    }

    private void EmiteProyectil(){
        dirDisparo = MovPlayer.dirAtaque;
        Instantiate(proyectil, puntoEmision.position, transform.rotation);
    }
    private void activaCapa(string nombre){
        for (int i = 0; i < animator.layerCount; i++){
            animator.SetLayerWeight(i,0); //Ambos layers con weigth en 0
        }
        animator.SetLayerWeight(animator.GetLayerIndex(nombre),1);
    }

}
