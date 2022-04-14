using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Monsters" && other.gameObject.tag == "Pizza")
        {
            Destroy(gameObject);
            Debug.Log("it works");
            
        }
    }
}
