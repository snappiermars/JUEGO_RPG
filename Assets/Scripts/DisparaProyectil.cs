using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaProyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 8.0f;
    private Vector3 direccion;

    private void Start() {
        switch (CAD.dirDisparo) {
            case 1:
                direccion = Vector3.down;
                break;
            case 2:
                direccion = Vector3.up;
                break;
            case 3:
                direccion = Vector3.left;
                break;
            case 4:
                direccion = Vector3.right;
                break;
            default:
                direccion = Vector3.zero;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position += direccion * Time.deltaTime * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Limites")) {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemigo")) {
            collision.transform.GetComponent<Enemigo>().TomarDaño(1);
            Destroy(this.gameObject);
        }
    }
}
