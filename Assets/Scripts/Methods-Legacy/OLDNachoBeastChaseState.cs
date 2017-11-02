using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDNachoBeastChaseState :  IEnemyState 

{

    private readonly NBStatePatternEnemy enemy;
    private float chaseTimer;
    private bool isHyper = false;
    //public bool isGrounded = true;

    public float jumpSpeed;
    public float forwardSpeed;
 
    //float enemyPosX;
    //float enemyPosY;
    //float enemyPosZ;
    //float jumpPosX;
    //float jumpPosY;
    //float jumpPosZ;


    public OLDNachoBeastChaseState (NBStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

   
  

    public void UpdateState()
    {
        
        Debug.Log (enemy.transform.forward.z);
        //Look();     
        if (enemy.isGrounded)
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
        

        if (!enemy.isGrounded  && other.gameObject.tag == "Ground")
        {
                   
            enemy.rigidbody.constraints = RigidbodyConstraints.None;
            enemy.rigidbody.isKinematic = true;
                     
            enemy.SetGrounded (true);
            enemy.navMeshAgent.enabled = true;
        } 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!enemy.isGrounded  && collision.gameObject.tag == "Ground")
        {
            enemy.rigidbody.constraints = RigidbodyConstraints.None;
            enemy.rigidbody.isKinematic = true;
            //enemy.isGrounded = true;           
            enemy.SetGrounded (true);
            enemy.navMeshAgent.enabled = true;
        } 
    }

  

    public void ToPatrolState ()
    {
        enemy.currentState = enemy.patrolState;
        chaseTimer = 0f;
    }

    public void ToChaseState ()
    {
        Debug.Log ("Can't transition into same state");
    }



    public void ToCircleState ()
    {
        enemy.currentState = enemy.circleState;
            chaseTimer = 0f;
       
    }



    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            Chase ();
        }
    }

    private void Chase()
    {
         
        
        enemy.navMeshAgent.Stop ();
        enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Resume ();
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;

        chaseTimer += Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            enemy.navMeshAgent.enabled = false;
            Jump();
       
           
        }          

        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player") && hit.distance <= 8.0f)

            ToCircleState();
        
        else if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.outOfRange) && hit.distance >= 15.01f && chaseTimer >= enemy.minChaseDuration)

            ToPatrolState();
        /*else  (chaseTimer >= enemy.minChaseDuration)
            ToPatrolState (); */         
    }

    private void Jump()
    {
        //none of this Pos shit works with iTween--fix it! 
        /*enemyPosX = enemy.transform.position.x;
        enemyPosY = enemy.transform.up.y;
        enemyPosZ = enemy.transform.position.z;
        jumpPosX = enemy.chaseTarget.transform.position.x - enemyPosX;
        jumpPosY = enemyPosY += 5.4f; 
        jumpPosZ = enemy.chaseTarget.transform.position.z - enemyPosZ; */

        enemy.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        enemy.rigidbody.isKinematic = false;
        //enemy.rigidbody.AddForce (Vector3.up * 6.0f, ForceMode.VelocityChange);
        //enemy.rigidbody.AddForce (enemy.chaseTarget.transform.position - enemy.transform.position * 1.0f, ForceMode.Impulse);

        //iTween.MoveTo(enemy.gameObject, iTween.Hash("X", jumpPosX, "Y", jumpPosY, "Z", jumpPosZ , "Time", 1.5));
        //Can iTween function by using the subtraction position-find hack I discovered? Stay tuned . . .

        enemy.SetGrounded (false);
 

              
    }

}



