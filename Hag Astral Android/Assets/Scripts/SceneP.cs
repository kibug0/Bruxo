using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneP : MonoBehaviour
{
    public string Scena;
    private bool coli = false;
    private GameManager Gm;
    public bool touch;
    private Button Interacion;

    void Start()
    {
        if(GameObject.FindWithTag("Inter"))
        {
            Interacion = GameObject.FindWithTag("Inter").GetComponent<Button>();
            Interacion.onClick.AddListener(delegate() { Androidtoque(); });
        }

    }
    

    void Update()
    { 
        if(coli)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X) || touch)
            {
                Scenechange(Scena);
                

            }

            
        }

        if(GameObject.FindWithTag("GameController"))
        {
            Gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        }


    }
    

    public void Scenechange(string cena)
    {
        SceneManager.LoadScene(cena);
        

    }


    public void Respawn()
    {
        if(GameObject.FindWithTag("GameController"))
        {
            SceneManager.LoadScene(Gm.FASE);

        }
        else
        {
            SceneManager.LoadScene("Inicio");
        }
        
        

    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            coli = true;
            Debug.Log(coli);
            
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            coli = false;
            Debug.Log(coli);
        }
        
    }

    public void Androidtoque()
    {
        touch = true;

    }

}
