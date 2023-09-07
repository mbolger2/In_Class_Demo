using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    //The three game objects with asteroids that we will be moving
    public Transform firstPiece;
    public Transform secondPiece;
    public Transform thirdPiece;
    //This piece is currently at the front
    public Transform currentFrontPiece;

    //The time between each piece movement
    public float switchTime = 0;
    //The resulting Z-axis distance between a new front piece and the old front piece
    public float switchDistance = 0;
    //A timer to keep track of time between switches
    private float timePassed = 0;

    // Update is called once per frame
    void Update()
    {
        /*
         The delta time is added to the timePasses variable to keep track of 
         time passed since a switch
        */
        timePassed += Time.deltaTime;

        //If the amount of time required for a switch has passed...
        if (timePassed > switchTime)
        {
            if (firstPiece.position.z < secondPiece.position.z)
            {
                if (firstPiece.position.z < thirdPiece.position.z)
                {
                    //The first piece is the one at the back
                    firstPiece.transform.position = 
                        currentFrontPiece.position +
                        Vector3.forward * switchDistance;

                    currentFrontPiece = firstPiece;
                }
                else
                {
                    //The third piece is the one at the back
                    secondPiece.transform.position =
                        currentFrontPiece.position +
                        Vector3.forward * switchDistance;

                    currentFrontPiece = secondPiece;
                }
            }
            else
            {
                if (secondPiece.position.z < thirdPiece.position.z) 
                {
                    //The second piece is the one at the back
                    secondPiece.transform.position =
                        currentFrontPiece.position +
                        Vector3.forward * switchDistance;

                    currentFrontPiece = secondPiece;
                }
                else 
                {
                    //The third piece is the one at the back
                    thirdPiece.transform.position =
                        currentFrontPiece.position +
                        Vector3.forward * switchDistance;

                    currentFrontPiece = thirdPiece;
                }
            }
            timePassed = 0;
        }
    }
}
