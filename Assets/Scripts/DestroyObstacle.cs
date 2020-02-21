using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{

    private GameObject destroyRelationTo;
    private float destroyDistanceZ = 10.0f;
    float destroyLocationZ;
    // Start is called before the first frame update
    void Start()
    {
        destroyRelationTo = GameObject.Find("Manny");
        
    }
    // Update is called once per frame
    void Update()
    {


            if (transform.position.z < destroyRelationTo.transform.position.z - destroyDistanceZ)
                { Destroy(gameObject); }
      
    }
}
