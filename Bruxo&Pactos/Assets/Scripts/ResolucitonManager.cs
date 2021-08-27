using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ResolucitonManager : MonoBehaviour
{
    //GameMAnager com as suas informações salvas
    public GameManager GM;

    Resolution [] resolutions;

    public GameObject listaresu;

    public GameObject listaquali;

    public int CurrentResolutionIndex;


    public List<string> optionsresu = new List<string>();

    public List<string> optionsquali = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
      if(listaresu == null)
      {
        

        listaresu = GameObject.FindGameObjectWithTag("Listresu");
      }

      if(listaquali == null)
      {
        

        listaquali = GameObject.FindGameObjectWithTag("Listqual");
      }

        resolutions = Screen.resolutions;
      

      

      listaresu.GetComponent<Dropdown>().ClearOptions();

      
      optionsquali.Add("low");
      optionsquali.Add("Medium");
      optionsquali.Add("High");
      optionsquali.Add("Ultra");

      CurrentResolutionIndex = 0;

      for(int i = 0; i < resolutions.Length; i++)
      {
        string option = resolutions[i].width + "x" + resolutions[i].height + "x" + resolutions[i].refreshRate;
        Debug.Log(resolutions[i].width + "x" + resolutions[i].height + " : " + resolutions[i].refreshRate);

        if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
          CurrentResolutionIndex = i;
        }

        optionsresu.Add(option);
      }

      #region especificações do dropdown de resolução
      listaresu.GetComponent<Dropdown>().AddOptions(optionsresu);
      listaresu.GetComponent<Dropdown>().value = CurrentResolutionIndex;
      listaresu.GetComponent<Dropdown>().RefreshShownValue();
      #endregion

      #region Especificações do dropdown de qualidade
      listaquali.GetComponent<Dropdown>().AddOptions(optionsquali);
      

      #endregion 
    }

    public void Update()
    {
      #region Recaptura do dropdown da resolução/especificaçoes e funcionamento dele
      if(listaresu == null)
      {

        if(GameObject.FindGameObjectWithTag("Listresu") == null)
        {
          return;
        }





        listaresu = GameObject.FindGameObjectWithTag("Listresu");
        listaresu.GetComponent<Dropdown>().ClearOptions();
        listaresu.GetComponent<Dropdown>().AddOptions(optionsresu);
        listaresu.GetComponent<Dropdown>().value = GM.Resolution;
        listaresu.GetComponent<Dropdown>().RefreshShownValue();
        //listaresu.GetComponent<Dropdown>().onValueChanged.AddListener(delegate {SetResolution(GM.Resolution);});
      }
      listaresu.GetComponent<Dropdown>().onValueChanged.AddListener(delegate {SetResolution(listaresu.GetComponent<Dropdown>().value);});
      #endregion
    
      #region Recaptura do dropdown da qualidade/especificaçoes e funcionamento dele
      if(listaquali == null)
      {
        if(GameObject.FindGameObjectWithTag("Listqual") == null)
        {
          return;
        }






        listaquali = GameObject.FindGameObjectWithTag("Listqual");
        listaquali.GetComponent<Dropdown>().ClearOptions();
        listaquali.GetComponent<Dropdown>().AddOptions(optionsquali);
        listaquali.GetComponent<Dropdown>().value = GM.Qualidade;
        
      }
      listaquali.GetComponent<Dropdown>().onValueChanged.AddListener(delegate {qualidade(listaquali.GetComponent<Dropdown>().value);});
      #endregion
    }

    // Update is called once per frame
    public void SetResolution(int resolutionIndex)
    {

      Resolution resolution = resolutions[resolutionIndex];

      Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

      GM.Resolution = resolutionIndex;


      

    }

    public void qualidade(int qualidadeIndex)
    {
      QualitySettings.SetQualityLevel(qualidadeIndex);
      GM.Qualidade = qualidadeIndex;
    }

    //Fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
    	Screen.fullScreen = isFullscreen;
    }
}
