using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    public float timeDestroy = 5f;
    public GameObject effect;
    public Transform parentObjectPosition;
    public GameObject parentObject;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject effectGo = (GameObject)Instantiate(effect, parentObjectPosition.position, parentObjectPosition.rotation);
            effectGo.transform.parent = parentObject.transform;
            Destroy(effectGo, timeDestroy);    
        }
    }
}