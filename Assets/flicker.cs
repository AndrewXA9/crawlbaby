using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	private Vector3 origin;
	private float lightValue;
	private Light myLight;
	
	public float step;
	public float moveAmount;
	public float flickerAmount;
	
	
	
	void Start(){
		origin = this.transform.position;
		myLight = this.gameObject.GetComponent<Light>();
		lightValue = myLight.intensity;
		//StartCoroutine(Flicker);
	}
	
	void Update(){
		this.transform.position = origin+new Vector3(Random.Range(-moveAmount,moveAmount),Random.Range(-moveAmount,moveAmount),Random.Range(-moveAmount,moveAmount));
		myLight.intensity = lightValue+Random.Range(-flickerAmount,flickerAmount);
	}
	
	//IEnumerator Flicker(){
		
	//}
}
