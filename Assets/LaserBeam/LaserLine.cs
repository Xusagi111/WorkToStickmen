using UnityEngine;
using System.Collections;

public class LaserLine : MonoBehaviour {

	public float MaxLength = 100.0f;
	public float StartSize = 0.3f;
	public float AnimationSpd = 0.1f;
	public Color LineColor = Color.red; 

	private float NowAnm;
	private LineRenderer line;
	private float NowLength;
	private bool bStop;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startColor = LineColor;
        line.endColor = LineColor;
        NowAnm = 0;
        NowLength = 0;
        bStop = false;
        LineFunc();
    }

	void LineFunc()
	{
		if(!bStop)
			NowLength = Mathf.Lerp(0,MaxLength,NowAnm);
		float width = Mathf.Lerp(StartSize,0,NowAnm);
		line.startWidth = width;
        line.endWidth = width;
        float length = NowLength;
		line.SetPosition(0,transform.position);
		line.SetPosition(1,transform.position+(transform.forward*length));
	}
	
	void Update ()
    {
		NowAnm+=AnimationSpd;
		if(NowAnm > 1.0)
		{
			Destroy(this.gameObject);
		}
		LineFunc();
	}

    public float GetNowLength() //this for OnCollision script
    {
        return NowLength;
    }
    public void StopLength(float length) //this for OnCollision script too
    {
        NowLength = length;
        bStop = true;
    }
}
