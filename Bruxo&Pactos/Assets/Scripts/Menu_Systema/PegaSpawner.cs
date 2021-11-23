using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegaSpawner : MonoBehaviour
{
    public Button Voltar;

    public SceneP SP;

    public string fase;

    void Start()
    {
        
        if(GameObject.FindWithTag("GameController"))
        {
            fase = GameObject.FindWithTag("GameController").GetComponent<GameManager>().FASE;
            Voltar.onClick.AddListener(delegate{SP.Scenechange(fase); });

        }

        
        
        
    }
}
