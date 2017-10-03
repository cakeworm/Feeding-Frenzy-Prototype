using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceJump : MonoBehaviour {

    public GameObject jumper;
    public UnityEngine.Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<UnityEngine.Rigidbody> ();
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		Jump();
	}


    private void Jump()
    {
        /*  jumper.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        jumper.rigidbody.isKinematic = false;
        jumper.rigidbody.AddForce (Vector3.up * 6.0f, ForceMode.VelocityChange);
        jumper.rigidbody.AddForce (enemy.chaseTarget.transform.position - enemy.transform.position * 1.0f, ForceMode.Impulse);
        jumper.SetGrounded (false);       */       
    }
 
}
