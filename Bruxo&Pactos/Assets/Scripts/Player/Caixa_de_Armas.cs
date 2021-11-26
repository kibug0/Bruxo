using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa_de_Armas : MonoBehaviour
{
    public List<Armas_Dano.Arma> Caixa;

    public int DanoArmat;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }
/*
    // Update is called once per frame
    void Update()
    {
        DanoArmat = Caixa[i].Dano;

        SpriteRenderer.sprite = Caixa[i].Arimagem.sprite;

        SpriteRenderer.Color = Caixa[i].Arimagem.Color;

        Transform.Scale = Caixa[i].Tamanho.Scale;
        
    }*/
}
