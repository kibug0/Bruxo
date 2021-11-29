using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caixa_de_Armas : MonoBehaviour
{
    public List<Armas_Dano.Arma> Caixa;

    public int DanoArmat;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DanoArmat = Caixa[i].Dano;

        if(Input.GetKeyDown(KeyCode.C) && Caixa.Count>1)
        {
            Debug.Log(Caixa.Count);
            i++;
            if(Caixa.Count<i+1)
            {
                i = 0;
            }
        }


        
    }
}
