using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
    Vector2 movement;


    //O script de trocar a camera
    public CameraTroca CameTroca; 


    public bool apertar = false;

    #endregion

    
    

   #region Update
    void Update()
    {
        //botões
        //Movimenta pelas setas na horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        //Movimenta pelas setas na Vertical
        movement.y = Input.GetAxisRaw("Vertical");

        movement.x = CrossPlatformInputManager.GetAxis("Horizontal");
        movement.y = CrossPlatformInputManager.GetAxis("Vertical");

        

        Debug.Log(movement.y);

        

        if(Andar != null)
        {
            if(movement.x == movement.y)
            {
                movement.y = 0;

            }
            Andar.SetFloat("Horizontal", movement.x);

            Andar.SetFloat("Vertical", movement.y);

            
        }
        

        
    }

    //FixedUpDate
    void FixedUpdate()
    {
        if(CameTroca != null)
        {
            if(CameTroca.Status.Equals(CameraTroca.StatusCamera.Parada))
            {
                Areadacamera();
            
            }
        }
        

        //movimentações
        Vector2 direcao = (movement).normalized * MoveSpeed * Time.fixedDeltaTime;
        Rb.velocity = new Vector2(direcao.x, direcao.y);
        //Rb.MovePosition(Rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        
        
        
        

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
