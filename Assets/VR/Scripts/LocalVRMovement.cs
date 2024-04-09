using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class LocalVRMovement : MonoBehaviour
{


    [SerializeField]
    private InputActionReference _moveInput;

    [SerializeField]
    private InputActionReference _rotateInput;

    [SerializeField]
    private Transform _headTransform;

    private CharacterController _characterController;
    private float _gravity = 0;

    public float MovementSpeed;
    public float RotateSpeed;
    private void OnEnable()
    {
        _moveInput.action.Enable();
        _rotateInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action.Disable();
        _rotateInput.action.Disable();
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Move();
        Rotate();
        Gravity();
    }

    private void Move()
    {
        Vector2 direction = _moveInput.action.ReadValue<Vector2>();
        Vector3 dir = new Vector3(direction.x, 0, direction.y);
        dir= _headTransform.TransformDirection(dir);
        dir = Vector3.Scale(dir, new Vector3(1, 0, 1)).normalized;
        _characterController.Move(dir*MovementSpeed*Time.deltaTime);
    }

    private void Rotate()
    {
        Vector2 rotation = _rotateInput.action.ReadValue<Vector2>();
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + rotation.x, 0)*RotateSpeed);
    }

    private void Gravity()
    {
        if (_characterController.isGrounded)
        {
            _gravity = 0;
        }
        else
        {
            _gravity -= 9.81f + Time.deltaTime;
            _characterController.Move(new Vector3(0, _gravity, 0));
        }
    }
}
