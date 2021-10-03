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
        if(CameTroca.Status.Equals(CameraTroca.StatusCamera.Parada))
        {
            Areadacamera();
        }

        //movimentações
        Rb.MovePosition(Rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

    }
    #endregion

    #region Contermove

    private void Areadacamera()
    {
        //Altura da camera
        float altura = 2 * CameTroca.CameraAtual.m_Lens.OrthographicSize;

        //Largura da camera
        float largura = altura * CameTroca.CameraAtual.m_Lens.Aspect;

        //Limite da camera no eixo x
        float limitex = Mathf.Abs(largura / 2 - transform.localScale.x / 2);

        //Limite da camera no eixo y
        float limitey = Mathf.Abs(altura / 2 - transform.localScale.y / 2);
        
        //Os dois lados no limite no eixo x esquerda/direita
        Vector2 limitesx = new Vector2(CameTroca.CameraAtual.transform.position.x - limitex, CameTroca.CameraAtual.transform.position.x + limitex);

        //Os dois lados no limite no eixo y cima/baixo
        Vector2 limitesy = new Vector2(CameTroca.CameraAtual.transform.position.y - limitey, CameTroca.CameraAtual.transform.position.y + limitey);
      
        
        float clampedx = Mathf.Clamp(transform.position.x, limitesx.x, limitesx.y);

        float clampedy = Mathf.Clamp(transform.position.y, limitesy.x, limitesy.y);


        transform.position = new Vector3(clampedx, clampedy, transform.position.z);
    }

    #endregion
}

