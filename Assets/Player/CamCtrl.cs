using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	
	public float backDist;
	public float upDist;
	public float focusHeightUp;
	public float focusHeightDown;
	private float focusHeight;
	public float snap;
	public float verticalSpeed;
	
	public float minAngle;
	public float maxAngle;
	
	public float transparentDist;
	
	private float angle;
	
	private GameObject player;
	private Vector3 target;
	
	//private bool up = true;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		focusHeight = focusHeightUp;
		//Screen.lockCursor = true;
	}

	private Vector3 dicks;

	void Update () {
		
		
		angle += (-Input.GetAxis("Mouse Y"))*Time.deltaTime*verticalSpeed;
		angle = Mathf.Clamp(angle,minAngle,maxAngle);
		
		this.transform.position = Vector3.Lerp(this.transform.position,target,snap*Time.deltaTime);
		player.transform.position+=(Vector3.up*focusHeight);
		this.transform.LookAt(player.transform.position);
		player.transform.position-=(Vector3.up*focusHeight);
		
		target = ((player.transform.rotation*Quaternion.Euler(angle,0f,0f))*((Vector3.back*backDist)+(Vector3.up*upDist)))+(player.transform.position+(Vector3.up*focusHeight));
		RaycastHit ray;
		//if(Physics.Raycast(player.transform.position+(Vector3.up*focusHeight),((player.transform.rotation*Quaternion.Euler(angle,0f,0f))*Vector3.back).normalized,out ray,backDist)){
		if(Physics.Raycast(player.transform.position+(Vector3.up*focusHeight),((player.transform.rotation*Quaternion.Euler(angle,0f,0f))*((Vector3.back*backDist)+(Vector3.up*upDist))),out ray,backDist)){
			target = ray.point;
			dicks = ray.point;
		}

		if(Input.GetMouseButtonDown(0)){
			Screen.lockCursor = true;
		}
		Debug.Log(angle);
		
	}
	
	void OnDrawGizmos(){
		
		if(Time.time > 0){
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(target,.25f);
			
			Gizmos.color = Color.yellow;
			Quaternion quat = (player.transform.rotation*Quaternion.Euler(angle,0f,0f));
			Gizmos.DrawRay(player.transform.position+(Vector3.up*focusHeight),quat*((Vector3.back*backDist)+(Vector3.up*upDist)) );
			Gizmos.DrawWireSphere(dicks,.25f);
		}
	}
	
	public void Up(){
		focusHeight = focusHeightUp;
	}
	public void Down(){
		focusHeight = focusHeightDown;
	}
	
	
}
