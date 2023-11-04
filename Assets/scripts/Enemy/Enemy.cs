using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private statemachine Statemachine;
    private NavMeshAgent _agent;

    public NavMeshAgent Agent
    {
        get => _agent;
    }

    [SerializeField] private string currentstate;
    public Path path;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public Transform gunbarrel;
    public float Eyeheight;
    private Vector3 lastknowPos;
    [Range(.1f, 10f)] public float firerate;
    public Vector3 Lastknowpos
    {
        get => lastknowPos;
        set => lastknowPos = value;
    }

    public GameObject Player
    {
        get => player;
    }
    

    void Start()
    {
        Statemachine = GetComponent<statemachine>();
        _agent = GetComponent<NavMeshAgent>();
        Statemachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentstate = Statemachine.activestate.ToString(); 
    }

    public bool CanSeePlayer()
    {
        if (player!=null)
        {
            if (Vector3.Distance(transform.position,player.transform.position)<sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position-(Vector3.up*Eyeheight);
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angelToPlayer>=-fieldOfView&&angelToPlayer<=fieldOfView)
                {
                    Ray ray = new Ray(transform.position+(Vector3.up*Eyeheight), targetDirection);
                    RaycastHit hitinfo = new RaycastHit();
                    if (Physics.Raycast(ray,out hitinfo,sightDistance))
                    {
                        if (hitinfo.transform.gameObject==player)
                        {
                            Debug.DrawRay(ray.origin,ray.direction*sightDistance);
                            return true;
                        }
                    }
                }
            } 
        }
        return false;
    }
}
