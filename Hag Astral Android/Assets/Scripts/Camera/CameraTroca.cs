using Cinemachine;
using UnityEngine;

public class CameraTroca : MonoBehaviour
{
    //o que confere os estatus da camera
    public enum StatusCamera { Parada, Movendo }


    //A camera que segue o player
    public CinemachineVirtualCamera playercam;

    //Camera que esta sendo usada no atual momento
    CinemachineVirtualCamera cameraAtual;

    //Para mostrar os Status 
    [SerializeField] StatusCamera status;

    private void Start()
    {
        //Ah camera atual e a camera que segue o player
        cameraAtual = playercam;

        //Sendo assim ela esta em movimento
        status = StatusCamera.Movendo;
    }

    public StatusCamera Status
    {
        get
        {
            //Para retornar o status
            return status;
        }
    }

    public CinemachineVirtualCamera CameraAtual
    {
        get
        {
            //para retornar a camera atual
            return cameraAtual;
        }
    }

    public void TravarCamera()
    {
        //quando a camera parar de se mover
        status = StatusCamera.Parada;
    }

    public void TrocaCamera(CinemachineVirtualCamera vcam)
    {
        //ele troca a pioridade da camera atual para a camera principal ser a parada nova trasida pelo collidrer
        trocaprioridade(cameraAtual, vcam);
        cameraAtual = vcam;
    }

    public void trocaCameraprincipal()
    {
        trocaprioridade(cameraAtual, playercam);
        status = StatusCamera.Movendo;
    }

    
    void trocaprioridade(CinemachineVirtualCamera vCamAtual, CinemachineVirtualCamera vcamnova)
    {
        vCamAtual.Priority = 0;
        vcamnova.Priority = 1;
    }
}
