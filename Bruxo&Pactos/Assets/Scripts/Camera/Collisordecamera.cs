using Cinemachine;
using UnityEngine;

public class Collisordecamera : MonoBehaviour
{
    public delegate void AreaFaseAtivaDelegate(CinemachineVirtualCamera vcam);
    public AreaFaseAtivaDelegate OnAreaAtivaAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("foi");
        if(collision.GetComponent<CinemachineVirtualCamera>() is  CinemachineVirtualCamera cam)
        {
            Debug.Log("player entrou na area" + collision.gameObject.name);

            OnAreaAtivaAction?.Invoke(cam);
            cam.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

