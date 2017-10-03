using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoBeastDieState : IEnemyState 
{
    private readonly NCStatePatternEnemy enemy;   

    public NachoBeastDieState (NCStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

   
   public void UpdateState () 
    {
        Die();
    }
    

    public void OnTriggerEnter (Collider other)
    {
        Debug.Log ("Can't transition: Die is a terminal state!");
    }

    public void OnCollisionEnter (Collision collision)
    {
    }

    public void ToPatrolState ()   
    {
        Debug.Log ("Can't transition: Die is a terminal state!");
    }

    public void ToChaseState ()
    {
        Debug.Log ("Can't transition: Die is a terminal state!");
    }

    public void ToJumpState ()
    {
        Debug.Log ("Can't transition: Die is a terminal state!");
    }

    public void ToCircleState ()
    {
        Debug.Log ("Can't transition: Die is a terminal state!");
    }

    public void ToDieState()
    {
        Debug.Log ("Can't transition into same state");
    }

    void Die()
    {
        // The enemy is dead.
        enemy.navMeshAgent.enabled = false;
        enemy.SetAlive(false);
          

        //isSated = true;

        /* StartSinking();

        
        // Turn the collider into a trigger so shots can pass through it.
              if (enemy.GetComponent<BoxCollider>() !=null)
        {
            enemy.enemyHealth.boxCollider.isTrigger = true;       
        }

        else if (enemy.GetComponent<CapsuleCollider>() !=null)
        {
            enemy.enemyHealth.capsuleCollider.isTrigger = true;       
        }
        // Tell the animator that the enemy is dead.
        //anim.SetTrigger ("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
       //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();


    }

    public void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        //GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        enemy.GetComponent <Rigidbody> ().isKinematic = true;

        // The enemy should now sink.
        enemy.enemyHealth.isSinking = true;

        // Increase the score by the enemy's score value.
        //ScoreManager.score += scoreValue;

        // After 2 seconds destroy the enemy.
        enemy.Destroy (enemy.gameObject, 2f);
    }  */
    }
}
