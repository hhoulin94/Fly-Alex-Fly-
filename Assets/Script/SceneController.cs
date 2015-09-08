using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public GameObject AnimatedPlayer ; 
	public GameObject Player ; 

	private bool PlayerStartMove ; 

	// Use this for initialization
	void Start () {
		PlayerStartMove = false; 
		AnimatedPlayer.GetComponent<SpriteRenderer> ().enabled = false; 
		Time.timeScale = 1.0f; 
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStartMove == true) {
			AnimatedPlayer.transform.Translate ( Time.deltaTime * 4.00f, 0, 0); 
		}

		if (AnimatedPlayer.transform.position.x > 1.99f) {
			AnimatedPlayer.GetComponent<SpriteRenderer>().enabled = false ;
			Player.transform.position = new Vector2 (1.99f , Player.transform.position.y)  ; 	
			Player.GetComponent<SpriteRenderer>().enabled = true ; 
			float goUp = 8.0f * Time.deltaTime  ; 
			Player.transform.Translate(0 , - goUp , 0) ;
		}

		if (Player.transform.position.y < -5.66f) {
			Application.LoadLevel(1) ; 
		}
	}
	
	public void StartGame(){
		AnimatedPlayer.GetComponent<SpriteRenderer> ().enabled = true; 
		Player.GetComponent<SpriteRenderer> ().enabled = false;
		PlayerStartMove = true; 
	}

}
