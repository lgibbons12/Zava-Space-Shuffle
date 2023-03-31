using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManger : MonoBehaviour
{
    

    [SerializeField] private GameObject deathText;
    
    [SerializeField] private GameObject deathButton;
    

    
    public bool playerDead = false;
    
    public GameObject easyMode;
  

    [SerializeField] private Animator anim;

    GameObject [] deathObjects;
    void Start()
    {
        deathText.SetActive(false);
        deathButton.SetActive(false);
        deathObjects = GameObject.FindGameObjectsWithTag("Death");

        foreach (GameObject death in deathObjects)
        {
            death.SetActive(false);
        }
        
    }
    
    public void Death(Rigidbody2D playerRb)
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        deathText.SetActive(true);
        deathButton.SetActive(true);
        //play a sound
        
        anim.SetTrigger("death");
        playerDead = true;
        PlayerPrefs.SetString("playerDead", "true");
    }

    public void Reset()
    {
        if (SceneManager.GetActiveScene().name == "FirewallScene") 
        {
            easyMode.SetActive(false);
        }
        
        PlayerPrefs.SetString("playerDead", "false");
        playerDead = false;
        if (SceneManager.GetActiveScene().name != "FirewallScene")
        {
            PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
        
        
    }
}
