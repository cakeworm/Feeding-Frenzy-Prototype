using UnityEngine;
using System.Collections;

public class Hotdog : MonoBehaviour 
{  
    public int food = 1;

    /*void OnTriggerEnter (Collider other)
    {
        
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, other.transform.position.normal);
        Vector3 pos = other.transform.position;

        GameObject hitObject = other.transform.gameObject;
        EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
                    
          enemyHealth.TakeDamage(food, pos);
        }

     }*/

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        GameObject hitObject = collision.transform.gameObject;
        EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
                    
            enemyHealth.TakeDamage(food, pos);
        }
    }
}


