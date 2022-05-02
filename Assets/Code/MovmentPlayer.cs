using MoreMountains.NiceVibrations;
using UnityEngine;
using System.Collections;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] DynamicJoystick _joystick;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _currentPlayer;
    [SerializeField] float _moveSpeed;
    [SerializeField] Animator _animator;
    private const int _constRotate = 2;
    [SerializeField] private bool _isRotateRight = true;
    [SerializeField] private bool _isRotateLeft;
    [SerializeField] private bool _isAnimation;


    /// <summary>
    /// Партиклы для анимации 
    /// </summary>
    [SerializeField] private GameObject ParticleSystem;

    private void Update()
    {
        
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
           // _animator.SetBool("isBland", true);


            Vector3 a = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);

            _rigidbody.velocity = a;
            //if (_currentPlayer.transform.transform.eulerAngles.y > -_constRotate && _joystick.Horizontal < -0.1 && !_isRotateLeft)
            //{
            //    Quaternion quaternion = new Quaternion(0, -180, 0, 0);

            //    _currentPlayer.GetComponent<Rigidbody>().MoveRotation(quaternion.normalized);
            
            //    _isRotateLeft = true;
            //    _isRotateRight = false;
            //}
            //if (_currentPlayer.transform.transform.eulerAngles.y > _constRotate && _joystick.Horizontal > 0.0002 && !_isRotateRight)
            //{
            //    Quaternion quaternion = new Quaternion(0, 180, 0, 0);
            //    _currentPlayer.GetComponent<Rigidbody>().MoveRotation(quaternion.normalized);

            //    _isRotateLeft = false;
            //    _isRotateRight = true;
            //}
        }
        //else
        //{
        //    _animator.SetBool("isBland", true);
        //}
       // CheckGround();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Enemy_Sword")
        {
            Debug.Log("Collizion + Проиграть партиклы и вибрацию"); //Проиграть партиклы и вибрацию
            Instantiate(ParticleSystem, collision.transform.position, Quaternion.identity);
            MMVibrationManager.Vibrate();
            StartCoroutine(TimeLineToParicle());
        }
    }

    private IEnumerator TimeLineToParicle()
    {
        ParticleSystem.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        ParticleSystem.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ParticleSystem.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        ParticleSystem.gameObject.SetActive(false);


    }
    private void CheckGround()
    {
       
        Ray ray = new Ray(transform.position, Vector3.forward);
        //Debug.DrawLine(transform.position, Vector3.forward, color: Color.green);
        RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 3f))
        //{
        //    Debug.Log("transform.position" + transform.position);
        //    if (hit.collider.tag == "Ground")
        //    {
        //        Debug.Log(hit.collider + "Ground");
        //    }
        //}
        //if (Physics.Raycast(ray, out hit, 3f))
        //{
        //    Debug.Log("transform.position" + transform.position);
        //    if (hit.collider.tag == "Ground")
        //    {
        //        Debug.Log(hit.collider + "Ground");
        //    }
        //}
        //if (Physics.Raycast(ray, out hit, 3f))
        //{
        //    Debug.Log("transform.position" + transform.position);
        //    if (hit.collider.tag == "Ground")
        //    {
        //        Debug.Log(hit.collider + "Ground");
        //    }
        //}

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2);
        int i = 0;
        while (i < hitColliders.Length)
        {
            // Debug.DrawLine(transform.position, transform.position + new Vector3(50,50,50), color: Color.green);
            if (hitColliders[i].tag == "Ground")
            {


                    //Debug.LogError("Ground");
                    //_currentPlayer.GetComponent<Rigidbody>().velocity = _vector3;

            }
            Debug.Log(hitColliders[i].name);

            i++;
        }
    }
}
