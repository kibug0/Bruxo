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

    private bool dentro;

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

    void Update()
    {
        if(dentro)
        {
            ataque.SetTrigger("Atk");
            StartCoroutine("ataquetempo");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        
        
        if(col.GetComponent<StatsPlayer>() is  StatsPlayer player)
        {
            speedOrigin = andar.speed;
            dentro = true;
            

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.GetComponent<StatsPlayer>() is  StatsPlayer player)
        {
            
            dentro = false;
            

        }

    }

    IEnumerator ataquetempo()
    {
        andar.speed = speedOrigin/2;

        
        
        yield return new WaitForSeconds(2);

        
        
        andar.speed = speedOrigin;

    }
}
