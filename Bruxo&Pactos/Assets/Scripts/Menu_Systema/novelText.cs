using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class novelText : MonoBehaviour
{
    [TextArea(3, 10)]public string[] textos;


    public GameObject caixa;

    private int I = 0;

    // Start is called before the first frame update
    void Start()
    {
        caixa.GetComponentInChildren<Text>().text = textos[I];
        I++;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(I < textos.Length)
            {
                Debug.Log(I);
                caixa.GetComponentInChildren<Text>().text = textos[I];
                I++;

            }
            else
            {
                Destroy(caixa);

            }
            
        }
        
    }
}
