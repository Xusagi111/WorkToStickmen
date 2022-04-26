using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] DynamicJoystick _joystick;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;
    [SerializeField] bool start = false;
    [SerializeField] Animator _animator;
    private const int _constRotate = 2;
    [SerializeField] private bool _isRotateRight = true;
    [SerializeField] private bool _isRotateLeft;


    //Logic Sword
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            Vector3 a = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);

            _rigidbody.velocity = a;
            Debug.Log($"_joystick.Horizontal: {_joystick.Horizontal} + _joystick.Vertical: {_joystick.Vertical} ");
        }
    }

    //private void Update()
    //{
    //    if (_isRotateRight)
    //    {
    //        _animator.SetBool("isBland", true);
    //        _animator.SetFloat("Vertical", -_joystick.Vertical * _moveSpeed);
    //        _animator.SetFloat("Horizontal", -_joystick.Horizontal * _moveSpeed);
    //    }
    //    else
    //    {
    //        _animator.SetBool("isBland", true);
    //        _animator.SetFloat("Vertical", _joystick.Vertical * _moveSpeed);
    //        _animator.SetFloat("Horizontal", _joystick.Horizontal * _moveSpeed);
    //    }

    //    if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
    //    {
    //        //Vector3 a = new Vector3(0, _joystick.Vertical * _moveSpeed, _joystick.Horizontal * _moveSpeed);

    //        //_rigidbody.velocity = a;
    //        Debug.Log($"_joystick.Horizontal: {_joystick.Horizontal} + _joystick.Vertical: {_joystick.Vertical} ");


    //        if (gameObject.transform.transform.eulerAngles.y > -_constRotate && _joystick.Horizontal < -0.1 && !_isRotateLeft)
    //        {
    //            gameObject.transform.transform.eulerAngles = new Vector3(0, -180, 0);
    //            _isRotateLeft = true;
    //            _isRotateRight = false;
    //        }
    //        if (gameObject.transform.transform.eulerAngles.y > _constRotate && _joystick.Horizontal > 0.0002 && !_isRotateRight)
    //        {
    //            gameObject.transform.transform.eulerAngles = new Vector3(0,0,0);
    //            _isRotateLeft = false;
    //            _isRotateRight = true;
    //        }

    //        //if (!start)
    //        //{
    //        //    StartCoroutine(NewTestCorrutine());
    //        //}
    //    }
    //    else
    //    {
    //        //_rigidbody.velocity = new Vector3(0, 0, 0);
    //        //_rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, 0));
    //        _animator.SetBool("isBland", false);
    //        //Debug.Log("намскемхе");
    //    }
    //}
    //IEnumerator NewTestCorrutine()
    //{
    //    start = true;
    //    yield return new WaitForSeconds(0.2f);

    //    _animator.SetBool("isBland", true);
    //    _animator.SetFloat("Vertical", _joystick.Vertical *_moveSpeed * Time.deltaTime);
    //    _animator.SetFloat("Horizontal", _joystick.Horizontal * _moveSpeed * Time.deltaTime);
    //    start = false;
    //}

    //IEnumerator NewTestCorrutine()
    //{
    //    start = true;
    //    yield return new WaitForSeconds(0.1f);
    //    if (_joystick.Horizontal > 0.6f)
    //    {

    //        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, Quaternion1));
    //    }
    //    if (_joystick.Horizontal < 0.6f)
    //    {
    //        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, 0, Quaternion2));
    //    }
    //    start = false;
    //}
}
