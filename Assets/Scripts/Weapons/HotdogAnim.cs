using UnityEngine;
using System.Collections;

public class HotdogAnim : MonoBehaviour {

    public Animator anim;
    bool firePressed;

    void Awake()
    {
       anim = GetComponent<Animator>();


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Swing ();
        }
    }

    void Swing ()
    {
        firePressed = true;

        anim.SetTrigger ("Fire Pressed");

       
    }

}
