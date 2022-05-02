using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this section of code is called automatically and attached to the 'Pizza' prefab
        // it essentially just propels the object to the right horizontally
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
