using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterPigJumpState :  IEnemyState 

{
    private readonly GPStatePatternEnemy enemy;   

    public GutterPigJumpState (GPStatePatternEnemy statePatternEnemy)
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