using UnityEngine;
using System.Collections;

public class NachoBeastAnim : MonoBehaviour {

    public Animator anim;
    public NBStatePatternEnemy enemy;

 
 // this script needs to be relegated to snippet or trashed.

    void Awake()
    {
       anim = GetComponent<Animator>();
       enemy = GetComponent<NBStatePatternEnemy>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        anim.SetTrigger ("Jump Initiated");
        enemy.SetGrounded (false);

       
    }

  



 

}
