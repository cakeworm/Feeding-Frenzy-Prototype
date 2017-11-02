using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoBeastJump : MonoBehaviour
{

    public NBStatePatternEnemy enemy;
    public Rigidbody rigidbody;
    public Animator anim;


	void Awake () 
    {
        enemy = GetComponent<NBStatePatternEnemy>();
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}

    void Start ()
    {
        StartCoroutine (JumpLogic());
    }

	// Update is called once per frame
	void Update()
    {       
     
	}
        
    IEnumerator JumpLogic()
    {
        Debug.Log ("I should only start once!");

        float minWaitTime = 2.0f;
        float maxWaitTime = 5.0f;
      
        while (enemy.isChasing)
        {
            Debug.Log ("JumpLogic active.");
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            Jump ();
        }
    }  

    void Jump ()
    {            
       anim.SetTrigger ("Jump Initiated");
       enemy.SetGrounded (false);
       enemy.navMeshAgent.acceleration = 40.0f;
       enemy.navMeshAgent.speed = 14.0f;
    }

    void BeGrounded()
    {
        enemy.SetGrounded (true);
        enemy.navMeshAgent.enabled = false;
        enemy.navMeshAgent.enabled = true;
       
       
        enemy.navMeshAgent.acceleration = 8.0f;
        enemy.navMeshAgent.speed = 3.5f;
    }

}
