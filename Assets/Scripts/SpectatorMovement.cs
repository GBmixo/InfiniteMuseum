using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;
    public GameObject cameraObject;

    Vector3 movementVector;
    float verticalMovementVector;
    Rigidbody rb;
    bool isMoving = false;
    bool isVerticalMoving = false;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void TriggerMovement(Vector2 ctxVector)
    {
        movementVector.x = ctxVector.x;
        movementVector.z = ctxVector.y;
        isMoving = true;
    }
    public void CancelMovement()
    {
        movementVector = new Vector3(0,0,0);
        isMoving = false;
    }

    public void TriggerVerticalMovement(float ctxValue)
    {
        verticalMovementVector = ctxValue;
        isVerticalMoving = true;
    }
    public void CancelVerticalMovement()
    {
        isVerticalMoving = false;
    }

    private void FixedUpdate()
    {
        
        if(isMoving == true)
        {
            float camRotation = cameraObject.transform.rotation.eulerAngles.y;
            //movementVector = Quaternion.Euler(cameraObject.transform.rotation.x, 0, cameraObject.transform.rotation.z);
            rb.MovePosition(transform.position + Quaternion.Euler(0, camRotation, 0) * movementVector * speed * Time.fixedDeltaTime);
           //Debug.Log("check: " + speed);
        }
        if(isVerticalMoving == true)
        {
            Vector3 vertMoveVector3 = new Vector3(0, verticalMovementVector, 0);
            rb.MovePosition(transform.position + vertMoveVector3 * verticalSpeed * Time.fixedDeltaTime);
        }

    }
}
