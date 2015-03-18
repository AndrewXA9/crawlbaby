using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public Texture image;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),image,ScaleMode.ScaleToFit);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel(GlobalReset.level);
		}
	}
}
