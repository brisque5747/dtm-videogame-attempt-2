using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    // Initalizing character speed and control
    private float speed = 10.0f;
    public float horizontalInput;
    private float xRange = 100f;
    private Animator playerAnim;
    private Rigidbody2D playerRb;
    private float jumpForce = 10;
    private float gravityModifier;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Moves player horizontally based on player input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerAnim.SetTrigger("Run_trig");
        }
        else if(horizontalInput == 0)
        {
            //playerAnim.ResetTrigger("Run_trig");
            playerAnim.Rebind();
            playerAnim.SetTrigger("Idle_trig");
        // Make Player jump when spacebar pressed
        if(Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow)))
            {
                Debug.Log("In jump");
                playerAnim.SetTrigger("Jump_trig");
                playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
