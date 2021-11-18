using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimicoCount : MonoBehaviour
{
    public List<GameObject> listini = new List<GameObject>();

    public enum tipo {Porta, saida, Mudfase}

    public bool ativador; 

    public string cena;

    private SceneP Cenap;

    public GameObject saida;

    public tipo escolhas;
    
    void Start()
    {
        if (Cenap == null)
        {
            Cenap = gameObject.GetComponent<SceneP>();
        }

        for(int i = 0; i <(int) gameObject.transform.childCount; i++)
        {
            listini.Add(gameObject.transform.GetChild(i).gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(listini.Count<=0)
        {
            if(escolhas == tipo.saida)
            {
                saida.SetActive(true);

            }

            if(escolhas == tipo.Porta)
            {
                saida.GetComponent<Collider2D>().enabled = true;

            }

            if(escolhas == tipo.Mudfase)
            {
                Cenap.Scenechange(cena);

            }
            

        }
        else
        {
            
            if(escolhas == tipo.Porta)
            {
                saida.GetComponent<Collider2D>().enabled = false;

            }
            
            if(escolhas == tipo.saida)
            {
                saida.SetActive(false);

            }

            listini.RemoveAll(GameObject => GameObject == null);
                
            
        }
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ativador)
        {
            for(int i = 0; i <(int) gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);

            }
            

        }

    }
}
