using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;
    private Playermotor _playermotor;
    private PlayerLook _look;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _playermotor = GetComponent<Playermotor>();
        _look = GetComponent<PlayerLook>();
        _onFoot.Jump.performed += ctx => _playermotor.Jump();
    }
    void FixedUpdate()
    {
        _playermotor.processMove(_onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.processLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
