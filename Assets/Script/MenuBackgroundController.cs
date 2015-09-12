using UnityEngine;
using System.Collections;

public class MenuBackgroundController : MonoBehaviour {

	public GameObject background ; 

	private float BackgroundTranslate ; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

			BackgroundTranslate = 3.0f * Time.deltaTime; 
			
			this.gameObject.transform.Translate (-BackgroundTranslate, 0, 0); 
			background.transform.Translate (-BackgroundTranslate, 0, 0);
			
			if (this.gameObject.transform.position.x < -24.3f) {
				this.gameObject.transform.position = new Vector2 (background.transform.position.x + 30, background.transform.position.y); 
			}
			
			if (background.transform.position.x < -24.3f) {
				background.transform.position = new Vector2 (this.gameObject.transform.position.x + 30, this.gameObject.transform.position.y); 
			}
	
	}
}
