using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class novelText : MonoBehaviour
{
    [TextArea(3, 10)]public string[] textos;


    public GameObject caixa;

    public int I = 0;

    public bool arma;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("PainelN") && caixa == null)
        {
            caixa = GameObject.FindWithTag("PainelN");
            caixa.GetComponentInChildren<Text>().text = textos[I];
            I++;
            
        }
        

        if (Input.GetKeyDown(KeyCode.Return) || arma && caixa !=null)
        {
            if(I < textos.Length)
            {
                
                caixa.GetComponentInChildren<Text>().text = textos[I];
                I++;

            }
            else
            {
                Destroy(caixa);

            }
            arma = false;
            
            
        }
        if(I >= textos.Length)
        {
            I--;
        }
        
    }
}
