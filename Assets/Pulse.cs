using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {


	public float speed = 1f;
	public float grow = 0.2f;

	public Vector3 init;

	void Start () {
		init = this.transform.localScale;
	}

	void Update () {
		this.transform.localScale = init + ((Vector3.one * (Mathf.Sin(Time.time*speed)*grow)));
	}
}
