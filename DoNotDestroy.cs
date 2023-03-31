using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private static DoNotDestroy objectInstance;
    void Awake(){
        DontDestroyOnLoad (this);
         
        if (objectInstance == null) {
            objectInstance = this;
        } 
        else {
            Destroy(this.gameObject);
        }
 }
}
