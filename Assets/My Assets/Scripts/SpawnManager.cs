using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Set the array size and drag the prefabs here.
    public GameObject[] groundObjects;

    // Set the same array size and define the chances for each prefab.
    public int[] chances;

    public float spawnRangeX;
    public float spawnPosZ;
    public float spawnPosY;

    public float startDelay;
    public float spawnInterval;

    //void RandomSpawn(Vector3 pos, Quaternion rot)
    void RandomSpawn()
    {
        // Draw a random int in 0..99 range.
        int rand = Random.Range(0, 100);
        int rangeStart = 0;

        for (int n = 0; n < groundObjects.Length; n++)
        {
            // Calculate this object's chance range.
            int rangeEnd = rangeStart + chances[n];

            if (rand >= rangeStart && rand < rangeEnd)
            {
                // If random number inside the range,
                // create the corresponding prefab.

                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnPosY, spawnPosY), spawnPosZ);

                Instantiate(groundObjects[n], spawnPos, groundObjects[n].transform.rotation);
            }

            // Next range right after the current one.
            rangeStart = rangeEnd;
        }
    }

    // Example: create 10 random sections at Start; each section has length 5, and
    // the first one will be created at this object's position (assuming this script
    // is attached to an empty object).
    void Start()
    {
        // Start at this object's position.
        //Vector3 position = transform.position;

        // Keep this object's orientation.
        //Quaternion rotation = transform.rotation;

        //for (int n = 0; n < 10; n++)
        //{
        //    RandomSpawn(position, rotation);

        //    // Advance position 5 units ahead.
        //    position += 5 * transform.forward;
        //}

        InvokeRepeating("RandomSpawn", 1, 2);
    }

    //void SpawnRandomSpaceObjects()
    //{
    //    int objectIndex = Random.Range(0, spaceObjects.Length);
    //    Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

    //    Instantiate(spaceObjects[objectIndex], spawnPos, spaceObjects[objectIndex].transform.rotation);
    //}
}
