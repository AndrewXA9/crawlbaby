using UnityEngine;
using System.Collections;

public class EyeLook : MonoBehaviour {

	private Vector3 origin;
	
	public float speed = 1;
	public float dist = 3;
	
	private float time = 0;
	
	private float cooldown = 0;
	
	void Start () {
		origin = this.transform.position;
	}
	
	void Update () {
		if(cooldown > 0){
			cooldown -= Time.deltaTime;
		}
		else{
			time += Time.deltaTime;
		}
		//Debug.Log(cooldown);
		this.transform.position = new Vector3(origin.x,origin.y+(((Mathf.Cos(time*speed)-1)/2)*dist),origin.z);
	}
	
	void Freeze(){
		cooldown = 3f;
	}
	
	
}
