using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [Header("MobileControls")]
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private CharacterController charcontroller;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Vector3 _moveVector;

    private void Start()
    {
        charcontroller = GetComponent<CharacterController>();
        GameObject joystickObject = GameObject.FindWithTag("GameController");
       _joystick = joystickObject.GetComponent<FixedJoystick>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        charcontroller.Move(_moveVector);
    }
}
