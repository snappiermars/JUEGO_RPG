using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorEnemigos : MonoBehaviour
{
    public static ContadorEnemigos Instance { get; private set; }

    private int contadorEnemigos = 0;
    [SerializeField] private GameObject pantallaFinal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ContarEnemigo(int incremento)
    {
        contadorEnemigos += incremento;
        if (contadorEnemigos >= 9)
        {
            pantallaFinal.SetActive(true);
            contadorEnemigos = 0;
        }
    }

    public int GetKillCount()
    {
        return contadorEnemigos;
    }
}

