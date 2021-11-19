using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ataque_Player : MonoBehaviour
{
    public delegate void GolpeDelegate(InimigoStats inimigo);
    public GolpeDelegate Golpe;

    public Animator ataque;

    public Collider2D colisão;

    public StatsPlayer status;

    private Button Batk;

    void Start()
    {
        if(GameObject.FindWithTag("Bataque"))
        {
            Batk = GameObject.FindWithTag("Bataque").GetComponent<Button>();
            Batk.onClick.AddListener(delegate() { Ataque(); });

        }

    }
    
    
   void Update()
   {
       if(status == null)
       {
           status = GetComponentInParent<StatsPlayer>();

       }

       
       

       if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Q))
       {
           Ataque();
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

    public void Ataque()
    {
        ataque.SetTrigger("Atacar");

    }
}
