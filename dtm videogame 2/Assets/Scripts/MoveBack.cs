using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this section of code is called automatically and attached to the 'Monster1' and 'Monster2' prefab
        // it essentially just propels the object to the left horizontally
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
