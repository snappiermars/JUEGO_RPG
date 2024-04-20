using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "portal1")
        {
            Vector3 posicionCamara = new Vector3(32.6f, 1.26f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:"+posicionCamara);
            Vector3 posicionPlayer = new Vector3(41.04f, 5.7f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1"+posicionPlayer);
        }
        if (obj.gameObject.tag == "portal2")
        {
            Vector3 posicionCamara = new Vector3(-0.82f, 1.17f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(8.38f, -0.31f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal3")
        {
            Vector3 posicionCamara = new Vector3(32.6f, 1.92f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(41.1f, 6.79f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }

        if (obj.gameObject.tag == "portal4")
        {
            Vector3 posicionCamara = new Vector3(-0.3f, 1.4f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(8.3f, -0.1f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal5")
        {
            Vector3 posicionCamara = new Vector3(0.04f, -14.9f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(0.69f, -16.9f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal6")
        {
            Vector3 posicionCamara = new Vector3(32.6f, 1.26f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(23.77f, -4.13f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal7")
        {
            Vector3 posicionCamara = new Vector3(63.64f, 1.67f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(57.24f, 2.98f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal12")
        {
            Vector3 posicionCamara = new Vector3(62.86f, -15.1f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(53.7f, -17f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal10")
        {
            Vector3 posicionCamara = new Vector3(32.6f, 1.26f, -20);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(23.64f, -3.2f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal11")
        {
            Vector3 posicionCamara = new Vector3(32.76f, -14.9f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(24f, -14.7f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal8")
        {
            Vector3 posicionCamara = new Vector3(62.9f, -14.9f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(72.4f, -13.8f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal9")
        {
            Vector3 posicionCamara = new Vector3(0.05f, -15.25f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(-9.4f, -15.8f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal6")
        {
            Vector3 posicionCamara = new Vector3(33.4f, -15.21f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(42.2f, -15.8f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
        if (obj.gameObject.tag == "portal7")
        {
            Vector3 posicionCamara = new Vector3(32.7f, 1.4f, -10);
            camara.transform.position = posicionCamara;
            print("posisiocnCamara:" + posicionCamara);
            Vector3 posicionPlayer = new Vector3(41f, 5.8f, 0);
            this.transform.position = posicionPlayer;
            print("posicionp1" + posicionPlayer);
        }
    }
}
