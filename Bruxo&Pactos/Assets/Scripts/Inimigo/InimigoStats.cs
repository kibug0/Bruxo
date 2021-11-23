using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InimigoStats : MonoBehaviour
{
    public int Vida;
    public int Dano;
    public int Velocidade;
    int vida;

    private Rigidbody2D Rb;


    public AudioSource audioHit;
    public AudioClip hit;
    


    // Start is called before the first frame update
    void Start()
    {
        vida = Vida;
        Rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida<0)
        {
            Destroy(gameObject);
        }
        
    }

    public void tiraVida(int DanoP)
    {
        vida = vida - DanoP;
        Rb.AddForce(-(GetComponent<InimigosIAs>().Direção)*10000*Time.deltaTime);
        audioHit.PlayOneShot(hit);
        StartCoroutine("Colorhit");
        
    }

    IEnumerator Colorhit()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        
        yield return new WaitForSeconds(5);
        
        GetComponentInChildren<SpriteRenderer>().color = Color.white;

    }
}
