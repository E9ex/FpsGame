using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackstate : BaseState
{
    private float movetimer;
    private float losePlayerTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void enter()
    {
     
    }

    public override void perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            movetimer += Time.deltaTime;
            if (movetimer>Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                movetimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer>8)
            {
                Statemachine.changestate(new patrolstate());
            }
        }
        
    }

    public override void exit()
    {
        
    }
}
