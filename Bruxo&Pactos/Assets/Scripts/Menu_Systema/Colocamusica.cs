using UnityEngine.Audio;
using UnityEngine;

public class Colocamusica : MonoBehaviour
{
    public AudioClip Audiolocal;
    
    
    void Start()
    {
        if(GameObject.FindWithTag("Audiocontroller"))
        {
            GameObject.FindWithTag("Audiocontroller").GetComponent<AudioManager>().SetFaseMusic(Audiolocal);
            Debug.Log("Foi");

        }
        
        
    }

   
}
