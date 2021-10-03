﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Simples: MonoBehaviour
{

    #region Variaveis
    //Velocidade do movimento
    public float MoveSpeed = 5f;

    //Rigidbody2D do player para movimentar ele
    public Rigidbody2D Rb;

    //Animotor para mudar a direção do player conforme o botão
    public Animator Andar;


    //Vetor para mover o rigidbody do player
    Vector2 movement;


    //O script de trocar a camera
    public CameraTroca CameTroca; 

    #endregion

   #region Update
    void Update()
    {
        //botões
        //Movimenta pelas setas na horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        //Movimenta pelas setas na Vertical
        movement.y = Input.GetAxisRaw("Vertical");

        Andar.SetFloat("Horizontal", movement.x);

        Andar.SetFloat("Vertical", movement.y);

        Andar.SetFloat("Speed", movement.sqrMagnitude);

        if(0!=Input.GetAxisRaw("Horizontal") || 0!=Input.GetAxisRaw("Vertical"))
        {
            if(movement.x<0 && movement.y<0)
            {
                Rb.rotation = 135f;
            }

            if(movement.x>0 && movement.y>0)
            {
                Rb.rotation = 315f;
            }

            if(movement.x>0 && movement.y<0)
            {
                Rb.rotation = 225f;
            }

            if(movement.x<0 && movement.y>0)
            {
                Rb.rotation = 45f;
            }

        }
        
        if( 0==Input.GetAxisRaw("Horizontal") || 0==Input.GetAxisRaw("Vertical"))
        {
        
        

        if(movement.x<0)
        {
            Rb.rotation = 90;
            //Triangulo.SetTrigger("Esquerda");
            
        }

        if(movement.x>0)
        {
            Rb.rotation = 270;
            //Triangulo.SetTrigger("Direita");
            
        }

        if(movement.y>0)
        {
            Rb.rotation = 0;
            //Triangulo.SetTrigger("Cima");
            
        }

        if(movement.y<0)
        {
            Rb.rotation = 180;
            //Triangulo.SetTrigger("Baixo");
            
        }
        }
    }

    //FixedUpDate
    void FixedUpdate()
    {
        if(CameTroca.Status.Equals(CameraTroca.StatusCamera.Parada))
        {
            Areadacamera();
        }

        //movimentações
        if(movement.x!=0 && movement.y!=0)
        {
            Rb.MovePosition(Rb.position + (movement * MoveSpeed * Time.fixedDeltaTime)/2);

        }
        else
        {
            Rb.MovePosition(Rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }

        
        
        
        

    }
    #endregion

    #region Contermove

    private void Areadacamera()
    {
        //Altura da camera
        float altura = 2 * CameTroca.CameraAtual.m_Lens.OrthographicSize;

        //Largura da camera
        float largura = altura * CameTroca.CameraAtual.m_Lens.Aspect;

        float limite = Mathf.Abs(largura / 2 - transform.localScale.x / 2);
        
        Vector2 limites = new Vector2(CameTroca.CameraAtual.transform.position.x - limite, CameTroca.CameraAtual.transform.position.x + limite);

        float clampedx = Mathf.Clamp(transform.position.x, limites.x, limites.y);
        transform.position = new Vector3(clampedx, transform.position.y, transform.position.z);
    }

    #endregion
}
