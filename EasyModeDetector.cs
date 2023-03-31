using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EasyModeDetector : MonoBehaviour
{
    

   

    public GameObject easyMode;

    public DeathManger death;

    

    // Start is called before the first frame update
    void Start()
    {
        
        easyMode.SetActive(false);

        death = GameObject.FindGameObjectWithTag("Logic").GetComponent<DeathManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("pipeDeath") > 3 && PlayerPrefs.GetString("easyModePicked") != "true") {
            showEasyOption();
        }
    }

    public void showEasyOption()
    {
        easyMode.SetActive(true);
    }
    public void makeEasy()
    {
        PlayerPrefs.SetInt("pipeSpawnRate", 3);
        PlayerPrefs.SetString("easyModePicked", "true");
        easyMode.SetActive(false);
        death.Reset();
        
    }
    
}
