//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacleSpawner : MonoBehaviour
{
    public GameObject objectToFollow;
    public GameObject[] Obstacles;
    public GameObject objectToSpawnFrom;
    private Vector3 rockDropLocation;
    public float rockDropHeight = 10.0f;
    public float timer = 4.0f;
    private float nextLevelLocation = 500;
    private float spawnerPositionZ;
    private int level = 1;

    public int randomMinX;
    public float randomMaxX;

    public float dropTime = 0.2f;
    public float spawnerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropRock", timer, dropTime);
        PublicValues.level = level;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnerPositionZ = objectToFollow.transform.position.z + 100;
        transform.position = objectToFollow.transform.position + new Vector3(0, 0, 50);
        transform.Translate(Vector3.forward * PublicValues.playerSpeed * Time.deltaTime);
        
        if (spawnerPositionZ >= nextLevelLocation)
        {
            level = level + 1;
            PublicValues.level = level;

            nextLevelLocation = nextLevelLocation + 500;
            LevelManager(level);
            
        }
        

    }

    private void LevelManager(int level)
    {
        CancelInvoke(); //TODO droprate too fast already on level 4
        dropTime -= 0.1f;
        if (dropTime < 0.1f) { dropTime = 0.1f; }
        InvokeRepeating("DropRock", timer, dropTime);
       


    }

    private void DropRock()
    {
        int index = Obstacles.Length - 1;
        int randomRock = Random.Range(0, index);
        float randomPos = Random.Range(randomMinX, randomMaxX);

        
        rockDropLocation = new Vector3(objectToSpawnFrom.transform.position.x  + randomPos, objectToSpawnFrom.transform.position.y + rockDropHeight, objectToSpawnFrom.transform.position.z);
        Instantiate(Obstacles[randomRock], rockDropLocation, Obstacles[0].transform.rotation);

        

    }



}