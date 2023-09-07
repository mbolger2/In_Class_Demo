using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug tick every second
        //Debug.Log("Tick");

        //Declare vector newPos
        Vector3 newPos = this.gameObject.transform.position;
        newPos.z += speed * Time.deltaTime;
        //Same as newPos.z = newPos.z + speed;

        this.gameObject.transform.position = newPos;
    }
}
