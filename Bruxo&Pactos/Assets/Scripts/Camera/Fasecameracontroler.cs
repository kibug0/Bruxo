using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Fasecameracontroler : MonoBehaviour
{
    public CameraTroca CameraController;
    public WavesSystens fase;
    public Collisordecamera AreaController;

    
    
    public void Iniciarfase()
    {
        fase.começar();
        //TotalFaseconcluida = 0;
        //faseAtual = -1;
        AreaController.OnAreaAtivaAction = TrocarCamera;

    }
   
    public void proximafase()
    {
        /*var proximaFaseIndex = faseAtual + 1;
        if(proximaFaseIndex < fases.Length)
        {
            
            if (faseAtual > 0) fases[faseAtual].desligarfase();

            faseAtual = proximaFaseIndex;
            fases[proximaFaseIndex].OnTodosMorreram = TodosSeForam;
            fases[proximaFaseIndex].LigarFase();
        }*/

    }
    public void TodosSeForam()
    {
        CameraController.trocaCameraprincipal();
        
        
    }
   void TrocarCamera(CinemachineVirtualCamera vcam)
    {
        
        CameraController.TrocaCamera(vcam);
        CameraController.TravarCamera();
        proximafase();
    }

    
}

