using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private float goleft ; 

	// Use this for initialization
	void Start () {
		this.gameObject.tag = "obstacle"; 
	}
	
	// Update is called once per frame
	void Update () {

		if (Camera.main.GetComponent<MainGameContoller> ().Gameover == false) {

			if(Camera.main.GetComponent<MainGameContoller>().score != 0){
			goleft = Time.deltaTime * 4.00f; 
			}else if(Camera.main.GetComponent<MainGameContoller>().score <= 10){
				goleft = Time.deltaTime * 4.50f ; 
			}else if(Camera.main.GetComponent<MainGameContoller>().score <= 20 &&Camera.main.GetComponent<MainGameContoller>().score >10){
				goleft = Time.deltaTime * 5.0f ; 
			}else if(Camera.main.GetComponent<MainGameContoller>().score > 20 && Camera.main.GetComponent<MainGameContoller>().score <= 30){
				goleft = Time.deltaTime * 6.0f ; 
			}else if(Camera.main.GetComponent<MainGameContoller>().score  > 30 && Camera.main.GetComponent<MainGameContoller>().score  <= 40){
				goleft = Time.deltaTime * 6.5f ; 
			}else if(Camera.main.GetComponent<MainGameContoller>().score  > 40 && Camera.main.GetComponent<MainGameContoller>().score <= 50){
				goleft = Time.deltaTime *7.0f ; 
			} else{
				goleft = Time.deltaTime *8.0f ; 
			}

			this.gameObject.transform.Translate (-goleft, 0, 0); 
	
			if (this.gameObject.transform.position.x < -4.968f) {
				Destroy (this.gameObject); 
				Camera.main.GetComponent<MainGameContoller>().score++ ; 
			}
		} else {

			Destroy(this.gameObject) ; 
		
		}
	}

}
