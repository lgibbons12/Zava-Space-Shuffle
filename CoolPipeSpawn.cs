using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolPipeSpawn : MonoBehaviour
{
    
    public int moveSpeed = 7;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }
}
