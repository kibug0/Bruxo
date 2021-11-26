using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranca : MonoBehaviour
{
    public WavesSystens fasewave;
    public GameObject Colliders;

    public bool toque = true;
    // Start is called before the first frame update
    void Start()
    {
        if(Colliders != null)
        {
            Colliders.SetActive(false);

        }
        
    }

    // Update is called once per frame
    public void abre()
    {
        Colliders.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(toque)
        {
            if(col.gameObject.tag == "Player")
            {
                Colliders.SetActive(true);

                fasewave.começar();

                toque = false;

            }

        }
        
    }
}
