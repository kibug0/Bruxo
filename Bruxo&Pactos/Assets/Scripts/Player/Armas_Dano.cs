using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armas_Dano : MonoBehaviour
{
    [System.Serializable]
        public class Arma
        {
            public string Name;

            public int Dano;

            public Sprite ImagemArma;
            


            
        }

        

        public GameObject PainelN;

        public GameObject Canvas;


        public Arma item;

        private bool coli;

    void Start()
    {
        if(GameObject.FindWithTag("Canvas"))
        {
            Canvas = GameObject.FindWithTag("Canvas");

        }
    }
    
    
    void Update()
    { 
        if(coli)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z))
            {
                
                GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa.Add(item);
                Destroy(gameObject);

            }

            
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(GameObject.FindWithTag("inventario") && col.CompareTag("Player"))
        {
            Instantiate(PainelN, Canvas.GetComponent<Transform> ());
            
            for(int i = 0; i <GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa.Count; i++)
            {
                if(GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa[i]  == item)
                {
                    return;

                }
            }
            
            
            coli = true;
            
            


        }

    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            
            coli = false;
            Destroy( GameObject.FindWithTag("PainelN"));
            
        }
        
    }
}
