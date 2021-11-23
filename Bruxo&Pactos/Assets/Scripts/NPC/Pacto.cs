using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacto : MonoBehaviour
{
    public GameObject Pergunta;

    public string Criatura;
    
   

    

    public void nao()
    {
        Destroy(Pergunta);

    }

    public void sim()
    {
        Destroy(Pergunta);
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<CaixaDeItens>().PactoA = Criatura;

    }
}
