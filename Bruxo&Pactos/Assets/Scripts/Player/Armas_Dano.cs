using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas_Dano : MonoBehaviour
{
    [System.Serializable]
        public class Arma
        {
            public string Name;

            public int Dano;
            

            public SpriteRenderer Arimagem;

            public Transform Tamanho;

            
        }

        public Arma item;
    
    
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(GameObject.FindWithTag("inventario"))
        {
            for(int i = 0; i <GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa.Count; i++)
            {
                if(GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa[i]  == item)
                {
                    return;

                }
            }
            if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>().Caixa.Add(item);

            }
            


        }

    }
}
