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
    public AudioClip Fase2Audio;
    public AudioClip Fase3Audio;

    //GameManager para pegar o dinheiro
    public GameManager GM;

    public float volumeb;

    public GameObject SliderMenu;

    



    //Volume
    public void Start()
    {
      
      
 
      faseM.clip = Fase1Audio;
      SetFaseMusic ();


    }

    public void Update(){
      //GM.Volume;

      if(GameObject.FindGameObjectWithTag("Volume"))
      {
        if(SliderMenu == null)
        {
          SliderMenu = GameObject.FindGameObjectWithTag("Volume");
          SliderMenu.GetComponent<Slider>().minValue = -80;
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

    

    public void SetFaseMusic ()
    {
      if(GM.FASE == "Cidade_1")
      {

        faseM.clip = Fase1Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        


      }


      if(GM.FASE == "Plano_Astral")
      {

        faseM.clip = Fase2Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        


      }

      if(GM.FASE == "Cidade_2")
      {

        faseM.clip = Fase3Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        
        

      }
      

    }

    public void SetVolume(float volume)
    {
      GM.Volume = volume;
      

      audioMixer.SetFloat("Volume", GM.Volume);
      
      

    }


    
    
    
}
