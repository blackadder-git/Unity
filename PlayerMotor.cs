using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    // these values show up in the editor UI where they can be modified
    public float speed = 3f;
    public float gravity = -9.8f;
    public float jump = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {
        // get this for each frame
        isGrounded = controller.isGrounded;
    }

    // get inputs from InputManager script and assign them to the character controller
    public void ProcessMove(Vector2 input)
    {
        /* map keys to future action
            1. Create new action map
            2. Create new action
            3. Selet new action and change 
               Action Type = Value
               Control Type = Vector 2
            4. Right click new action and choose Add Up\Down\Left\Right Composite
            5. To add input, choose Up, Down, Left, Right and ...
               begin to type in the Path Dropdown e.g. W to find and select the W [Keyboard] or S to find and select S [Keyboard]
               If the drop down does not work, select the [T] to switch from text mode to graphical         
         */

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y; // convert verticle y movement to forward/backward
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // apply constant downward force to player
        // detaTime explained https://www.youtube.com/watch?v=8pYq15Lh0x4 = elapsed time (seconds) since last frame was run
        playerVelocity.y += gravity * Time.deltaTime;
        
        if (isGrounded && playerVelocity.y < 0)
        {
            // keep downward force reasonable
            playerVelocity.y = -2f;
        }
        
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // control player jump
    public void Jump()
    {
        if (isGrounded) 
        {
            // calculate player jump
            playerVelocity.y = Mathf.Sqrt(jump * -3.0f * gravity);
        }
    }
}