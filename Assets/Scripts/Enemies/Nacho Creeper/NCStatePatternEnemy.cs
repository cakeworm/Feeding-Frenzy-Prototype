using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCStatePatternEnemy : MonoBehaviour {

    //public float searchingTurnSpeed = 120f;
    public float minChaseDuration = 5f;
    public float outOfRange = 100f;
    public float sightRange = 15f;
    //public float circleRange =8f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3 (0, .5f, 0);
    public MeshRenderer meshRendererFlag;
    public BoxCollider collider;

    public bool isHyper = false;
    public bool isAlive = true;
    public bool isGrounded = true;



    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public NachoCreeperPatrolState patrolState;
    [HideInInspector] public NachoCreeperChaseState chaseState;
    [HideInInspector] public NachoCreeperJumpState jumpState;
    [HideInInspector] public NachoCreeperCircleState circleState;
 


    //[HideInInspector] public EnemyHealth enemyHealth;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    [HideInInspector] public UnityEngine.Rigidbody rigidbody;


    private void Awake()

    {
       
        
       patrolState = new NachoCreeperPatrolState (this);
       chaseState = new NachoCreeperChaseState (this);
       jumpState = new NachoCreeperJumpState (this);
       circleState = new NachoCreeperCircleState (this);


        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        navMeshAgent.speed = 3.5f;

        rigidbody = GetComponent<UnityEngine.Rigidbody> ();

        collider = GetComponent<UnityEngine.BoxCollider> ();


    }



    // Use this for initialization
	void Start () 
    {
       currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (isAlive)
        {
            currentState.UpdateState();
        }
	}

    void OnTriggerEnter(Collider other)
    {
       currentState.OnTriggerEnter (other);
    }

    public void SetAlive (bool alive)
    {
        isAlive = alive;
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }


}
