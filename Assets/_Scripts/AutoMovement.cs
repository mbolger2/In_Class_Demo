using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    //The speed of this object
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //Make a new temporary vectore
        Vector3 newPos = transform.position;

        //The new position is equal to
        //(Original Pos) + (Direction * Speed * DeltaTime (to avoid frame dependency!!)
        newPos += transform.forward * speed * Time.deltaTime;


        transform.position = newPos;
    }
}
