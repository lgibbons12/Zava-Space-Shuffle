using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private DeathManger death;


    
    
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            anim.SetTrigger("death");
            death.Death(rb);

            PlayerPrefs.SetInt("pipeDeath", PlayerPrefs.GetInt("pipeDeath") + 1);
            
            

            

        }
    }
}
