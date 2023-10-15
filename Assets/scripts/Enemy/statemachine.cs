using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statemachine : MonoBehaviour
{
    public BaseState activestate;
    public patrolstate Patrolstate;

    public  void Initialise()
    {
        Patrolstate = new patrolstate();
        changestate(Patrolstate);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activestate!=null)
        {
            activestate.perform();
        }
    }

    public void changestate(BaseState newstate)
    {
        if (activestate!=null)
        {
           activestate.exit(); 
        }

        activestate = newstate;
        if (activestate!=null)
        {
            activestate.Statemachine = this;
            activestate.enemy = GetComponent<Enemy>();
            activestate.enter();
        }
    }
}
