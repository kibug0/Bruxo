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
        Canvas = GameObject.FindWithTag("canvas");


        
    }

    // Update is called once per frame
    void Update()
    {
        if(Canvas == null)
        {
            Canvas = GameObject.FindWithTag("canvas");

        }
        if (Input.GetKey ("escape")) 
        {
           ColocaMenu();
        }

        
    }

    public void ColocaMenu()
    {
        if(GameObject.FindWithTag("Menu"))
        { 
            Instantiate(Menu, Canvas.GetComponent<Transform> ());
        }
        else
        {
            Destroy(Menu);
        }
    }
}
