using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathing : MonoBehaviour {

	public List<Transform> nodes;
	
	void Start () {
		for(int i=0;i<this.transform.childCount;i++){
			nodes.Add(this.transform.GetChild(i));
			this.transform.GetChild(i).gameObject.renderer.enabled = false;
		}
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