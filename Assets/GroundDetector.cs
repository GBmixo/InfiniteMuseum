using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    PlayerController playerController;

    private void Awake()
    {
        playerController = gameObject.GetComponentInParent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider detected " + other.gameObject.name);
        if(other.gameObject.layer == 6)
        {
            Debug.Log("you're grounded now");
            playerController.isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collider no longer detected " + other.gameObject.name);
        if (other.gameObject.layer == 6)
        {
            Debug.Log("you're no longer grounded");
            playerController.isGrounded = false;
        }
    }
}
