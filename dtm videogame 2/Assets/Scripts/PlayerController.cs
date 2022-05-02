using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    // Initalizing character variables
    private float speed = 10.0f;
    public float horizontalInput;
    private float xRange = 100f;
    private Animator playerAnim;
    private Rigidbody2D playerRb;
    private float jumpForce = 10;
    private float gravityModifier;
    public float verticalInput;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // this section of code is called when the character goes outside of the xrange (outside of the camera zone)
        // it keeps them at the range they are trying to go outisde of, to prevent them from falling off the map
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // this section of code is called when the player starts moving left or right on the platforms (running)
        // it TRIGGERS an animation to run that looks like someone running.
        // if the character stops running the code detects this and stops the animation and switches to an idle animation
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerAnim.SetTrigger("Run_trig");
        }
        else if (horizontalInput == 0)
        {
            playerAnim.ResetTrigger("Run_trig");
            playerAnim.Rebind();
            playerAnim.SetTrigger("Idle_trig");
            
        }

        // this section of code is called when player presses the spacebar key OR presses the spacebar key & rightarrow
        // it triggers an animation ti run that looks like someone jumping
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow)))
        {
                Debug.Log("In jump");
                playerAnim.SetTrigger("Jump_trig");
                playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        // this section of code is called when player falls off of the map and is BELOW the value that triggers the variable
        // it triggers a message on the bottom left of the screen that declares the game over
        if (transform.position.y < -5)
        {
            Debug.Log("Game Over, please press play button to run again");
            Application.Quit();
        }

        // this section of code is called when the player presses the S key on their keyboard
        // it triggers a prefab to form above the player to shoot out at the monsters to 'neutralise them'
        if (Input.GetKeyDown(KeyCode.S))
        {
            float shootingY = transform.position.y + 2f;
            Vector2 shootingPosition = new Vector2(transform.position.x, shootingY);
            Instantiate(projectilePrefab, shootingPosition, projectilePrefab.transform.rotation);
        }
    }
}
