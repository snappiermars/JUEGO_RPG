using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int dañoGolpe;
    public float tiempoEntreAtaques = 0.5f;
    private float tiempoSigAtaque = 0f;
    private Animator animator;
    public static bool atacando;
    [SerializeField] private AudioClip clip;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (tiempoSigAtaque > 0) {
            tiempoSigAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && tiempoSigAtaque <= 0) {
            atacando = true;
            Golpe();
            tiempoSigAtaque = tiempoEntreAtaques;
        }

        if (tiempoSigAtaque <= 0) {
            atacando = false;
        }
    }

    private void Golpe() {
        switch (MovPlayer.dirAtaque) {
            case 1:
                animator.SetTrigger("ataqueFront");
                break;
            case 2:
                animator.SetTrigger("ataqueBack");
                break;
            case 3:
                animator.SetTrigger("ataqueLeft");
                break;
            case 4:
                animator.SetTrigger("ataqueRight");
                break;
        }
    }

    // Esta función debería ser llamada desde un evento de animación
    private void VerificaGolpe() {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos) {
            if (colisionador.CompareTag("Enemigo")) {
                colisionador.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
                ControladorSonido.Instance.EjecutarSonido(clip);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private void activaCapa(string nombre) {
        for (int i = 0; i < animator.layerCount; i++) {
            animator.SetLayerWeight(i, 0); // Ambos layers con weight en 0
        }
        animator.SetLayerWeight(animator.GetLayerIndex(nombre), 1);
    }
}
