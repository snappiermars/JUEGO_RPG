using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAD : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    public float tiempoEntreAtaques = 0.5f;
    private float tiempoSigAtaque = 0f;
    public Transform puntoEmision;
    private Animator animator;
    public static int dirDisparo = 0;
    public static bool disparando = false;
    [SerializeField] private AudioClip clip;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (tiempoSigAtaque > 0) {
            tiempoSigAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0) {
            disparando = true;
            activaCapa("Ataque");
            Dispara();
            tiempoSigAtaque = tiempoEntreAtaques;
        }

        if (tiempoSigAtaque <= 0.05f) {
            disparando = false;
        }
    }

    private void Dispara() {
        switch (MovPlayer.dirAtaque) {
            case 1:
                animator.SetTrigger("disparaFront");
                break;
            case 2:
                animator.SetTrigger("disparaBack");
                break;
            case 3:
                animator.SetTrigger("disparaLeft");
                break;
            case 4:
                animator.SetTrigger("disparaRight");
                break;
        }
    }

    // Esta función debería ser llamada desde un evento de animación
    private void EmiteProyectil() {
        dirDisparo = MovPlayer.dirAtaque;
        Instantiate(proyectil, puntoEmision.position, transform.rotation);
        ControladorSonido.Instance.EjecutarSonido(clip);
    }

    private void activaCapa(string nombre) {
        for (int i = 0; i < animator.layerCount; i++) {
            animator.SetLayerWeight(i, 0); // Ambos layers con weight en 0
        }
        animator.SetLayerWeight(animator.GetLayerIndex(nombre), 1);
    }
}
