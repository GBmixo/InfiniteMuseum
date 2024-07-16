using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Camera cam;

    //public bool shouldMove = false;
    public Vector2 inputDir;
    public bool isGrounded = true;
    bool isSprinting = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    public void TriggerSprint()
    {
        if(!isSprinting)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void ProcessMovement()
    {
        RaycastHit hit;
        //Vector3 p1 = transform.position + controller.center;
        //Multiplies the direction of the move input by the direction of the camera's Y-axis.
        float targetDir = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        bool raycastIsGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2 + 0.2f, 6);

        
        if(!isSprinting)
        {
            currentSpeed = moveSpeed;
        }
        else
        {
            currentSpeed = sprintSpeed;
        }

        if(isGrounded)
        {
            //Debug.Log("I think I'm grounded");
            isGrounded = true;
            //velocityY = 0.05f;
            if (inputDir.magnitude > 0.1f)
            {
                //Debug.Log(targetDir);
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDir, ref turnSmoothVelocity, turnTime);
            }
        }
        else
        {
            //Debug.Log("I think I'm NOT grounded");
            isGrounded = false;
            velocityY += -gravity * Time.deltaTime;
        }

        Vector3 moveDir = Quaternion.Euler(0f, targetDir, 0f) * Vector3.forward;
        Vector3 velocity = moveDir * inputDir.magnitude * currentSpeed + Vector3.up * velocityY;
        //Debug.Log($"moveDir: {moveDir}, velocity: {velocity}");
        controller.Move(velocity * Time.deltaTime);
        Debug.DrawRay(transform.position, controller.height * Vector3.down, Color.red);
    }

    
}
