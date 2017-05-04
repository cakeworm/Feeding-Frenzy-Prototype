using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoCreeperJumpState :  IEnemyState 

{
    private readonly NCStatePatternEnemy enemy;   

    public NachoCreeperJumpState (NCStatePatternEnemy statePatternEnemy)
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