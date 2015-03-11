using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathing : MonoBehaviour {

	private List<Transform> nodes;
	private bool move = false;
	public  float waitTime;
	private float currTime = 0;
	public float moveSpeed;
	private int target = 0;
	private int maxTarget;
	
	void Start () {
		nodes = new List<Transform>();
		for(int i=0;i<this.transform.childCount;i++){
			if(this.transform.GetChild(i).name == "MoveNode"){
				nodes.Add(this.transform.GetChild(i));
				this.transform.GetChild(i).gameObject.renderer.enabled = false;
			}
		}
		foreach(Transform i in nodes){
			i.parent = null;
		}
	}
	
	void Update(){
		if(move){
			if((this.transform.position-nodes[target].position).magnitude > moveSpeed){
				this.transform.position += (nodes[target].position-this.transform.position).normalized*moveSpeed;
			}
			else{
				target = (target+1)%(nodes.Count);
				move = false;
			}
		}
		else{
			if(currTime < waitTime){
				currTime += Time.deltaTime;
				//Debug.Log(currTime);
			}
			else{
				currTime = 0;
				move = true;
				this.transform.LookAt(nodes[target].position);
			}
			//Debug.Log(move);
		}
	}
	
	void Freeze(){
		move = false;
		currTime = 0;
	}
	
	void OnDrawGizmos(){
		if(Time.time > 0){
			for(int i=0;i<nodes.Count;i++){
				Gizmos.color = Color.green;
				Gizmos.DrawLine(nodes[i].position,nodes[(i+1)%nodes.Count].position);
				Gizmos.color = Color.yellow;
				int c = 4;
				for(int j=0;j<c;j++){
					Gizmos.DrawSphere(Vector3.Lerp(nodes[i].position,nodes[(i+1)%nodes.Count].position,((Time.time/2f)+((1.0f/(float)c)*(float)j))%1),0.2f);
				}
			}
		}
	}
}