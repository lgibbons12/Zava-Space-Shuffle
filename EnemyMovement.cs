using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private int moveCounter = 0;

    [SerializeField] private int moveDuration = 100;
    [SerializeField] private float moveSpeed = 7;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (moveCounter == 0)
        {
            rb.velocity = new Vector2(0f, moveSpeed);
        }
        else if (moveCounter == moveDuration)
        {
           rb.velocity = new Vector2(0f, moveSpeed * -1);
        }
        //change to time.deltatime
        moveCounter += 1;
        if (moveCounter > moveDuration*2)
        {
            moveCounter = 0;
        }
    }
}
