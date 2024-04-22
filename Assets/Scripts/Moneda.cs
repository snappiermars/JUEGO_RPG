using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Moneda : MonoBehaviour
{
    
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            ControladorSonido.Instance.EjecutarSonido(clip);
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
            
        }
    }
   
}
