using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerMovement : MonoBehaviour
{
    // The rigidbody that controls the physics fo the first frame update
    public Rigidbody2D reggiebody;

    // The force fo the jump
    public float jumpForce;

    // The movement speed of this character
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        // Find a rigidbody2d on this object and assign it to reggiebody
        reggiebody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // On the down press of space the player jumps
        if (Input.GetButtonDown("Jump"))
        {
            // Add force to the reggiebody upwards
            reggiebody.AddForce(Vector2.up * jumpForce);
        }

        //
        float xMov = Input.GetAxis("Horizontal");


        reggiebody.AddForce(Vector2.right * xMov * speed * Time.deltaTime);
        
    }
}
