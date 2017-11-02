using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterPigPatrolState :  IEnemyState 

{

    private readonly GPStatePatternEnemy enemy;
    private int nextWayPoint;
   


    public GutterPigPatrolState(GPStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }




    public void UpdateState()
    {
            Look();
            Patrol();   
    }

    public void OnTriggerEnter (Collider other)
    {
        //if (other.gameObject.CompareTag ("Player"))
        //   ToChaseState ();
    }

    public void OnCollisionEnter(Collision collision)
    {

    }


    public void ToPatrolState ()
    {
        Debug.Log ("Can't transition into same state");
    }

    public void ToChaseState ()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToCircleState ()
    {
        enemy.currentState = enemy.circleState;
    }



    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }

    void Patrol()
    {
        

        if (enemy.isHyper)
        {
            enemy.navMeshAgent.speed = 3.5f;
            enemy.isHyper = false;
            Debug.Log ("I am no longer hyper. Phew!");
        }

        enemy.navMeshAgent.Stop ();
        enemy.meshRendererFlag.material.color = Color.green;       
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();




        //Below snippet is from Interface training; going to use the Unity API snippet instead
        //if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        if (enemy.navMeshAgent.remainingDistance <= 0.5f)
        {
            nextWayPoint = Random.Range (0, enemy.wayPoints.Length);
        }
    }

}
