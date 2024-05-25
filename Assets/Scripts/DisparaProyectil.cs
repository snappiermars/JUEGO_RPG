using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaProyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 8.0f;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if  (CAD.dirDisparo == 1){
            transform.position += new Vector3(0,-1,0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 2){
            transform.position += new Vector3(0,1,0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 3){
            transform.position += new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }else if (CAD.dirDisparo == 4){
            transform.position += new Vector3(1,0,0) * Time.deltaTime * velocidad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "limites"){
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "enemigo"){
            collision.transform.GetComponent<Enemigo>().TomarDaño(1);
            Destroy(this.gameObject);
        }
    }
}
