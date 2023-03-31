using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestTime : MonoBehaviour
{
    public Text bestTime;
    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("bestTime");
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        bestTime.text = "World Record: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
}
