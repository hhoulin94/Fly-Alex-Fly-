using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

	private float spawnTimeControl, currentspawnTimeLeft, spawnTimeTemp, goleft ;
	private int MinAmount = 1; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Camera.main.GetComponent<MainGameContoller> ().Gameover == false ) {
			
			goleft = Time.deltaTime * 7.00f; 
			
			this.gameObject.transform.Translate (-goleft, 0, 0); 
			
			if (this.gameObject.transform.position.x < -2.1f) {
				Destroy (this.gameObject); 
				Camera.main.GetComponent<MainGameContoller>().RocketBoom += 1 ; 
			}

		} else {
			
			Destroy(this.gameObject) ; 
			
		}

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy(this.gameObject) ; 
			Camera.main.GetComponent<MainGameContoller>().Gameover = true ; 
		}

		if (other.gameObject.tag == "obstacle") {
			Destroy(other.gameObject) ;
			Destroy(this.gameObject) ; 
		}
	}

}
