using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAve_Game : MonoBehaviour
{
    public float volume;
    public int health;
    public float[] Posição;

    
    public SAve_Game(AudioManager Audio)
    {
        volume = Audio.volumeb;

        Posição = new float [3];

        //Posição[0] = Movimento.transform.position.x;
        //Posição[1] = Movimento.transform.position.y;
        //Posição[2] = Movimento.transform.position.z;

    }


    
    




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
