using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class COLLIDERMenu : MonoBehaviour
{
    
    public string fase;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.GetComponent<Chama_Menu>()!=null)
        {
            this.GetComponent<Chama_Menu>().ColocaMenu();
        }
        else if(this.GetComponent<SceneP>()!=null)
        {
            this.GetComponent<SceneP>().Scenechange(fase);
        }

    }
}
