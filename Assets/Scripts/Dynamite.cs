using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;
    public GameObject explosionPrefab;
    public float throwForce = 1000;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bomb == enabled)
        {
            Invoke("Detonate", 5);
        }
    }

    void Detonate()
    {
       
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
        
        
        Destroy(gameObject);
        

    }

}
