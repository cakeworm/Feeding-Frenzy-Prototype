using UnityEngine;
using System.Collections;

public class SlowDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {

    Destroy(gameObject, 4);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
