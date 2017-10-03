using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoBeastChaseState : IEnemyState 

{

    private readonly NCStatePatternEnemy enemy;
   
   
    private float chaseTimer;

   

    public float jumpSpeed;
    public float forwardSpeed;
 


    public NachoBeastChaseState (NCStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

  

   
 
    public void UpdateState()
    {
        
       
             
        if (enemy.isAlive)
        {
            Chase();
        }

        if (enemy.isHyper)
        {
            Debug.Log("i am hyper");
        }      
   
    }

    public void OnTriggerEnter(Collider other)
    {

    } 


    public void OnCollisionEnter(Collision other)
    {

    } 

    public void ToPatrolState ()
    {
        enemy.nachoBeastJump.enabled = false;
        enemy.SetChasing (false);
        enemy.currentState = enemy.patrolState;
        chaseTimer = 0f;
    }

    public void ToChaseState ()
    {
        Debug.Log ("Can't transition into same state");
    }

    public void ToJumpState()
    {
        enemy.currentState = enemy.jumpState;
    }

    public void ToCircleState ()
    {
        enemy.nachoBeastJump.enabled = false;
        enemy.SetChasing (false);
        enemy.currentState = enemy.circleState;
            chaseTimer = 0f;
       
    }

    private void Chase()
    {
        enemy.nachoBeastJump.enabled = true;

        enemy.SetChasing (true);
        enemy.navMeshAgent.Stop();
        enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Resume();
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;

        chaseTimer += Time.deltaTime;     


        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player") && hit.distance <= 8.0f)

            ToCircleState();
        
        else if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.outOfRange) && hit.distance >= 15.01f && chaseTimer >= enemy.minChaseDuration)

            ToPatrolState();               
    }

 

}



