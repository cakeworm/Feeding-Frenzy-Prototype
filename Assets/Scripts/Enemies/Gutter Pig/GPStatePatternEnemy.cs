using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPStatePatternEnemy : MonoBehaviour {

    //public float searchingTurnSpeed = 120f;
    public float minChaseDuration = 5f;
    public float outOfRange = 22f;
    public float sightRange = 20f;
    //public float circleRange =8f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3 (0, .5f, 0);
    public MeshRenderer meshRendererFlag;
    public BoxCollider collider;

    public bool isHyper = false;
    public bool isAlive = true;
    public bool isGrounded = true;
    public bool isChasing = false;




    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public GutterPigPatrolState patrolState;
    [HideInInspector] public GutterPigChaseState chaseState;
    [HideInInspector] public GutterPigCircleState circleState;
    public GutterPigJump gutterPigJump;


 


    //[HideInInspector] public EnemyHealth enemyHealth;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    [HideInInspector] public UnityEngine.Rigidbody rigidbody;
    [HideInInspector] public UnityEngine.Animator animator;


    private void Awake()

    {
       
        
        patrolState = new GutterPigPatrolState (this);
        chaseState = new GutterPigChaseState (this);
        circleState = new GutterPigCircleState (this);



        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        navMeshAgent.speed = 3.5f;

        rigidbody = GetComponent<UnityEngine.Rigidbody> ();

        animator = GetComponent<UnityEngine.Animator> ();

        collider = GetComponent<UnityEngine.BoxCollider> ();

        gutterPigJump = GetComponent<GutterPigJump> ();




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

    public void SetChasing(bool chasing)
    {
        isChasing = chasing;
    }

  

}
