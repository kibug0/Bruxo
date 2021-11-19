using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
  //AudioMixer principal
    public AudioMixer audioMixer;
    

    //audio sources das fases
    public AudioSource faseM;
    


    //Musicas das fases
    public AudioClip Fase1Audio;


    //GameManager para pegar o dinheiro
    public GameManager GM;

    public float volumeb;

    public GameObject SliderMenu;

    



    

    public void Update()
    {
      //GM.Volume;

      if(GameObject.FindGameObjectWithTag("Volume"))
      {
        if(SliderMenu == null)
        {
          SliderMenu = GameObject.FindGameObjectWithTag("Volume");
          SliderMenu.GetComponent<Slider>().minValue = -35;
          SliderMenu.GetComponent<Slider>().maxValue = 0;
          SliderMenu.GetComponent<Slider>().value = GM.Volume;
          SliderMenu.GetComponent<Slider>().onValueChanged.AddListener(delegate {SetVolume(SliderMenu.GetComponent<Slider>().value);});
          
        }
      }
      
      
     
      

    }

    /*
    public void SAve_Game ()
    {
      Save_System.SAve_Game(this);
    }

    public void LoadPlayer ()
    {
      SAve_Game data = Save_System.LoadPlayer();
      volumeb = data.volume;

    }*/

    

    public void SetFaseMusic(AudioClip Audio)
    {
        faseM.clip = Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        } 

    }

    public void SetVolume(float volume)
    {
      GM.Volume = volume;
      

      audioMixer.SetFloat("Volume", GM.Volume);
      
      

    }


    
    
    
}
