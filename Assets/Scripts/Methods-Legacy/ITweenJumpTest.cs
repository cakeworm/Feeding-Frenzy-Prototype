using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenJumpTest : MonoBehaviour {

 
 
    public float jumpSpeed;
    public float forwardSpeed;
 
    float playerPosY;
    float playerPosZ;
    float jumpPosY;
    float jumpPosZ;
  
    
    private UnityEngine.AI.NavMeshAgent agent;
 
    void Start()
    {
        agent = GetComponent <UnityEngine.AI.NavMeshAgent>();
    }
 
 
    void Update()
    {


         
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        if (Input.GetKeyDown("r"))
        {
            agent.enabled = true;
        }
    }
 
    private void Jump()
    {
        //Transform target;
        //Vector3 = target.position; 
         
        playerPosY = gameObject.transform.position.y;
        playerPosZ = gameObject.transform.position.z;
        jumpPosY = playerPosY += 5.4f;
        jumpPosZ = playerPosZ += 10.0f;

        agent.enabled = false;
        iTween.MoveTo(gameObject, iTween.Hash("Y", jumpPosY, "Z", jumpPosZ, "islocal", true, "Time", 1.5));
        //agent.enabled = true;
 
       
    }

   /* void OnCollisionEnter(Collision collision)
    {
        Vector3 colLocation = collision.transform.position;        
        Debug.Log ("I'm hitting something");

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log (colLocation);
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log (colLocation);
        }
    }

    */


}
