using UnityEngine;
using System.Collections;

public class GenericEnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;

    public Transform target;
    NavMeshAgent agent;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Start ()
    {
        _alive = true;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    
    void Update ()
    {

        

        if (_alive)
        {
            agent.SetDestination(target.position);
        
            Ray ray = new Ray (transform.position, transform.forward);
            RaycastHit hit;
            
            if(Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate (fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint (Vector3.forward *1.5f);
                        _fireball.transform.rotation =transform.rotation;
                    }
                }
         
       
            }
        }

       /* if (!_alive)
            //agent.velocity = Vector3.zero;
            agent.Stop();
            */
        
    }

    public void SetAlive (bool alive)
    {
        _alive = alive;
    }   
    

}
