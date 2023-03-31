using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    
    [SerializeField] private float deadZone = -50;

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "PlatLevelFour")
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        else
        {
            
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }
        

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
