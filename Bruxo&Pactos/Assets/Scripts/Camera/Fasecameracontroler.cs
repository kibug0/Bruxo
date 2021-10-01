using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Fasecameracontroler : MonoBehaviour
{
    public CameraTroca CameraController;
    public WavesSystens fase;
    public int fasesfeitas;
    public Collisordecamera AreaController;

    
    void Start()
    {
        Iniciarfase();
    }
    
    public void Iniciarfase()
    {
        
        
        Debug.Log("Iniciarfase");
        AreaController.OnAreaAtivaAction = TrocarCamera;

    }
   
    public void proximafase()
    {
        fase.começar();
        fasesfeitas++;
        

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

