using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chama_Menu : MonoBehaviour
{

    
    //Menu a ser chamado
    public GameObject Menu;

    //Canvas para colocar o menu dentro
    public GameObject Canvas;

    //String da tag
    public string Tag;
    
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindWithTag("Canvas");
        if(Tag == null)
        {
            Tag = "Menu";
        }
        


        
    }

    // Update is called once per frame
    void Update()
    {
        if(Canvas == null)
        {
            Canvas = GameObject.FindWithTag("Canvas");

        }
        if(tag == "Menu")
        {
            if (Input.GetKeyDown("escape")) 
            {
            ColocaMenu();
            }
        }
        if(GameObject.FindGameObjectWithTag("FechaButton"))
        {
            GameObject.FindGameObjectWithTag("FechaButton").GetComponent<Button>().onClick.AddListener(delegate() {ColocaMenu();});
            Debug.Log("FechaButton");

        }
        

        
    }

    public void ColocaMenu()
    {
        if(GameObject.FindWithTag(Tag))
        { 
            Destroy(GameObject.FindWithTag(Tag));
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
