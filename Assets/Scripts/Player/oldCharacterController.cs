using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class oldCharacterController : MonoBehaviour
{
    public InputManager inputManager;
    private CharacterController controller;
    private Camera cam;

    public float moveSpeed = 5f; //player speed when not sprinting.
    public float sprintSpeed = 9f; //player speed when sprinting.
    public float jumpSpeed = 15f;

    public float gravity = 9.81f; //gravity variable, postive # is downward force.

    public float turnTime = 0.1f; //time it takes for player to rotate to the movement direction
    float turnSmoothVelocity;

    private float velocityY;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }

    void CharacterMove()
    {
        Vector2 inputDir = inputManager.GetMovement(); //A normalized 2D vector of the movement input.
        float targetDir = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y; //Multiplies the direction of the move input by the direction of the camera's Y-axis.
        float isSprint = inputManager.IsSprint(); //Sprint input, is a button input but outputs as a float. Unity sucks.
        float isJump = inputManager.isJump(); //Jump input, again a dumb float.

        //Check if player is spirnting, set 'currentSpeed' to determined floats.
        if(isSprint == 1)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        if (controller.isGrounded)
        {
            velocityY = 0.05f;
            if(inputDir.magnitude > 0.1f)
            {
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDir, ref turnSmoothVelocity, turnTime);
            }

            if(isJump == 1)
            {
                velocityY = jumpSpeed;
            }
            //Debug.Log("Grounded");
        }
        else
        {
            velocityY += -gravity * Time.deltaTime;
        }

        Vector3 moveDir = Quaternion.Euler(0f, targetDir, 0f) * Vector3.forward;
        Vector3 velocity = moveDir * inputDir.magnitude * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
    }
}
*/
