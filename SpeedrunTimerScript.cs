using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedrunTimerScript : MonoBehaviour
{
    public GameObject speedrunTimer;

    
    public Text timerText;

   
    void Start()
    {
        time = PlayerPrefs.GetFloat("timer");
        
        
        if (PlayerPrefs.GetInt("speedrun") == 1)
        {
            speedrunTimer.SetActive(true);
        }
        PlayerPrefs.SetString("playAgain", "false");

        
    }
    public float time = 0f;
     
    

    
    void Update()
    {
        
        if (PlayerPrefs.GetString("playAgain") == "true")
        {
            time = 0;
            PlayerPrefs.SetFloat("timer", 0f);
            
        }
        else
        {
            
            if (SceneManager.GetActiveScene().name != "End")
            {
                
                time += Time.deltaTime;
                PlayerPrefs.SetFloat("timer", time);
            }
            
            
            DisplayTime(PlayerPrefs.GetFloat("timer"));
            
        }

        
        

    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (SceneManager.GetActiveScene().name != "End")
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "Final Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            PlayerPrefs.SetFloat("bestTime", timeToDisplay);
            PlayerPrefs.Save();
        }
        
    }
}
