using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEmpurra : MonoBehaviour
{
    public InimigoStats status;
    // Start is called before the first frame update
    void Start()
    {
        if(status == null)
       {
           status = GetComponent<InimigoStats>();

       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(col.GetComponent<StatsPlayer>() is  StatsPlayer player)
            {
                
                col.GetComponent<StatsPlayer>().tiraVida(status.Dano, gameObject);
            }

        }
        
        
        
    }
}
