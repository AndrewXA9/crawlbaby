using UnityEngine;
using System.Collections;

public class GetSeen : MonoBehaviour {
	
	public GameObject alert;
	public GameObject arrow;
	public bool alertOn = false;
	
	private AudioSource audio;
	
	public float TimeLimit;
	private float currTime = 0;
	private float resetDelay = 0;
	
	private int state = 0;
	
	private int alerts = 0;
	
	public Texture bar;
	public Texture border;
	
	private Vector3 alertPos;
	
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
			Application.LoadLevel(1);
		}
		
		if(alerts == 0 && alertOn){
			alert.SetActive(false);
			arrow.SetActive(false);
			alertOn = false;
		}
		
		alerts = 0;
	}
	
	public void Alert(Vector3 pos){
		if(alerts == 0){
			alertPos = pos;
			arrow.transform.LookAt(alertPos);
			
			currTime += Time.deltaTime;
			currTime = Mathf.Clamp(currTime,0,TimeLimit);
			if(resetDelay <= 0){
				alert.SetActive(true);
				arrow.SetActive(true);
				alertOn = true;
				audio.Play();
			}
			resetDelay = 1f;
		}
		alerts++;
	}
	
	public void OnGUI(){
		if(currTime > 0){
			GUI.DrawTexture(new Rect(0,0,Screen.width*(currTime/TimeLimit),100),bar);
			GUI.DrawTexture(new Rect(0,0,Screen.width,100),border);
		}
		GUI.Box(new Rect(0,100,50,50),alerts.ToString());
	}
	
}
