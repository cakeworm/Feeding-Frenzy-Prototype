using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour 
{
    public NCStatePatternEnemy enemy;

    void Awake()
    {
        enemy = transform.parent.GetComponent <NCStatePatternEnemy>();       
    }

    void OnCollisionEnter (Collision collision)

    {
      Vector3 colLocation = collision.transform.position;

        Debug.Log ("I'm hitting something");

        Debug.Log (colLocation);

       

       if (!enemy.isGrounded  && collision.gameObject.tag == "Ground")
        {
            Debug.Log ("The collision IF statement is firing.");
           
            enemy.rigidbody.constraints = RigidbodyConstraints.None;
            enemy.rigidbody.isKinematic = true;
            //enemy.isGrounded = true;           
            enemy.SetGrounded (true);
            enemy.navMeshAgent.enabled = true;
        } 
   }
}