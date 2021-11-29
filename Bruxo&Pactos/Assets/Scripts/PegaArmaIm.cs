using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegaArmaIm : MonoBehaviour
{
    public Image Armaima;

    public Caixa_de_Armas arma;
    
    

    // Update is called once per frame
    void Update()
    {
        if(arma == null)
       {
           arma = GameObject.FindWithTag("inventario").GetComponent<Caixa_de_Armas>();

       }

       Armaima.sprite = arma.Caixa[arma.i].ImagemArma;


    }
}
