using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] DynamicJoystick _joystick;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;
    private void FixedUpdate()
    {
        if (_joystick.Horizontal !=0 && _joystick.Vertical != 0 )
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, -_moveSpeed * 0.5f, 0);
        }
    }
}
