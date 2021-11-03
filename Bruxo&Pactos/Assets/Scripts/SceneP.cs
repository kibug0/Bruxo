using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneP : MonoBehaviour
{
    public string Scena;
    private bool coli = false;
    

    void Update()
    { 
        if(coli)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
            {
                Scenechange(Scena);
                

            }

            
        }


    }
    

    public void Scenechange(string cena)
    {
        SceneManager.LoadScene(cena);
        

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

}
