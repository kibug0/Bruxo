using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chama_Menu : MonoBehaviour
{

    
    //Menu a ser chamado
    public GameObject Menu;

    //Canvas para colocar o menu dentro
    public GameObject Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindWithTag("Canvas");


        
    }

    // Update is called once per frame
    void Update()
    {
        if(Canvas == null)
        {
            Canvas = GameObject.FindWithTag("Canvas");

        }
        if (Input.GetKeyDown("escape")) 
        {
           ColocaMenu();
        }

        
    }

    public void ColocaMenu()
    {
        if(GameObject.FindWithTag("Menu"))
        { 
            Destroy(GameObject.FindWithTag("Menu"));
            Resume();
            
        }
        else
        {
            Pause();
            Instantiate(Menu, Canvas.GetComponent<Transform> ());
            
        }
    }

    //Função que Resume o jogo, é usada no botão
    public void Resume()
    {
       
        Time.timeScale = 1f;
        
        
    }

    //Função que Pausa o jogo
    public void Pause()
    {
        
        Time.timeScale = 0f;
        
        
    }
}
