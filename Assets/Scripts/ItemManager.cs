using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public GameObject healthUp;
    public GameObject speedUp;
    public GameObject dynamiteUp;
    

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckItem(GameObject itemTag) 
    {
        if (itemTag.gameObject.tag == "Dynamite")
        {
            PublicValues.dynamiteCount += 3;
            Destroy(itemTag.gameObject);
            audioManager.PlayOneLiner();
        }

        if (itemTag.gameObject.tag == "rock")
        {
            PublicValues.health -= 2;
            audioManager.PlayHurtSound();
        }

        if (itemTag.gameObject.tag == "Health")
        {
            PublicValues.health += 20;
            audioManager.PlayOneLiner();
            Destroy(itemTag.gameObject);
        }
        if (itemTag.gameObject.tag == "Speed")
        {
            audioManager.PlayOneLiner();
            Destroy(itemTag.gameObject);
        }
        if (itemTag.gameObject.tag == "Money")
        {
            PublicValues.money += 20;
            audioManager.PlayOneLiner();
            Destroy(itemTag.gameObject);
        }
        if (itemTag.gameObject.tag == "Finish")
        {
            
            SceneManager.LoadScene(1);
        }
    }
}
