using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRing : MonoBehaviour
{
    [Header("Collision Detection")]
    //The tag that must be on the other objcet of the trigger interactoin for points to be added
    public string scoringTag = "Player";
    [Header("Particle Effect")]
    //The prefab of the particle effect
    public Transform ringExplosion;
    [Header("Faking Destruction")]
    //The mesh of the ring so that we can hide it
    public GameObject ringMesh;
    //The collider of the ring so that we can disable it
    public Collider ringCollider;

    [Header("Audio Source")]
    //The audio source that will play the scoring sound
    public AudioSource ringSoundPlayer;
    //The sound that will be played when points are scored with this ring
    public AudioClip scoreSound;

    private void Start()
    {
        //We tell the sudio source what clip it will play
        ringSoundPlayer.clip = scoreSound;
    }

    /*
     * This callback function will be called when a collider on the same
     * object as this script enters a trigger (or if there is a trigger 
     * on this object colliding with an object
     */
    private void OnTriggerEnter(Collider other)
    {
        //We display the name of the object we collided with
        Debug.Log("Collided with object " + other.gameObject.name);

        //If the other object has a scoring tag of player
        if (other.CompareTag(scoringTag))
        {
            //Add 10 points to score manager, which will display
            ScoreManager.Instance.AddScore(10);

            //Spawn a ring explosion at the position of this object, with its same rotation
            Instantiate(ringExplosion, this.transform.position, this.transform.rotation, this.transform);

            //We destroy this object
            //Destroy(this.gameObject);

            //Instead of destroying this object we're going to hide the ring
            //and the collider so that the player thinks it's destroyed
            ringMesh.SetActive(false);
            ringCollider.enabled = false;

            //Tell the player to play the sound assigned to its "clip" variable
            ringSoundPlayer.Play();

        }
    }
}
