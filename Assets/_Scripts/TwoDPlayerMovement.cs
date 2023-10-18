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

    // How far the player must be from the floor to jump
    public float minFloorDistance;

    //
    public Vector3 raycastOriginOffset;

    // 
    public float distanceBetweenRays;


    [SerializeField]
    private bool physicsMovement;

    [SerializeField]
    bool raw;


    // Start is called before the first frame update
    void Start()
    {
        // Find a rigidbody2d on this object and assign it to reggiebody
        reggiebody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (physicsMovement)
        {
            PhysicsMovement();
        }
        else
        {
            KinematicMovement();
        }
    }

    void KinematicMovement()
    {

    }

    void PhysicsMovement()
    {
        // 
        // Ray2D floorDetection = new Ray2D(this.transform.position, -Vector2.up);
        Debug.DrawRay(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance, Color.red);

        bool middleRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance);
        bool leftRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset - Vector3.right * distanceBetweenRays, -Vector2.up, minFloorDistance);
        bool rightRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset + Vector3.right, -Vector2.up, minFloorDistance);

        // On the down press of space the player jumps
        if (Input.GetButtonDown("Jump")
            // We can cast the position to a v2 for this operation, since the funcion
            //
            //&& Physics2D.Raycast(this.transform.position + raycastOriginOffset, 
            //-Vector2.up, minFloorDistance))
            && leftRay || rightRay)
        {
            // Add force to the reggiebody upwards
            reggiebody.AddForce(Vector2.up * jumpForce);
        }

        // Get the input of the player (represented as (-1,1))
        //float xMov = Input.GetAxis("Horizontal");     // Has trailing speed after button let go
        float xMov;    // Stops as soon as not pressed

        if (raw)
        {
            // We can add force to the right based on that, if we want an "icey" movement
            // reggiebody.AddForce(Vector2.right * xMov * speed * Time.deltaTime);
            xMov = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            // Or we can chane the velocity directly. Notice we're not changing the
            // velocity in y
            //reggiebody.velocity = new Vector2 (xMov * speed, reggiebody.velocity.y);
            xMov = Input.GetAxisRaw("Horizontal");

        }

    }
}
