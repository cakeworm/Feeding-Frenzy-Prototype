using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public Transform target;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () 
    {
        transform.RotateAround(target.transform.position,  Vector3.up, 20 *Time.deltaTime);
    }
}
