using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	
	public float backDist;
	public float upDist;
	public float focusHeight;
	public float snap;
	public float verticalSpeed;
	
	public float minAngle;
	public float maxAngle;
	
	public float transparentDist;
	
	private float angle;
	
	private GameObject player;
	private Vector3 target;
	
	
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//Screen.lockCursor = true;
	}
	
	void Update () {
		
		
		angle += Input.GetAxis("Mouse Y")*Time.deltaTime*verticalSpeed;
		angle = Mathf.Clamp(angle,minAngle,maxAngle);
		
		this.transform.position = Vector3.Lerp(this.transform.position,target,snap*Time.deltaTime);
		player.transform.position+=(Vector3.up*focusHeight);
		this.transform.LookAt(player.transform.position);
		player.transform.position-=(Vector3.up*focusHeight);
		
		target = ((player.transform.rotation*Quaternion.Euler(angle,0f,0f))*((Vector3.back*backDist)+(Vector3.up*upDist)))+player.transform.position;
		
		if(Input.GetMouseButtonDown(0)){
			Screen.lockCursor = true;
		}
		
		/*RaycastHit ray;
		if(Physics.Raycast(this.transform.position,this.transform.forward,out ray,transparentDist)){
			ray.collider.renderer.material.color = Color.red;
		}*/
		
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(target,.25f);
	}
	
}
