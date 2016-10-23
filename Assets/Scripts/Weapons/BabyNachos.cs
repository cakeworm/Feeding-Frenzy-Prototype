using UnityEngine;
using System.Collections;

public class BabyNachos : MonoBehaviour {

    public float speed = 11.0f;

    //public int damage = 1;

    void FixedUpdate ()
    {
        transform.Rotate  (Vector3.right* Time.deltaTime);
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy (this.gameObject);

    }
}
