using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public GameObject up;
	public GameObject down;
	private CapsuleCollider colliderUp;
	private SphereCollider colliderDown;
	
	private GameObject climbPoint;
	
	public enum states {walk,crawl,run,jump,climb,grab};
	public states state = states.walk;
	
	public float walkspeed;
	public float crawlspeed;
	public float runspeed;
	
	public float turnspeed;
	
	private float speed;
	
	void Start(){
		climbPoint = GameObject.Find("Climb");
		
		speed = walkspeed;
		
		colliderUp = this.gameObject.GetComponent<CapsuleCollider>();
		colliderDown = this.gameObject.GetComponent<SphereCollider>();
		colliderDown.enabled = false;
	}
	
	// Update is called once per frame
	void Update(){
		
		
		//BASIC MOVEEMTN
		if(state == states.walk || state == states.run || state == states.crawl){
			Vector3 hMove = this.transform.right*Input.GetAxis("Horizontal")*(speed*Time.deltaTime)/2;
			Vector3 vMove = this.transform.forward*Input.GetAxis("Vertical")*(speed*Time.deltaTime);
			
			if(!Physics.Raycast(new Ray(this.transform.position+(Vector3.up*0.2f)+(hMove.normalized*(colliderDown.radius)),hMove.normalized),hMove.magnitude)){
				this.transform.position += hMove;
			}
			if(!Physics.Raycast(new Ray(this.transform.position+(Vector3.up*0.2f)+(vMove.normalized*(colliderDown.radius)),vMove.normalized),vMove.magnitude)){
				this.transform.position += vMove;
			}
		}
		//ROTATE
		this.transform.RotateAround(this.transform.position,Vector3.up,Input.GetAxis("Mouse X")*Time.deltaTime*turnspeed);
			
		//CRAWL
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			if(state == states.walk || state == states.run){
				state = states.crawl;
				up.SetActive(false);
				down.SetActive(true);
				colliderUp.enabled = false;
				colliderDown.enabled = true; 
				speed = crawlspeed;
			}
		}
		if(Input.GetKeyUp(KeyCode.LeftControl)){
			state = states.walk;
			up.SetActive(true);
			down.SetActive(false);
			colliderUp.enabled = true;
			colliderDown.enabled = false;
			speed = walkspeed;
		}
		
		
		
		
	}
	
	void OnDrawGizmos(){
		if(Time.time > 0){
			Vector3 hMove = this.transform.right*Input.GetAxis("Horizontal")*(speed*Time.deltaTime)/2;
			Vector3 vMove = this.transform.forward*Input.GetAxis("Vertical")*(speed*Time.deltaTime);
			
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.transform.position+(Vector3.up*0.2f),0.05f);
			Gizmos.DrawRay(this.transform.position+(Vector3.up*0.2f)+(hMove.normalized*(colliderDown.radius)),hMove);
			Gizmos.DrawRay(this.transform.position+(Vector3.up*0.2f)+(vMove.normalized*(colliderDown.radius)),vMove);
		}
	}
	
}
