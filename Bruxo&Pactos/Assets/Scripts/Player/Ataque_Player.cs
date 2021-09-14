using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Player : MonoBehaviour
{
    public Animator ataque;

    public Collider2D colisão;
    
    

    


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(" Bateu ");
        
    }
}
