using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider : MonoBehaviour
{
    [SerializeField] private DeathManger death;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        death = GameObject.FindGameObjectWithTag("Logic").GetComponent<DeathManger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            death.Death(rb);
        }
        else if (collision.gameObject.CompareTag("Teleporter"))
        {
            PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("FirewallScene");
        }
        else if (collision.gameObject.CompareTag("EasterEgg"))
        {
            SceneManager.LoadScene("Easter Egg");
        }
        
    }
    
}
