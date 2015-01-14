using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project:MonoBehaviour{
	
	public float rot = 0;
	public float speed = 1;
	
	private float rez = 20;
	
	private List<Vector3> searchPoints;
	
	void Start(){
		searchPoints = new List<Vector3>();
		
		for(int i=0;i<(rez*rez);i++){
			searchPoints.Add(new Vector3());
		}
		
		int ind = 0;
		for(int i=0;i<rez;i++){
			for(int j=0;j<rez;j++){
				float x = ((float)j/rez)-0.5f+((1f/rez)/2f);
				float y = ((float)i/rez)-0.5f+((1f/rez)/2f);
				Vector3 v = new Vector3(x,0.0f,y);
				if((v.magnitude<0.5f)){
					searchPoints[ind] = v;
				}
				
				ind++;
			}
		}
	}
	
	void Update(){
		rot = rot+(speed*Time.deltaTime);
		
		this.transform.rotation = Quaternion.Euler(0,rot,0);
		
		for(int i=0;i<rez;i++){
			
		}
	}
	
	void OnDrawGizmos(){
		if(Time.time > 0){
			foreach (Vector3 i in searchPoints){
				if(i == Vector3.zero){
					Gizmos.color = Color.red;
				}
				else{
					Gizmos.color = Color.green;
				}
				Gizmos.DrawSphere(i,0.1f);
			}
		}
	}
}
