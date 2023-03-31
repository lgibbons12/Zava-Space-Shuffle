using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    //do this later!
    //private AudioSource finishSound;

    // Start is called before the first frame update
    void Start()
    {
        //finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //finishSound.Play();
            CompleteLevel();
        }


    }

    private void CompleteLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void EaterEgg()
    {
        SceneManager.LoadScene("PlatLevelFour");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Info Screen");
    }
}
