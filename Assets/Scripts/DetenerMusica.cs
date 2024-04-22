using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetenerMusica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameObject.FindGameObjectWithTag("musica").GetComponent<MusicaFondo>().StopMusic(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
