using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Player : MonoBehaviour
{
    public delegate void GolpeDelegate(InimigoStats inimigo);
    public GolpeDelegate Golpe;

    public Animator ataque;

    public Collider2D colisão;

    public Status status;
    
    
   void Update()
   {
       if(status == null)
       {
           status = GameObject.FindWithTag("GameController").GetComponent<Status>();

       }
       

       if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Q))
       {
           ataque.SetTrigger("Atacar");
       }
   }
    


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<InimigoStats>() is  InimigoStats Ini)
        {
            col.GetComponent<InimigoStats>().tiraVida(status.dano);


        }
        
        
    }
}
