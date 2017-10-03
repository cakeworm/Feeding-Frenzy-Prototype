using UnityEngine;
using System.Collections;

public class RangeBetweenDistances : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);




        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Distance: " + distance);
        }

        if (distance > 5.0f & distance < 15.0f)
        {

        }

    }

   
}

