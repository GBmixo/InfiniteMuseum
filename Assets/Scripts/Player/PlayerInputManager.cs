using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerControls controls;
    PlayerController playerController;

    private void Awake()
    {
        controls = new PlayerControls();
        playerController = GetComponent<PlayerController>();

        controls.DefaultPlayer.Move.performed += ctx =>
        {
            playerController.inputDir = ctx.ReadValue<Vector2>();
            //playerController.shouldMove = true;
        };
        controls.DefaultPlayer.Move.canceled += ctx =>
        {
            playerController.inputDir = new Vector2(0,0);
            //playerController.shouldMove = false;
        };

        controls.DefaultPlayer.Sprint.started += ctx =>
        {
            playerController.TriggerSprint();
        };
        controls.DefaultPlayer.Sprint.canceled += ctx =>
        {
            playerController.TriggerSprint();
        };

        controls.DefaultPlayer.Interact.performed += ctx =>
        {

        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
