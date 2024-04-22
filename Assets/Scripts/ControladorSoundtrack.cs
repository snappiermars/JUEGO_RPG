using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSoundtrack : MonoBehaviour
{
   public AudioSource[] canciones;
    private int indiceActual = 0;

    void Start()
    {
        // Comienza la reproducción de la primera canción
        ReproducirSiguienteCancion();
    }

    void ReproducirSiguienteCancion()
    {
        // Verifica si el índice actual está dentro del rango de la lista de canciones
        if (indiceActual < canciones.Length)
        {
            // Detiene la canción actual (si se está reproduciendo)
            if (indiceActual > 0)
            {
                canciones[indiceActual - 1].Stop();
            }

            // Reproduce la siguiente canción en la lista
            canciones[indiceActual].Play();

            // Incrementa el índice para la próxima canción
            indiceActual++;
        }
    }
}
