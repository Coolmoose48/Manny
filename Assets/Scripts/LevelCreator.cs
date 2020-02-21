using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levelparts;
    public GameObject levelStart;
    public GameObject levelEnd;
    public GameObject bossLevel;
    private float nextLevelPositionZ = 50;
    private GameObject player;
    private List<GameObject> levelPieces = new List<GameObject>();
    public int setMaxLevelSize = 100;



    // Start is called before the first frame update
    void Start()
    {
        
        PublicValues.level++;
        if (PublicValues.level == 1)
        { PublicValues.health = 100; }
        PublicValues.levelPartMax = setMaxLevelSize;
        CreateLevel(setMaxLevelSize);
        Instantiate(levelStart, new Vector3(0, 0, 0), levelStart.transform.rotation);
       

    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    public void AddPart() // Add new level part at the end of the line
    {



        Debug.Log(PublicValues.LevelPartCount + " ja max: " + PublicValues.levelPartMax);

        if(PublicValues.LevelPartCount < PublicValues.levelPartMax) 
        {
            
            int randomLevel = Random.Range(0, levelparts.Count);
            Instantiate(levelparts[randomLevel], new Vector3(0, 0, nextLevelPositionZ), levelparts[randomLevel].transform.rotation);
            nextLevelPositionZ += 50;
            PublicValues.LevelPartCount = PublicValues.LevelPartCount + 1;
           
        }
    
    }
    public void CreateLevel(int maxLevelSize)
    {
        for(int a=0; a<maxLevelSize; a++)
        {
            int randomLevel = Random.Range(0, levelparts.Count);
            levelPieces.Add(Instantiate(levelparts[randomLevel], new Vector3(0, 0, nextLevelPositionZ), levelparts[randomLevel].transform.rotation) as GameObject);
            
            levelPieces[a].name = "" + a;

            
            nextLevelPositionZ += 50;
            PublicValues.LevelPartCount = PublicValues.LevelPartCount + 1;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       
    }



}

