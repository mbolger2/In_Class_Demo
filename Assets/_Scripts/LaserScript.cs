using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float maximumLength;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is pressing the right mouse
        if (Input.GetButton("Fire2"))
        {
            // We start by defining a ray with origin in this object
            // And the forward direction of htis object as its direction..
            // This isn't necessary, I just did it to visually simplify things
            Ray ray = new Ray(gameObject.transform.position,
                gameObject.transform.forward);

            // Debug drawray will draw a ray. This is only visible in the editor
            // And only visible in the game tab if you have gizmos enabled.
            Debug.DrawRay(ray.origin, ray.direction * maximumLength, Color.red, 1f);

            // If the raycast hits something (using maximumLength as its maximum
            // possible length, and mask as a way to filter through layers that it 
            // can and cannot hit), this function will store the information of the hit
            // int he raycasthit hit varibale
            if (Physics.Raycast(ray, out RaycastHit hit, maximumLength, mask))
            {
                // Write the name of the transform hit
                Debug.Log(hit.transform.name);
            }
        }
    }
}
