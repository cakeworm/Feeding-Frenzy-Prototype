using UnityEngine;
using System.Collections;

public class HotdogAnim : MonoBehaviour {

    public Animator anim;
    public CapsuleCollider activeDog;


    void Awake()
    {
       anim = GetComponent<Animator>();
       activeDog = GetComponentInChildren<CapsuleCollider> ();


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
        //bool firePressed;

        //firePressed = true;

        anim.SetTrigger ("Fire Pressed");       
    }



    void ActivateDog()
    {
        activeDog.isTrigger = false;
    }

    void InactivateDog()
    {
        activeDog.isTrigger = true;
    }

}
