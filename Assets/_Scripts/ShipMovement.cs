using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //The maximum and minimum position of the ship in each axis
    public Vector2 movementBoundariesMin;
    public Vector2 movementBoundariesMax;

    //The speed of the player in X and Y
    //Tooltip lets you hover over in the ditor and get the string
    [Tooltip("The speed of the player in X and Y")]
    public float speed;

    [Header("Animations")]
    // The animatore that controls the ship animations
    public Animator animator;
    // The parameter that controls the x
    public string xAnimParameter;
    public string yAnimParameter;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        //A way to collapse the code in the editor for organizaiton
        #region Example
        /*
        //Debug tick every second
        //Debug.Log("Tick");

        //Declare vector newPos
        Vector3 newPos = this.gameObject.transform.position;
        newPos.z += speed * Time.deltaTime;
        //Same as newPos.z = newPos.z + speed;

        this.gameObject.transform.position = newPos;
        */
        #endregion

        //We declare the variables keeping track of player input
        float xMov, yMov;

        //We store the player input
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        animator.SetFloat(xAnimParameter, xMov);
        animator.SetFloat(yAnimParameter, yMov);

        //We declare a variable with the motion the player is making
        //                              v Horizontal Direction
        //                                  v Vertical Direction
        //                                              v Speed of both directions
        Vector3 motion = new Vector3 (xMov, yMov, 0) * speed * Time.deltaTime;

        //Temporary variable to check for the boundaries
        Vector3 finalPos = transform.position + motion;

        //Fix movement in x
        if (finalPos.x > movementBoundariesMax.x)
        {
            finalPos.x = movementBoundariesMax.x;
        }
        if (finalPos.x < movementBoundariesMin.x)
        {
            finalPos.x = movementBoundariesMin.x;
        }

        //Fix movement in y
        if (finalPos.y > movementBoundariesMax.y)
        {
            finalPos.y = movementBoundariesMax.y;
        }
        if (finalPos.y < movementBoundariesMin.y)
        {
            finalPos.y = movementBoundariesMin.y;
        }

        //Set the correct finalPos
        transform.position = finalPos;

        /*
         We change the postion by adding the motion
        trans
         */
        //transform.position = transform.position + motion;
    }
}
