using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState  
{

   

    void UpdateState (); 
    

    void OnTriggerEnter (Collider other);

    void OnCollisionEnter (Collision collision);


    void ToPatrolState ();   

    void ToChaseState ();

    void ToCircleState ();

  
  

}
