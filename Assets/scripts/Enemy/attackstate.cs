using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackstate : BaseState
{
    private float movetimer;
    private float losePlayerTimer;
    private float shotTimer;
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
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer>enemy.firerate)
            {
                shoot();
            }
            if (movetimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                movetimer = 0;
            }

            enemy.Lastknowpos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                Statemachine.changestate(new searchstate());
            }
        }

    }

    public void shoot()
    {
        Transform gunbarrel = enemy.gunbarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/bullet") as GameObject,gunbarrel.position,enemy.transform.rotation);
        Vector3 shootdirection=(enemy.Player.transform.position-gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity =
            Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootdirection * 40;
        Debug.Log("shoot");
        shotTimer = 0;
    }

    public override void exit()
    {
        
    }
}
