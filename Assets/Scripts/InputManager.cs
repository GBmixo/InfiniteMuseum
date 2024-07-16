using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    SpectatorCamera controls;
    SpectatorMovement movementController;
    public GameObject cameraObject;

    MouseLook mouseLook;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new SpectatorCamera();
        movementController = gameObject.GetComponent<SpectatorMovement>();
        mouseLook = cameraObject.GetComponent<MouseLook>();

        controls.Spectator.Movement.performed += ctx =>
        {
            Vector2 ctxVector2 = ctx.ReadValue<Vector2>();
            movementController.TriggerMovement(ctxVector2);
        };

        controls.Spectator.Movement.canceled += ctx =>
        {
            movementController.CancelMovement();
        };

        controls.Spectator.UpDownControl.performed += ctx =>
        {
            float ctxValue = ctx.ReadValue<float>();
            movementController.TriggerVerticalMovement(ctxValue);
        };
        controls.Spectator.UpDownControl.canceled += ctx =>
        {
            movementController.CancelVerticalMovement();
        };

        controls.Spectator.MouseLook.performed += ctx =>
        {
            Vector2 ctxVector2 = ctx.ReadValue<Vector2>();
            mouseInput = ctxVector2;
        };

    }

    private void Update()
    {
        mouseLook.UpdateMouseInput(mouseInput);
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
