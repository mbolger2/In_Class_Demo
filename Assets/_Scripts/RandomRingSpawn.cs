using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRingSpawn : MonoBehaviour
{
    //the prefab with the ring will be instantiated
    public Transform ringPrefab;

    //Defining an array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[6];
    //the seconds between the instantiation of each ring
    public float spawnRate = 1.0f;
    //a counter used to keep track 
    private float spawnCounter = 0.0f;

    private void Start()
    {
        spawnCounter += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //The delta time is added to the counter to keep track fo time
        spawnCounter += Time.deltaTime;

        //If the counter has surpassed the rate, we're ready to spawn something
        if (spawnCounter > spawnRate)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            //Spawn something
            Debug.Log("Spawning ring at " + spawnPoints[randomIndex].name);

            //Spawn the ring prefab at the position of the randomly selected
            //spawnpoint, with teh rotation of said spawn point
            Instantiate(ringPrefab, spawnPoints[randomIndex].transform.position, spawnPoints[randomIndex].transform.rotation);

            //The counter is reset
            spawnCounter = 0.0f;
        }
    }
}
