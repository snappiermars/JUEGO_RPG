using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            other.transform.GetComponentInChildren<VidasPlayer>().Cura(1);
            ControladorSonido.Instance.EjecutarSonido(clip);
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }
    }
   
}
