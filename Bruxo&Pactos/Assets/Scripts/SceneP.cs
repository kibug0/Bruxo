using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneP : MonoBehaviour
{
    public string Scena;
    private bool coli;
    private GameManager Gm;
    

    void Update()
    { 
        if(coli)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z))
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
           
            
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            coli = false;
            
        }
        
    }

}
