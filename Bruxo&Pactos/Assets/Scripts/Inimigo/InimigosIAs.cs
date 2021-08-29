using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InimigosIAs : MonoBehaviour
{
    public Transform target;

    public float speed = 200;

    public float jumpforce = 200;

    [SerializeField]
    private Vector2 Direção;

    public float nextWayPointDistanci = 3f;

    public Transform EnimieGfx;

    Path caminho;

    int currentWayPoint = 0;

    bool reachedEndpoint = false;

    Seeker seeker;
    Rigidbody2D Rg;

    void Start()
    {
        Rg = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

        

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
        Vector2 Forcex = new Vector2(1,0) * speed * Time.deltaTime;

        Direção = direcao;

        
        

        float distance = Vector2.Distance(Rg.position, caminho.vectorPath[currentWayPoint]);

        if(distance < nextWayPointDistanci)
        {
           currentWayPoint++;
        }

        if(Force.x >= 0.01f)
        {
            EnimieGfx.localScale = new Vector3(-1f, 1f, 1f);
            Rg.AddForce(Forcex);
        }
        else if(Force.x <= -0.01f)
        {
            EnimieGfx.localScale = new Vector3(1f, 1f, 1f);
            Rg.AddForce(-Forcex);
        }

        





    }
}
