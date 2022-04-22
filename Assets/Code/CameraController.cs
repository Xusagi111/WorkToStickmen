using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _currentObjCamera;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, _player.position + _currentObjCamera, Time.deltaTime + _speed);
    }
}
