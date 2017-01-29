using UnityEngine;
using System.Collections;

public class PeaShooter : MonoBehaviour {

    //private GameObject peaShooter;
    public GameObject[] peaSplats;
    public int food = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            


            //Ray ray = new Ray (transform.position, Vector3.forward);
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection (Vector3.forward);
            Debug.DrawRay (transform.position, forward, Color.green);





            if (Physics.Raycast(transform.position, (forward), out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();
                Vector3 pos = hit.point;

                Instantiate (peaSplats[Random.Range(0,2)], hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));

                if (enemyHealth!= null)
                    {
                        enemyHealth.TakeDamage(food, pos );
                    }
                

                    
                
            }
        }
    }

   
}
