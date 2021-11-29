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
    void Start()
    {
        if(caixa != null)
        {
            
            caixa.GetComponentInChildren<Text>().text = textos[I];
            I++;
            
            
        }

        if(GameObject.FindWithTag("PainelN") && caixa == null)
        {
            caixa = GameObject.FindWithTag("PainelN");
            caixa.GetComponentInChildren<Text>().text = textos[I];
            I++;
            
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("PainelN") && caixa == null)
        {
            caixa = GameObject.FindWithTag("PainelN");
            caixa.GetComponentInChildren<Text>().text = textos[I];
            I++;
            
        }
        

        if (Input.GetKeyDown(KeyCode.Return) && caixa !=null)
        {
            if(I < textos.Length)
            {
                
                caixa.GetComponentInChildren<Text>().text = textos[I];
                I++;

            }
            else if (I == textos.Length)
            {
                Destroy(caixa);

            }
            
            
            
        }
        else if(I >= textos.Length && arma)
        {
            I--;
        }
        
    }
}
