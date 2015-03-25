using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour {
	
	private int cookies = 0;
	private int maxCookies = -1;
	
	void Start () {
		GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit");
		foreach(GameObject i in exits){
			i.renderer.enabled = false;
		}
		
		maxCookies = GameObject.FindGameObjectsWithTag("CookieJar").Length;
		
		
	}
	
	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.gameObject.tag);
		if(collision.gameObject.tag == "Exit"){
			Debug.Log("asfasd");
			Application.LoadLevel(Application.loadedLevel+1);
			
		}
		
		if(collision.gameObject.tag == "CookieJar"){
			cookies ++;
			Destroy(collision.gameObject);
			
			if(cookies >= maxCookies-3){
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}
		
	}
	
	
}
