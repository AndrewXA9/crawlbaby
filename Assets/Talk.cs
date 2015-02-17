﻿using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour {


	public string text = "Text goes here llololollolool";
	
	private Rect Bubble;
	private float pos;
	
	
	void Start () {
		Bubble = new Rect(Screen.width/20f,-((Screen.height/20f)+(Screen.height/5f)),Screen.width-((Screen.width/20f)*2f),Screen.height/5f);
		pos = Bubble.y;
		this.gameObject.renderer.enabled = false;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			pos = Screen.height/20f;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			pos = -((Screen.height/20f)+(Screen.height/5f));
		}
	}
	
	void OnGUI(){
		Bubble.y = Mathf.Lerp(Bubble.y,pos,0.1f);
		GUI.Box(Bubble,text);
		
	}
	
	
	
}
