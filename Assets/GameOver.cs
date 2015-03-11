using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public Texture image;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect((Screen.width/2f)-(image.width/2f),0,Screen.height,Screen.height),image);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel(GlobalReset.level);
		}
	}
}
