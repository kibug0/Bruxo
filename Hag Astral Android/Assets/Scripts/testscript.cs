using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    Fasecameracontroler FaseCC;

    private void Awake()
    {
        if (FaseCC == null)
        {
            

            FaseCC = GetComponent<Fasecameracontroler>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //FaseCC.Iniciarfase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
