using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private int dynamiteCount = 3;
    public Text distanceText;
    float currCountdownValue;

    private int level;
    public Text levelText;

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    public Text healthText;

    public Text gameOverText;



    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartCountdown());
        PublicValues.dynamiteCount = dynamiteCount;
        level = PublicValues.level;
        if (level == 0) { PublicValues.level = 1; }

    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = "Dynamite: " + PublicValues.dynamiteCount;
        levelText.text = "Level : " + PublicValues.level;
        timerText.text = "Money : " + PublicValues.money;
        healthText.text = "HEALTH : " + PublicValues.health;
        if (PublicValues.health <= 0)
        {
            ResetValues();
            GameOver();
        }
        else gameOverText.text = "";
    }





    public void GameOver()
    {
        PublicValues.isGameOver = true;
        SceneManager.LoadScene(2);
    }

    public void ResetValues()
    {
        PublicValues.level = 0;
        PublicValues.health = 100;
        PublicValues.dynamiteCount = 3;
        PublicValues.money = 0;
    }
}
