using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip jump;
    public AudioClip throwing;
    public AudioClip[] hurtSounds;
    public AudioClip[] oneLiners;
    public AudioClip ambience;
    public GameObject player;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = player.gameObject.GetComponent<AudioSource>();
    }

   
   
    public void PlayHurtSound()
    {
        int index = Random.Range(0, hurtSounds.Length);
        playerAudio.PlayOneShot(hurtSounds[index],1.0f);
    }

    public void PlayOneLiner()
    {
        int index = Random.Range(0, oneLiners.Length);
        playerAudio.PlayOneShot(oneLiners[index], 1.0f);
    }

    public void PlayJump()
    {
        playerAudio.PlayOneShot(jump, 1.0f);
    }

    public void PlayThrow()
    {
        playerAudio.PlayOneShot(throwing, 1.0f);
    }
    

}
