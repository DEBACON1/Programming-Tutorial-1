using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{

    int score;
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
            
            Debug.Log(score);
        }
        
    }

}

