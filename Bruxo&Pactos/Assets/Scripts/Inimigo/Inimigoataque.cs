using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigoataque : MonoBehaviour
{
    [SerializeField]
    private Animator ataque;
    [SerializeField]
    private InimigosIAs andar;

    private float speedOrigin;

    void Start()
    {
        if(ataque==null)
        {
            ataque = GetComponentInParent<Animator>();

        }

        if(andar==null)
        {
            andar = GetComponentInParent<InimigosIAs>();

        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        
        if(col.GetComponent<StatsPlayer>() is  StatsPlayer player)
        {
            speedOrigin = andar.speed;

            ataque.SetTrigger("Atk");
            StartCoroutine("ataquetempo");
            

            
            


        }

    }

    IEnumerator ataquetempo()
    {
        andar.speed = speedOrigin/2;

        
        
        yield return new WaitForSeconds(2);

        
        
        andar.speed = speedOrigin;

    }
}
