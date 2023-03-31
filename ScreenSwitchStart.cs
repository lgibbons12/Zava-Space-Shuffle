using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenSwitchStart : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("easy", "no");
        PlayerPrefs.SetInt("pipeDeath", 0);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetString("easyModePicked", "false");
        
        if (SceneManager.GetActiveScene().name != "Start")
        {
            PlayerPrefs.SetInt("pipeSpawnRate", 2);
            PlayerPrefs.SetInt("speedrun", 0);
        }
        
        PlayerPrefs.SetFloat("timer", 0f);
        PlayerPrefs.SetString("playerDead", "false");
        PlayerPrefs.SetString("currentLevel", "none");
    }
    public void SwitchScreen()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            SceneManager.LoadScene("PlatLevelZero");
        }
        else{
            SceneManager.LoadScene("Start");
        PlayerPrefs.SetString("survived", "no");
        }
        
        
    }
    public void SwitchScreenEasy()
    {
        SceneManager.LoadScene("Start");
        PlayerPrefs.SetString("survived", "no");
        PlayerPrefs.SetInt("pipeSpawnRate", 1);
    }
    public void SwitchScreenSpeedrun()
    {
        SceneManager.LoadScene("Start");
        PlayerPrefs.SetInt("speedrun", 1);
        
        
    }

}
