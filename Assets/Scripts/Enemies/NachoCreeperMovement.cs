using UnityEngine;
using System.Collections;

public class NachoCreeperMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;
    private bool _midrange;
    private bool _close;

    public Transform target;
    NavMeshAgent agent;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    //START INITIALIZING
    void Start ()
    {
        _alive = true;
        _midrange = false;
        _close = false;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //UPDATES
    void Update()
    {
        if (_alive)
        {          
            Follow();

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 9.0f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }       
       
            }

            if (_midrange)
            {
                CirclePlayer();                            

                if (Vector3.Distance(transform.position, target.position) >= 17.0)
                {
                    Debug.Log("Enemy is far away and should be chasing!");
                    SetMidrange(false);
                    agent.Resume();                           
                }

               else if (Vector3.Distance(transform.position, target.position) <= 10.0f)
                {    
                    Debug.Log("Enemy is close and should be chasing!");               
                    SetMidrange(false);
                    agent.Resume();
                }

                      
            }    
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance >= 10.0f & distance <= 17.0f)
        {
            SetMidrange(true);
            Debug.Log("Enemy is midrange and should be rotating!");
        }           
    }

    //SPECIAL METHODS
        void Follow()
        {
            agent.SetDestination(target.position);           

        }

        void CirclePlayer()
        {
            agent.Stop();
            agent.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        } 





    // BOOLS 
    public void SetAlive (bool alive)
    {
        _alive = alive;
    }   

    public void SetMidrange(bool midrange)
    {
        _midrange = midrange;    
    }

    public void SetClose(bool close)
    {
        _close = close;
    }
    

}
