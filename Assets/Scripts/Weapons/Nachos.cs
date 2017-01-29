using UnityEngine;
using System.Collections;

public class Nachos : MonoBehaviour {

    public float speed = 1.0f;
    public GameObject [] cheeseSplats;
    public GameObject cheeseSplat_1;
    public GameObject cheeseSplat_2;

    public int food = 1;

    [SerializeField] private GameObject babyNachosPrefab;
    private GameObject _babyNachos;

    //public int damage = 1;

   void Start()
    {
    cheeseSplats = new GameObject[2];
    cheeseSplats [0] = cheeseSplat_1;
    cheeseSplats [1] = cheeseSplat_2;
  
    }

    void FixedUpdate ()
    {
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

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

        else
        {
            Instantiate(cheeseSplats[Random.Range(0,1)], pos, rot);  
        }

        Instantiate(babyNachosPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}


//Instantiate (peaSplats[Random.Range(0,2)], hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));