﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    #region informações do menu
        public int Qualidade;

        public int Resolution;
        
        public float Volume;

    #endregion

    #region informações do decorrer do jogo
        public int vida;

        public int Nivelplayer;

        public int NivelInimigos;

        public int NivelContrato;

        public string FASE;
    #endregion

    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void proximacena()
    {
        SceneManager.LoadScene("Casa");

    }

}
