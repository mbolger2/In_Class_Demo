using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //The key the player needs to press for shooting
    //public KeyCode shootKey;
    public string shootButton;

    //The projectile that we'll be shooting
    public Transform projectile;

    //How many seconds pass between each shot
    public float fireRate;

    //An internal counter used to keep trcak of time passed between shots
    float fireCooldown = 0;
    
    // Update is called once per frame
    void Update()
    {
        //Add the delta time to the fire cooldown
        fireCooldown += Time.deltaTime;

        //If the cooldown has reached the rate
        if ( fireCooldown >= fireRate
            && PauseMenu.isPaused == false
            && Input.GetButtonDown(shootButton))
        {
            //Shoot
            //Debug.Log("Pew");
            Shoot();

            //Reset the cooldown
            fireCooldown = 0;
        }
    }

    void Shoot()
    {
        //The projectile is spawned at the position of this transform witht he default rotation
        //Instantiate(projectile, transform.position, Quaternion.identity);
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
