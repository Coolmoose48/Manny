using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public GameObject player;
    private Rigidbody playerRb;
    public GameObject artillery;
    private Vector3 artilleryLocation;
    private GameObject clone;
    private AudioManager audioManager;
    private ItemManager itemManager;
       
    
    public bool moving = false;
    public float speed = 500.0f;
    public float delayTime = 2.0f;
    public float limitXneg = 10.0f;
    public float limitXPos = 10.0f;
    public float jumpSpeed = 5f;
    public float jumpForce;
    private Rigidbody _Rb;
    private bool isGrounded = true;
    public float gravityModifier;
    public Animator playerAnim;
    
    Quaternion targetRotation;

    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    

    // Start is called before the first frame update
    void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        
        PublicValues.playerSpeed = speed;
        playerRb = player.GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        itemManager = GameObject.FindWithTag("ItemManager").GetComponent<ItemManager>();
        if(PublicValues.level == 1) { PublicValues.health = 100; }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
    }


    void PlayerMovement()
    {

        playerAnim.SetFloat("vertical", Input.GetAxis("Vertical")); // replace 1.0f when you want to control forward momentum
        playerAnim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
       
        float turnInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical"); //replace 1.0f when you want to control forward momentum

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PublicValues.dynamiteCount > 0)
            {
                playerAnim.SetTrigger("throw");
                Invoke("Throw", 0.5f);
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.SetTrigger("attack");
        }

        if (forwardInput > 0.1)
        {

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }
        if (forwardInput <-0.1)
        {

            transform.Translate(Vector3.back * Time.deltaTime * speed/4 * -forwardInput);
        }
        if (turnInput != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed/2 * turnInput);
            //targetRotation *= Quaternion.AngleAxis(speed * 3 * turnInput * Time.deltaTime, Vector3.up);
            //transform.rotation = targetRotation;
        }

        if(Input.GetAxis("Jump") > 0.7f && isGrounded)
            {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetBool("jump", true);
            isGrounded = false;
            audioManager.PlayJump();
        
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        playerAnim.SetBool("jump", false);
        isGrounded = true;
        GameObject part = collision.gameObject;
        
       

    }
    private void OnTriggerEnter(Collider other)
    {
        itemManager.CheckItem(other.gameObject);
                   
       


    }

    private void Throw()
    {
            audioManager.PlayThrow();
            artilleryLocation = player.transform.position + new Vector3(0.5f, 2, 1);
            Instantiate(artillery, artilleryLocation, player.transform.rotation);
            PublicValues.dynamiteCount -= 1;
              
    }

    
          
}

