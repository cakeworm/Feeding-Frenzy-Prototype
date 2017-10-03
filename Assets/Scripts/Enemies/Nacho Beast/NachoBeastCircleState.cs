using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoBeastCircleState : IEnemyState 

{
    private readonly NCStatePatternEnemy enemy;   

    public NachoBeastCircleState (NCStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

   
    public void UpdateState () 
    {
        //Look ();
        Circle ();

        if (enemy.isHyper)
        {
            Debug.Log ("i am hyper");
        }
    }

    public void OnTriggerEnter (Collider other)
    {
    }

    public void OnCollisionEnter(Collision collision)
    {

    }

    public void ToPatrolState ()
    {
    }

    public void ToChaseState ()
    {
        enemy.currentState = enemy.chaseState;
         
    }

    public void ToJumpState()
    {
        enemy.currentState = enemy.jumpState;
    }

    public void ToCircleState ()
    {
        Debug.Log ("Can't transition into same state");
    }

   

    private void Look()
    {
        RaycastHit hit;
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;

        }
        else
        {
         ToChaseState ();
        } 
    }


    private void Circle()
    {
        enemy.navMeshAgent.Stop ();
        enemy.meshRendererFlag.material.color = Color.red;

        RaycastHit hit;
       // Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
        if (Physics.SphereCast(enemy.eyes.transform.position, 3.0f, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.distance <= 8.0f && hit.collider.CompareTag("Player"))


        {
            enemy.chaseTarget = hit.transform;
            enemy.transform.RotateAround(enemy.chaseTarget.transform.position, Vector3.up, 100 * Time.deltaTime);
            Debug.Log ("I should be rotating!");
        }
        else //if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.distance >= 9.0f && hit.collider.CompareTag("Player"))
        {
        
         ToChaseState ();
        }







    }

}