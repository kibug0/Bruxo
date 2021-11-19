using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Faselocal : MonoBehaviour
{
    public string fase;
    // Start is called before the first frame update
    void Start()
    {
        fase = SceneManager.GetActiveScene().name;
        if(GameObject.FindWithTag("GameController"))
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().FASE = fase;
            

        }
        
    }

    
}
