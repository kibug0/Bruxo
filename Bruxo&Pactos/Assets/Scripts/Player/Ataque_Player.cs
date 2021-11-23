﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Player : MonoBehaviour
{
    public delegate void GolpeDelegate(InimigoStats inimigo);
    public GolpeDelegate Golpe;

    public Animator ataque;

    public Collider2D colisão;

    public StatsPlayer status;
    
    
   void Update()
   {
       if(status == null)
       {
           status = GetComponentInParent<StatsPlayer>();

       }
       

       if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Q))
       {
           ataque.SetTrigger("Atacar");
       }
   }
    


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Inimigo")
        {
            if(col.GetComponent<InimigoStats>() is  InimigoStats Ini)
            {
                col.GetComponent<InimigoStats>().tiraVida(status.Dano);
            }

        }
        
        
        
    }
}
