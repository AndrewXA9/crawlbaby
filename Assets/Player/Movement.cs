using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public GameObject up;
	public GameObject down;
	private CapsuleCollider colliderUp;
	private SphereCollider colliderDown;
	
	private Camera cam;
	
	private GameObject climbPoint;
	
	private float fast = 1f;
	
	public enum states {walk,crawl,jump,climb,grab};
	public states state = states.walk;
	
	public float walkspeed;
	public float crawlspeed;
	public float speedupMultiplier;
	
	public float turnspeed;
	
	private float speed;
	
	public AnimationCurve climbUp;
	public AnimationCurve climbForward;
	
	
	
	void Start(){
		climbPoint = GameObject.Find("Climb");
		
		cam = Camera.main;
		
		speed = walkspeed;
		
		colliderUp = this.gameObject.GetComponent<CapsuleCollider>();
		colliderDown = this.gameObject.GetComponent<SphereCollider>();
		colliderDown.enabled = false;
	}
	
	// Update is called once per frame
	void Update(){

		//BASIC MOVEEMTN
		if(state == states.walk || state == states.crawl){
			Vector3 hMove = this.transform.right*Input.GetAxis("Horizontal")*(speed*Time.deltaTime)*(.5f)*fast;
			Vector3 vMove = this.transform.forward*Input.GetAxis("Vertical")*(speed*Time.deltaTime)*fast;
			
			if(!Physics.Raycast(new Ray(this.transform.position+(Vector3.up*0.2f)+(hMove.normalized*(colliderDown.radius)),hMove.normalized),hMove.magnitude)){
				this.transform.position += hMove;
			}
			if(!Physics.Raycast(new Ray(this.transform.position+(Vector3.up*0.2f)+(vMove.normalized*(colliderDown.radius)),vMove.normalized),vMove.magnitude)){
				this.transform.position += vMove;
			}
		}

		//ROTATE
		if(state != states.grab && state != states.climb){
			this.transform.RotateAround(this.transform.position,Vector3.up,Input.GetAxis("Mouse X")*Time.deltaTime*turnspeed);
		}
			
		//PARKOUR
		if(state != states.climb && state != states.crawl){
			if(Input.GetKeyDown(KeyCode.Space)){
				RaycastHit ray;
				if(Physics.Raycast(climbPoint.transform.position,-(this.transform.up),out ray,0.8f)){
					StartCoroutine(Parkour((ray.point-this.transform.position).magnitude));
				}
			}
			
		}
		
		//CRAWL TOGGLE
		if(state == states.walk || state == states.crawl){
			if(Input.GetKeyDown(KeyCode.LeftControl)){
				if(state == states.walk){
					state = states.crawl;
					up.SetActive(false);
					down.SetActive(true);
					colliderUp.enabled = false;
					colliderDown.enabled = true; 
					cam.SendMessage("Down");
					speed = crawlspeed;
				}
			}
			if(Input.GetKeyUp(KeyCode.LeftControl)){
				state = states.walk;
				up.SetActive(true);
				down.SetActive(false);
				colliderUp.enabled = true;
				colliderDown.enabled = false;
				cam.SendMessage("Up");
				speed = walkspeed;
			}
		}
		
		
		
		
	}
	
	IEnumerator Parkour(float height){
		states tState = state;
		state = states.climb;
		
		float t = 0;
		Vector3 pos = this.transform.position;
		
		this.rigidbody.useGravity = false;
		colliderUp.enabled = false;
		
		while(t<1){
			this.transform.position = pos+(this.transform.up*climbUp.Evaluate(t)*height)+(this.transform.forward*climbForward.Evaluate(t)*0.4f);
			t += Time.deltaTime;
			yield return null;
		}
		
		state = tState;
		this.rigidbody.useGravity = true;
		colliderUp.enabled = true;
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
