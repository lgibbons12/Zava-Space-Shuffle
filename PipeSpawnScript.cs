using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;

    public float spawnRate;

    private float timer;

    public float heightOffset;

    public int counter = 20;

    public Text timerText;

    [SerializeField] private DeathManger death;
    // Start is called before the first frame update
    void Start()
    {
       spawnPipe(); 
       death = GameObject.FindGameObjectWithTag("Logic").GetComponent<DeathManger>();
       spawnRate = PlayerPrefs.GetInt("pipeSpawnRate");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (counter < 0)
        {
           PlayerPrefs.SetString("survived", "yes"); 
           SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel")); 
        }
        
       
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            
            spawnPipe();
            timer = 0;
            if (!death.playerDead)
            {
                counter --;
            }
            
            timerText.text = "Time Left: " + counter;
        }
    }

    void spawnPipe()
    {
        int spawnY = 4;
        float which = Random.Range(0, 2);
        if (which == 0)
        {
            spawnY = -4;
        }
        
        Instantiate(pipe, new Vector2(transform.position.x, spawnY), transform.rotation);
    }
}
