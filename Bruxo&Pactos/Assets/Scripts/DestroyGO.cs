using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    public void Destroi(GameObject objeto)
    {
        Destroy(objeto);
        Time.timeScale = 1f;

    }

    
}
