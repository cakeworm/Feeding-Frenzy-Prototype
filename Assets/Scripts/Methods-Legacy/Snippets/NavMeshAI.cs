using UnityEngine;
using System.Collections;

public class NavMeshAI : MonoBehaviour {
    
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
	void Start () 
    {
	    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    agent.SetDestination(target.position);
	}



}
