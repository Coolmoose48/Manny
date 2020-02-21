using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text statsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           if(PublicValues.isGameOver)
        {
            ShowGameStats();
           
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void ShowGameStats()
    {
        
        
    }

    public void StartTheGame()
    {
        PublicValues.level = 0;
        PublicValues.health = 100;
        PublicValues.money = 0;
        PublicValues.dynamiteCount = 3;
        PublicValues.isGameOver = false;
        SceneManager.LoadScene(1);
    }
    private void OnMouseDown()
    {
        StartTheGame();
    }

} 

