using UnityEngine;
using System.Collections;

public class Nachos : MonoBehaviour {

    public float speed = 11.0f;

    [SerializeField] private GameObject babyNachosPrefab;
    private GameObject _babyNachos;

    //public int damage = 1;

    void FixedUpdate ()
    {
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate (babyNachosPrefab, transform.position, transform.rotation);
        Destroy (this.gameObject);

    }

}
