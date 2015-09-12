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

			goleft = Time.deltaTime * 8.00f; 

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
