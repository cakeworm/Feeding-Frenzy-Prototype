using UnityEngine;
using System.Collections;

public class BabyNachos : MonoBehaviour {

    public float speed = 11.0f;

    public GameObject [] cheeseSplats;
    public GameObject cheeseSplat_1;
    public GameObject cheeseSplat_2;

    public int food = 1;

    void Start()
    {
    cheeseSplats = new GameObject[2];
    cheeseSplats [0] = cheeseSplat_1;
    cheeseSplats [1] = cheeseSplat_2;
  
    }

    void FixedUpdate ()
    {
        transform.Rotate  (Vector3.right* Time.deltaTime);
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        GameObject hitObject = collision.transform.gameObject;
       
        //ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
        EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();



        if (enemyHealth != null)
        {
                    
          enemyHealth.TakeDamage(food, pos);
        }
        else
        {
            Instantiate(cheeseSplats[Random.Range(0,1)], pos, rot);  
        }
        Destroy (this.gameObject);

    } 
}
