using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    
    #region Variaveis
    //Velocidade do movimento
    public float MoveSpeed = 5f;

    //Rigidbody2D do player para movimentar ele
    public Rigidbody2D Rb;

    //Animotor para mudar a direção do player conforme o botão
    public Animator Andar;


    //Vetor para mover o rigidbody do player
    public Vector2 movement;


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

            
        }
        

        
    }

    //FixedUpDate
    void FixedUpdate()
    {
        

        //movimentações
        Vector2 direcao = (movement).normalized * MoveSpeed * Time.fixedDeltaTime;
        Rb.velocity = new Vector2(direcao.x, direcao.y);
        //Rb.MovePosition(Rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        
        
        
        

    }
    #endregion

    
}
