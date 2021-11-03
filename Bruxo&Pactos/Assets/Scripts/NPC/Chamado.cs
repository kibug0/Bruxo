using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chamado : MonoBehaviour
{
    public GameObject Exclamacao;
    public bool perto = false;

    public GameObject Pergunta;

    public GameObject Canvas;

    public Pacto confirmar;



    

    
    // Update is called once per frame
    void Update()
    {
        if(Exclamacao == null)
        {
            Exclamacao = GetchildWithName(this.gameObject, "esclamacao");
            
        }
        if(Canvas == null)
        {
            Canvas = GameObject.FindGameObjectWithTag("Canvas");
            
        }
        

        if(perto)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                

                Instantiate(Pergunta, Canvas.transform);

                GameObject PerguntaClone = GameObject.FindGameObjectWithTag("Pergunta");

                confirmar.Pergunta = PerguntaClone;
                
                Button btnS = GetchildWithName(PerguntaClone, "sim").GetComponent<Button>();
                Button btnN = GetchildWithName(PerguntaClone, "nao").GetComponent<Button>();
            
                btnS.onClick.AddListener(confirmar.sim);
                btnN.onClick.AddListener(confirmar.nao);

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
            if(Exclamacao != null)
            {
                Exclamacao.SetActive(true);
            }
            
            perto = true;
            
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            if(Exclamacao != null)
            {
                Exclamacao.SetActive(false);
            }
            
            perto = false;
        }
        
    }
    
}
