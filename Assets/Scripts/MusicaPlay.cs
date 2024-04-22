using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPlay : MonoBehaviour
{
    
    void Start()
    {
        GameObject.FindGameObjectWithTag("musica").GetComponent<MusicaFondo>().PlayMusic();
    }

    
}
