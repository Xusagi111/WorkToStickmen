using UnityEngine;

public class DragAndDropPlayerArm : MonoBehaviour
{
    public Rigidbody _rigidbody;
    private Vector3 _vector3 = new Vector3(3, 5f, 0);
    private Vector3 _vector3Minus = new Vector3(-3, -5f, 0);
    private bool isbool;

    void FixedUpdate()
    {
        if (isbool)
        {
            _rigidbody.velocity = _vector3;
            isbool = false;
        }
        else
        {
            _rigidbody.velocity = _vector3Minus;
            isbool = true;
        }
    }
}
