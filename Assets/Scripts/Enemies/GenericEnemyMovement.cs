using UnityEngine;
using System.Collections;

public class GenericEnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool isAlive;

    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Start ()
    {
        isAlive = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    
    void Update ()
    {

        

        if (isAlive)
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

       /* if (!isAlive)
            //agent.velocity = Vector3.zero;
            agent.Stop();
            */
        
    }

    public void SetAlive (bool alive)
    {
        isAlive = alive;
    }   
    

}
