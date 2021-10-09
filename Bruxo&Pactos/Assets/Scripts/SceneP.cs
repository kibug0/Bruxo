using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneP : MonoBehaviour
{
    

    public void Scenechange(string cena)
    {
        SceneManager.LoadScene(cena);

    }

}
