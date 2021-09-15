using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamado : MonoBehaviour
{
    public GameObject Exclamacao;
    public bool perto = false;

    public GameObject Pergunta;

    public GameObject Canvas;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Exclamacao == null)
        {
            Exclamacao = GetchildWithName(this.gameObject, "esclamacao");
            
        }
        

        if(perto)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(Pergunta, Canvas.transform);

            }

        }

        
        
        
    }

    public GameObject GetchildWithName(GameObject obj, string nome)
    {
        Transform trans = obj.transform;

        Transform childtrans = trans.Find(nome);

        if(childtrans != null)
        {
            return childtrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Exclamacao.SetActive(true);
            perto = true;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Exclamacao.SetActive(false);
            perto = false;
        }
        
    }
    
}
