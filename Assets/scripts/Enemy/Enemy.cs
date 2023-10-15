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
    [SerializeField]
    private string currentstate;

    public Path path;

    void Start()
    {
        Statemachine = GetComponent<statemachine>();
        _agent = GetComponent<NavMeshAgent>();
        Statemachine.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
