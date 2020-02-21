using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Slider slider;
    
    private Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 0;
    float enemyHealth;
    float maxHealth = 100;
    Rigidbody rb;
    
   
    




    void Start()
    {
        Player = GameObject.Find("Manny").transform;
        enemyHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        
        
       
       

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                Attack();
            }

        }
    }

    void Attack()
    {
        

        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.Find("Manny").name)
        {
            
            PublicValues.health -= 1;
        }
    }

    public void GetDamage(int damage)
    {

        rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        
        float sliderDamage = CalculateDamage(damage);
        if (slider.value >= 0)
        {
            slider.value += sliderDamage;
        }

        if(slider.value >= 1)
        { Destroy(this.gameObject); }
    }

    float CalculateDamage(float damage)
    {

        float WeaponDamage = damage;
        float returnDamage = 0.1f;
        return returnDamage;
    }
}