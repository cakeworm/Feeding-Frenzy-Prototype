using UnityEngine;
using System.Collections;

public class NachoLauncher : MonoBehaviour {

   
    [SerializeField] private GameObject nachosPrefab;
    private GameObject _nachos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _nachos == null)
                    {
                         _nachos = Instantiate (nachosPrefab) as GameObject;
                        _nachos.transform.position = transform.position;
                        _nachos.transform.rotation =transform.rotation;
                    }

    }
}
