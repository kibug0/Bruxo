using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacando : MonoBehaviour
{
    public Animator atack;
    private float timeBtwAttack;
    public float StartTimeBtwAttack;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            atack.SetTrigger("Atack");
        }
        
    }
   
}
