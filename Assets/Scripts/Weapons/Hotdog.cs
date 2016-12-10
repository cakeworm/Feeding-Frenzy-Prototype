using UnityEngine;
using System.Collections;

public class Hotdog : MonoBehaviour 

{  
    void OnTriggerEnter (Collider other)
    {
        GameObject hitObject = other.transform.gameObject;
        ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();             

        if (target != null)
        {
            target.ReactToHit();
        }

     }

}


