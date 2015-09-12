using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public GameObject background ; 

	private float BackgroundTranslate ; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Camera.main.GetComponent<MainGameContoller> ().Gameover == false) {
			BackgroundTranslate = 1.0f * Time.deltaTime; 

			this.gameObject.transform.Translate (-BackgroundTranslate, 0, 0); 
			background.transform.Translate (-BackgroundTranslate, 0, 0);

			if (this.gameObject.transform.position.x < -10.73f) {
				this.gameObject.transform.position = new Vector2 (background.transform.position.x +12, background.transform.position.y); 
			}

			if (background.transform.position.x < -10.73f) {
				background.transform.position = new Vector2 (this.gameObject.transform.position.x + 12, this.gameObject.transform.position.y); 
			}
		} else {
			this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x , this.gameObject.transform.position.y) ;
			background.transform.position = new Vector2(background.transform.position.x , background.transform.position.y) ; 
		}
	}
}
