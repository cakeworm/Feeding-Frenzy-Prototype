using UnityEngine;
using System.Collections;

public class PeaShooter : MonoBehaviour {

    //private GameObject peaShooter;

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
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator (Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds (1);
        
        Destroy (sphere);
    }
}
