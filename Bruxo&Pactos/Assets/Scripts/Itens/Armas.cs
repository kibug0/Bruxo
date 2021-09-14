using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    [System.Serializable]
    public class weapons
    {
        //Nome da arma
        public string Name;

        //Tipo da arma
        public string Tipo;

        //O transform do inimigo para chamar ele
        public Transform enemy;

        //o nivel do inimigo por enquanto não esta sendo usado
        public int Dano;
    }

    public inimigo[] weapons;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
