using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public string itemId;
    public GameObject objectToFollow;
    public Vector3 spawnerLocationOffset;
    
    public GameObject[] spawnObjects;
    public float spawnRate;
    private Vector3 dropLocation;

    public bool moveTowardsobject;
    public float towardsObjectSpeed = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        dropLocation = objectToFollow.transform.position + spawnerLocationOffset;
        spawnRate = spawnRate / PublicValues.level;
        InvokeRepeating("SpawnObject", 1.0f , spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveTowardsobject)
        {
            Debug.Log("liikutaan kohti pelaajaa");

        }else transform.position = objectToFollow.transform.position;

    }

    void SpawnObject()
    {
        dropLocation = this.transform.position + spawnerLocationOffset;
        int randomIndex = Random.Range(0, spawnObjects.Length -1);
        Instantiate(spawnObjects[randomIndex],dropLocation, spawnObjects[randomIndex].transform.rotation);
    }
}
