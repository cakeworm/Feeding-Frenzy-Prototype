using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoBeastJumpState :  IEnemyState 

{
    private readonly NBStatePatternEnemy enemy;   

    public NachoBeastJumpState (NBStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

  

   public void UpdateState () 
    {

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

    }

    public void ToJumpState ()
    {

    }

    public void ToCircleState ()
    {

    }


}