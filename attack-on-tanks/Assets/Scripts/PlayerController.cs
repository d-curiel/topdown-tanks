using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject _Tank;
    [SerializeField]
    PlayerInput _PlayerInput;


    TankController _TankController;

    private void Awake()
    {
        _PlayerInput.actions.actionMaps[0].Enable();
        _TankController = _Tank.GetComponent<TankController>();
    }
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        _TankController.OnMovementInput(context.ReadValue<Vector2>());
    }

    public void OnAimInput(InputAction.CallbackContext context)
    {

        _TankController.OnAimInput(Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()));
    }

    public void OnShotInput(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton())
        {
            _TankController.OnShotInput();
        }
    }
}
