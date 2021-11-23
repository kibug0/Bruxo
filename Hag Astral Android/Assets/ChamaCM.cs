using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChamaCM : MonoBehaviour
{
    public Button MenuB;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            MenuB.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("Player").GetComponent<Chama_Menu>().ColocaMenu();});
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
