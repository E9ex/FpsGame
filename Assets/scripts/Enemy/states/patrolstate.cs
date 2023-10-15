using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolstate : BaseState
{
   public int waypointIndex;
   public float waitTimer;
   public override void enter()
   {
      
   }
   public override void perform()
   {
      patrolCycle();
   }
   public override void exit()
   {
      
   }

   public void patrolCycle()
   {
      if (enemy.Agent.remainingDistance<.2f)
      {
         waitTimer += Time.deltaTime;
         if (waitTimer > 3)
         {

            if (waypointIndex < enemy.path.waypoint.Count - 1)
               waypointIndex++;
            else
               waypointIndex = 0;
            enemy.Agent.SetDestination(enemy.path.waypoint[waypointIndex].position);
            waitTimer = 0;
         }
      }
   }
}
