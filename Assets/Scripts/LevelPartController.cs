using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartController : MonoBehaviour
{
    private GameObject player;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Manny");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > (transform.position.z + 55))
        {
            //PublicValues.LevelPartCount = PublicValues.LevelPartCount - 1;
            //Destroy(gameObject);
            

        }
                
    }   
}
