using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Speed of proj
    public float speed;
    //Lifetime of proj
    public float lifetime;
    //The counter that keeps track of how long this proj has been around for
    private float lifetimeCounter = 0;
    
    // Update is called once per frame
    void Update()
    {
        //We use the functoin to keep update clean
        MoveProjectile();

        //The deltatime is added to the counter
        lifetimeCounter += Time.deltaTime;

        //If the counter has exceeded the lifetime
        if (lifetimeCounter > lifetime)
        {
            Destroy(this);
        }

    }

    void MoveProjectile()
    {
        //We define a new position vector to easily modify its vlaues
        Vector3 newPos = transform.position;

        //We set the new position to be "speed" units along the forward direction
        newPos += transform.forward * speed * Time.deltaTime;

        //Set the new position of the object
        transform.position = newPos;
    }
}
