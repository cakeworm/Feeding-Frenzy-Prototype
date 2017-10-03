using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisattachReattachNavMesh : MonoBehaviour {} 
/*
{

    private readonly NCStatePatternEnemy enemy;

    public NachoBeastChaseState (NCStatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

	void Update () 
    {
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
            enemy.SetGrounded (true);
            enemy.navMeshAgent.enabled = true;
        } 
    }



        private void Jump()
    {
        enemy.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        enemy.rigidbody.isKinematic = false;
        //enemy.rigidbody.AddForce (Vector3.up * 6.0f, ForceMode.VelocityChange);
        //enemy.rigidbody.AddForce (enemy.chaseTarget.transform.position - enemy.transform.position * 1.0f, ForceMode.Impulse);
         enemy.SetGrounded (false);              
    }
            	
	}
}

*/