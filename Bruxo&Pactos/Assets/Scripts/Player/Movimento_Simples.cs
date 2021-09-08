using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoSimples : MonoBehaviour
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

    #endregion

   #region Update
    void Update()
    {
        //botões
        //Movimenta pelas setas na horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        //Movimenta pelas setas na Vertical
        movement.y = Input.GetAxisRaw("Vertical");

        if(Andar != null)
        {
            Andar.SetFloat("Horizontal", movement.x);

            Andar.SetFloat("Vertical", movement.y);

            Andar.SetFloat("Speed", movement.sqrMagnitude);
        }

        

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
        //movimentações
        Rb.MovePosition(Rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

    }
    #endregion}
}
