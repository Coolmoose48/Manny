using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteBarrel : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        GameObject player = GameObject.Find("Player");
        if (other == player)
        {
            PublicValues.dynamiteCount += 3;
            Destroy(gameObject);
        }

    }
}
