using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        movimiento();
        AnimacionesPlayer();

    }

    private void movimiento()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        dirMov = new Vector2(movX, movY).normalized;
        //dirMov = new Vector2(movX, movY);
        rb.velocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);
    }
    private void AnimacionesPlayer()
    {
        anim.SetFloat("movX",dirMov.x);
        anim.SetFloat("movY", dirMov.y);

    }

    
}
