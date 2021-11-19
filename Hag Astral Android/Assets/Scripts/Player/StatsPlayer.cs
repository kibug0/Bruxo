using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public int vida;
    public int Dano;
    public Status status;
    private Rigidbody2D Rb;
    public GameObject SliderVida;

    // Start is called before the first frame update
    void Start()
    {
    
       
        
        Rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if( GameObject.FindWithTag("Status"))
        {
            if(status == null)
            {
                status = GameObject.FindWithTag("Status").GetComponent<Status>();
                vida = status.Vida;
                Dano = status.dano;

            }

        }

        
        if(GameObject.FindGameObjectWithTag("Vida"))
        {
            if(SliderVida == null)
            {
                SliderVida = GameObject.FindGameObjectWithTag("Vida");
                SliderVida.GetComponent<Slider>().minValue = 0;
                if(!status == null)
                {
                    SliderVida.GetComponent<Slider>().maxValue = status.Vida;
                }
                else
                {
                    SliderVida.GetComponent<Slider>().maxValue = vida;
                }
            }
            SliderVida.GetComponent<Slider>().value = vida;
        }
    
        
        

       if(vida <=0)
       {
           Debug.Log("Game Over");
           StartCoroutine("morte");
           SceneManager.LoadScene("GameOver");

       }

        
    }

    public void tiraVida(int DanoE, GameObject ini)
    {
        vida = vida - DanoE;
        Rb.AddForce(ini.GetComponentInParent<InimigosIAs>().Direção*100000*Time.deltaTime);
        //audioHit.PlayOneShot(hit);
        StartCoroutine("Colorhit");
        
    }

    IEnumerator Colorhit()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        
        yield return new WaitForSeconds(5);
        
        GetComponentInChildren<SpriteRenderer>().color = Color.white;

    }

    IEnumerator morte()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        
        yield return new WaitForSeconds(5);
        
        Destroy(gameObject);

    }
}
