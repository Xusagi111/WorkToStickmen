using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEndEffect : MonoBehaviour {

    public float DestroyTime = 3.0f;
    public GameObject HitEffect = null;
    private LaserLine LL;
    private bool bHit = false;

    void Start()
    {
        LL = (LaserLine)this.gameObject.transform.FindChild("LaserLine").GetComponent<LaserLine>();
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        RaycastHit hit;
        int layerMask = ~(1 << LayerMask.NameToLayer("NoBeamHit") | 1 << 2);
        if (HitEffect != null && !bHit && Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            GameObject hitobj = hit.collider.gameObject;
            if (hit.distance < LL.GetNowLength())
            {
                LL.StopLength(hit.distance);
                bHit = true;

                Quaternion Angle;
                Angle = Quaternion.AngleAxis(180.0f, transform.up) * this.transform.rotation;
                GameObject obj = (GameObject)Instantiate(HitEffect, this.transform.position + this.transform.forward * hit.distance, Angle);
                obj.transform.localScale = this.transform.localScale;
            }
        }
    }
}
