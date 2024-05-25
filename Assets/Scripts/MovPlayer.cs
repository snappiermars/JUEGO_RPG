using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov = 5f; // Asegúrate de ajustar la velocidad en el Inspector
    public Rigidbody2D rb;
    public Animator anim;
    private bool PlayerMoviendose = false;
    private float ultimoMovX, ultimoMovY;
    public static int dirAtaque = 0; // 1 - Frente, 2 - Atrás, 3 - Izquierda, 4 - Derecha

    void FixedUpdate()
    {
        movimiento();
        if (!CombateCaC.atacando && !CAD.disparando) // Si no está atacando
        {
            AnimacionesPlayer();
        }
    }

    private void movimiento()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        dirMov = new Vector2(movX, movY).normalized;
        rb.velocity = dirMov * velMov; // Aplica velocidad al Rigidbody

        if (movX == 0 && movY == 0)
        {
            PlayerMoviendose = false; // IDLE
        }
        else
        {
            PlayerMoviendose = true; // Caminar
            ultimoMovX = movX;
            ultimoMovY = movY;
        }

        // Actualiza la dirección del ataque
        if (movX == -1) dirAtaque = 3; //Izquierda
        else if (movX == 1) dirAtaque = 4; //Derecha
        else if (movY == -1) dirAtaque = 1; //Abajo
        else if (movY == 1) dirAtaque = 2; //Arriba

        ActualizaCapa();
    }

    private void AnimacionesPlayer()
    {
        anim.SetFloat("movX", ultimoMovX);
        anim.SetFloat("movY", ultimoMovY);
    }

    private void ActualizaCapa()
    {
        if (!CombateCaC.atacando && !CAD.disparando){
            if (PlayerMoviendose)
            {
            activaCapa("Caminar");
             }
            else
            {
            activaCapa("Idle");
            }
        }else{
            activaCapa("Ataque");
        }
    }

    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0); // Ambos layers con weight en 0
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1); // Activa la capa correcta
    }
}
