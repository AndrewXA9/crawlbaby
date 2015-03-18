using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project2:MonoBehaviour{
	
	//public float rot = 0;
	//public float speed = 1;
	
	public float angle = 2;
	public float searchDist = 50;
	
	
	void Start(){
		
	}
	
	/*void Update(){
		
		RaycastHit ray;
		
		if(Physics.Raycast(this.transform.position,,out ray,searchDist)){
			if(ray.collider.tag == "Player"){
				hitPoints.Add(ray.point);
				ray.collider.gameObject.SendMessage("Alert");
				this.transform.parent.gameObject.SendMessage("Freeze");
			}
			else{
				hitPointsMiss.Add(ray.point);
			}
			
	}
	
	void OnDrawGizmos(){
		if(Time.time > 0){
			Gizmos.color = Color.green;
			foreach (Vector3 i in searchPoints){
				Gizmos.DrawSphere(((this.transform.rotation*Quaternion.Euler(90,0,0))*((Vector3.up*angle)+i))+this.transform.position,0.01f);
			}
			
			foreach (Vector3 i in hitPointsMiss){
				Gizmos.DrawSphere(i,0.1f);
			}
			Gizmos.color = Color.red;
			foreach (Vector3 i in hitPoints){
				Gizmos.DrawSphere(i,0.1f);
			}
		}
	}*/
}
