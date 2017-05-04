using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour {


    public float lerpTime = 3.0f;
    public float verticalDistance = 40.0f;
    public float horizontalDistance = 100.0f;

    public Vector3 startPos;
    private new Rigidbody rigidbody;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;




	void Start () 
    {
		    rigidbody = GetComponent <Rigidbody>();
        agent = GetComponent <UnityEngine.AI.NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update()
    {

        if (Input.GetKey("space"))


        {
            
            StartCoroutine("Jump");
        }
	}


        IEnumerator Jump() 
        {
           agent.enabled = false;

           rigidbody.freezeRotation = true;

           rigidbody.AddRelativeForce (0, verticalDistance, horizontalDistance);

           /*void OnCollisionEnter (Collision other)
           {
                if (other.CompareTag ("Ground"));
                {
                agent.enabled = true;
                }
           } */

           
          
           return null;

            //transform.position = Vector3.Lerp (this.transform.position, target.position, speed);
            //yield return null;
        }
}
