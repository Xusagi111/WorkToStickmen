using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] DynamicJoystick _joystick;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;
    [SerializeField] float Quaternion1;
    [SerializeField] float Quaternion2;
    [SerializeField] bool start = false;
    private void FixedUpdate()
    {
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed, 0);
            Debug.Log($"_joystick.Horizontal: {_joystick.Horizontal} + _joystick.Vertical: {_joystick.Vertical} ");
            if (!start)
            {
               // StartCoroutine(NewTestCorrutine());
            }
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, 0));
            Debug.Log("намскемхе");
        }
    }
        IEnumerator NewTestCorrutine()
    {
        start = true;      
        yield return new WaitForSeconds(0.1f);
        if (_joystick.Horizontal > 0.6f)
        {

            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, Quaternion1));
        }
        if (_joystick.Horizontal < 0.6f)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, Quaternion2));
        }
        start = false;
    }
}
