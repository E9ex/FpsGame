using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchstate : BaseState
{
    private float searchtimer;
    private float moveTimer;
    public override void enter()
    {
        enemy.Agent.SetDestination(enemy.Lastknowpos);
    }
    public override void perform()
    {
        if (enemy.CanSeePlayer())
        {
            Statemachine.changestate(new attackstate());
        }

        if (enemy.Agent.remainingDistance<enemy.Agent.stoppingDistance)
        {
            searchtimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if (searchtimer>10)
            {
                Statemachine.changestate(new patrolstate());
            }
        }
    }
    public override void exit()
    {
        
    }
}
