using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InimigosIAs : MonoBehaviour
{
    GameObject Player;
    public Transform target;

    public float speed = 200;

    public bool Wave = false;


    public Vector2 Direção;

    public float nextWayPointDistanci = 3f;

    public Transform EnimieGfx;

    Path caminho;

    int currentWayPoint = 0;

    bool reachedEndpoint = false;

    Seeker seeker;
    Rigidbody2D Rg;

    public Animator Andar;

    //O script de trocar a camera
    public CameraTroca CameTroca; 

    void Start()
    {
        Rg = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        if(target == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            target = Player.GetComponent<Transform>();

        }

        if(CameTroca == null)
        {
            
            CameTroca = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTroca>();

        }
        

        

    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
           seeker.StartPath(Rg.position, target.position, OnPathComplete);
        }
        
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            caminho = p;
            currentWayPoint = 0;
        }

    }

    void Update()
    {
        if(caminho == null)
        {
            return;
        }

        if(currentWayPoint >= caminho.vectorPath.Count)
        {
            reachedEndpoint = true;
            return;
        }
        else
        {
            reachedEndpoint = false;
        }

        Vector2 direcao = ((Vector2)caminho.vectorPath[currentWayPoint] - Rg.position).normalized;
        Vector2 Force = direcao * speed * Time.deltaTime;

        if(Andar != null)
        {
            Debug.Log(direcao);
            
            if(direcao.x > direcao.y)
            {
                Andar.SetFloat("horizontal", direcao.x);

            }

            else
            {
                Andar.SetFloat("vertical", direcao.y);

            }
            
        }

        

        Direção = direcao;

        if(Wave)
        {
            if(CameTroca.Status.Equals(CameraTroca.StatusCamera.Parada))
            {
                Areadacamera();
            }

        }
        


        Rg.velocity = new Vector2(Force.x, Force.y);

        
        

        float distance = Vector2.Distance(Rg.position, caminho.vectorPath[currentWayPoint]);

        if(distance < nextWayPointDistanci)
        {
           currentWayPoint++;
        }

        if(Force.x >= 0.01f)
        {
            EnimieGfx.localScale = new Vector3(-1f, 1f, 1f);
            
        }
        else if(Force.x <= -0.01f)
        {
            EnimieGfx.localScale = new Vector3(1f, 1f, 1f);
            
        }
        

        

        





    }

    
        
        

    

    private void Areadacamera()
    {
        //Altura da camera
        float altura = 2 * CameTroca.CameraAtual.m_Lens.OrthographicSize;

        //Largura da camera
        float largura = altura * CameTroca.CameraAtual.m_Lens.Aspect;

        //Limite da camera no eixo x
        float limitex = Mathf.Abs(largura / 2 - transform.localScale.x / 2);

        //Limite da camera no eixo y
        float limitey = Mathf.Abs(altura / 2 - transform.localScale.y / 2);
        
        //Os dois lados no limite no eixo x esquerda/direita
        Vector2 limitesx = new Vector2(CameTroca.CameraAtual.transform.position.x - limitex, CameTroca.CameraAtual.transform.position.x + limitex);

        //Os dois lados no limite no eixo y cima/baixo
        Vector2 limitesy = new Vector2(CameTroca.CameraAtual.transform.position.y - limitey, CameTroca.CameraAtual.transform.position.y + limitey);
      
        
        float clampedx = Mathf.Clamp(transform.position.x, limitesx.x, limitesx.y);

        float clampedy = Mathf.Clamp(transform.position.y, limitesy.x, limitesy.y);


        transform.position = new Vector3(clampedx, clampedy, transform.position.z);
    }
}
