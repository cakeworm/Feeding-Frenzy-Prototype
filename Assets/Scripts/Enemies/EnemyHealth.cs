﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
    public int startingHealth = 3;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 1.0f;              // The speed at which the enemy sinks through the floor when dead.
    //public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    //public AudioClip deathClip;                 // The sound to play when the enemy dies.


    //Animator anim;                              // Reference to the animator.
   //AudioSource enemyAudio;                     // Reference to the audio source.
   // ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
   public BoxCollider boxCollider;
   public CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
   public NCStatePatternEnemy enemy;
    bool isAlive = true;                                // Whether the enemy is alive, acts as a switch for kinematic colliders
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    bool isHyper;                             //Whether the enemy is excited by food, and begins moving excitedly and dangerously

    void Awake ()
    {
        // Setting up the references.
        //anim = GetComponent <Animator> ();
        //enemyAudio = GetComponent <AudioSource> ();
       //hitParticles = GetComponentInChildren <ParticleSystem> ();
        boxCollider = GetComponentInChildren <BoxCollider> ();
        capsuleCollider = GetComponentInChildren <CapsuleCollider>();
        enemy = GetComponent <NCStatePatternEnemy>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update ()
    {
        // If the enemy should be sinking...
        if(isSinking)
        {
            
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            Debug.Log ("I'm sinking");
        }


    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (!isAlive)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play ();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
            
        // Set the position of the particle system to where the hit was sustained.
        //hitParticles.transform.position = hitPoint;

        // And play the particles.
        // hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 2)
        {    
            Debug.Log("health is 2, activate hyper mode");
            NCStatePatternEnemy enemy = GetComponent <NCStatePatternEnemy>();


            enemy.navMeshAgent.speed = 5.0f;
            enemy.isHyper = true;
        



            /* NachoBeastMovement nachoBeastMovement = GetComponent<NachoBeastMovement>();
            NachoBeastMovement_H nachoBeastMovement_H = GetComponent<NachoBeastMovement_H>();
            if (nachoBeastMovement != null)
            {
                nachoBeastMovement.enabled = false;
            }
            if (nachoBeastMovement_H != null)
            {
                nachoBeastMovement_H.enabled = true;
            }*/
        }


        if (currentHealth <= 0)
        {

            


            NCStatePatternEnemy nCStatePatternEnemy = GetComponent<NCStatePatternEnemy>();
            if (nCStatePatternEnemy != null)
            {
                nCStatePatternEnemy.SetAlive(false);
                Debug.Log ("I'm dead");

                Die ();
            }

            NachoBeastMovement_H nachoBeastMovement_H = GetComponent<NachoBeastMovement_H>();
            if (nachoBeastMovement_H != null)
            {
                nachoBeastMovement_H.SetAlive (false);

                Die ();
            }

            GenericEnemyMovement genericEnemyMovement = GetComponent<GenericEnemyMovement>();
            if (genericEnemyMovement != null)
            {
                genericEnemyMovement.SetAlive (false);

                Die ();
            }
          


            // ... the enemy is dead.

        }
    }


    void Die()
    {
        // The enemy is dead.
       
        //enemy.GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

        isAlive = false;
        
        // Turn the collider into a trigger so shots can pass through it.
        if (GetComponent<BoxCollider>() !=null)
        {
            boxCollider.isTrigger = true;       
        }

        else if (GetComponent<CapsuleCollider>() !=null)
        {
            capsuleCollider.isTrigger = true;       
        }

        StartSinking();
        // Tell the animator that the enemy is dead.
        //anim.SetTrigger ("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
       //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();


    }


    public void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        //GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent <Rigidbody> ().isKinematic = true;

        // The enemy should now sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        //ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy (gameObject, 2f);
    }
}

