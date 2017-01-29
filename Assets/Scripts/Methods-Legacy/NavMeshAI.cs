using UnityEngine;
using System.Collections;

public class NavMeshAI : MonoBehaviour {
    
    public Transform target;
    NavMeshAgent agent;

    // Use this for initialization
	void Start () 
    {
	    agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    agent.SetDestination(target.position);
	}



}
