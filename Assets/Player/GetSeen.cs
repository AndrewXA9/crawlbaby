using UnityEngine;
using System.Collections;

public class GetSeen : MonoBehaviour {
	
	public GameObject alert;
	public bool alertOn = false;
	
	private AudioSource audio;
	
	public float TimeLimit;
	private float currTime = 0;
	private float resetDelay = 0;
	
	private int state = 0;
	
	private int alerts = 0;
	
	public void Start(){
		audio = this.gameObject.GetComponent<AudioSource>();
	}
	
	public void Update(){
		if(resetDelay > 0f){
			resetDelay -= Time.deltaTime;
		}
		else{
			if(currTime > 0f){
				currTime -= Time.deltaTime;
			}
		}
		
		if(currTime >= TimeLimit){
			GlobalReset.level = Application.loadedLevel;
			Application.LoadLevel(0);
		}
		
		if(alerts == 0 && alertOn){
			alert.SetActive(false);
			alertOn = false;
		}
		
		alerts = 0;
	}
	
	public void Alert(){
		if(alerts == 0){
			currTime += Time.deltaTime;
			currTime = Mathf.Clamp(currTime,0,TimeLimit);
			if(resetDelay <= 0){
				alert.SetActive(true);
				alertOn = true;
				audio.Play();
			}
			resetDelay = 1f;
		}
		alerts++;
	}
	
	public void OnGUI(){
		if(currTime > 0){
			GUI.Box(new Rect(0,0,Screen.width*(currTime/TimeLimit),100),"lolololooololol");
		}
		GUI.Box(new Rect(0,100,50,50),alerts.ToString());
	}
	
}
