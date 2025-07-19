using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    PlayerController playerController;
    List<GameObject> collidingWith;

    private void Awake()
    {
        playerController = gameObject.GetComponentInParent<PlayerController>();
        collidingWith = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider detected " + other.gameObject.name);
        if(other.gameObject.layer == 6)
        {
            collidingWith.Add(other.gameObject);
            Debug.Log(collidingWith.Count);
            CheckGround();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collider no longer detected " + other.gameObject.name);
        if (other.gameObject.layer == 6)
        {
            collidingWith.Remove(other.gameObject);
            Debug.Log(collidingWith.Count);
            CheckGround();
        }
    }

    void CheckGround()
    {
        if(collidingWith.Count > 0)
        {
            Debug.Log("you're grounded now");
            playerController.isGrounded = true;
        }
        else
        {
            Debug.Log("you're no longer grounded");
            playerController.isGrounded = false;
        }
    }

    /*
    bool CheckForGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
        Physics.SphereCast();
    }
    */
}
