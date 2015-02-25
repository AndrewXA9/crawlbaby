using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project:MonoBehaviour{
	
	//public float rot = 0;
	//public float speed = 1;
	
	public float rez = 10;
	public float angle = 2;
	public float searchDist = 50;
	
	private List<Vector3> searchPoints;
	private List<Vector3> hitPoints;
	private List<Vector3> hitPointsMiss;
	
	void Start(){
		searchPoints = new List<Vector3>();
		hitPoints = new List<Vector3>();
		hitPointsMiss = new List<Vector3>();
		
		for(int i=0;i<rez;i++){
			for(int j=0;j<rez;j++){
				float x = ((float)j/rez)-0.5f+((1f/rez)/2f);
				float y = ((float)i/rez)-0.5f+((1f/rez)/2f);
				Vector3 v = new Vector3(x,0.0f,y);
				if((v.magnitude<0.5f)){
					searchPoints.Add(v);
				}
			}
		}
	}
	
	void Update(){
		//rot = rot+(speed*Time.deltaTime);
		
		//this.transform.rotation = Quaternion.Euler(0,rot,0);
		
		RaycastHit ray;
		hitPoints.Clear();
		hitPointsMiss.Clear();
		foreach(Vector3 i in searchPoints){
			//if(Physics.Raycast(this.transform.position,(this.transform.rotation*Quaternion.Euler(90,0,0))*(this.transform.position+(Vector3.up*angle)+i),out ray,searchDist)){
			if(Physics.Raycast(this.transform.position,((this.transform.rotation*Quaternion.Euler(90,0,0))*((Vector3.up*angle)+i)),out ray,searchDist)){
				if(ray.collider.tag == "Player"){
					hitPoints.Add(ray.point);
					ray.collider.gameObject.SendMessage("Alert");
				}
				else{
					hitPointsMiss.Add(ray.point);
				}
			}
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
	}
}
