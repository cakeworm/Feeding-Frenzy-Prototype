using UnityEngine;
using System.Collections;

public class PeaShooter : MonoBehaviour {

    //private GameObject peaShooter;
    public GameObject[] peaSplats;

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
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    
                    target.ReactToHit();

                }
                else
                {
                    Instantiate (peaSplats[Random.Range(0,2)], hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));
                }
            }
        }
    }

   
}
