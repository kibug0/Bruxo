using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FimCutScene : MonoBehaviour
{
    private VideoPlayer CutScene;

    private double Timer = 0;

    public string cena;

    // Start is called before the first frame update
    void Awake()
    {
        CutScene = GetComponent<VideoPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= CutScene.length + 2)
        {
            SceneManager.LoadScene(cena);

        }
        else
        {
            Timer += Time.deltaTime;
        }
        
    }
}
