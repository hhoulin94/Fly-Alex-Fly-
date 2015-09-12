using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public GameObject BackgroundMusicObject ; 

	public GameObject AnimatedPlayer ; 
	public GameObject Player ; 

	private bool PlayerStartMove ; 
	private int TimesPlayed ; 
	// Use this for initialization
	void Start () {
		PlayerStartMove = false; 
		AnimatedPlayer.GetComponent<SpriteRenderer> ().enabled = false; 
		Time.timeScale = 1.0f; 
		//PlayerPrefs.SetInt("Times" , 0) ; 
		TimesPlayed = PlayerPrefs.GetInt ("Times"); 
		Debug.Log (TimesPlayed); 

		if (TimesPlayed == 0) {
			PlayerPrefs.SetInt ("Acceleration", 0);
			PlayerPrefs.SetInt ("Speed", 0);
			PlayerPrefs.SetInt ("coin", 0);
			PlayerPrefs.SetInt ("highscore", 0);
			TimesPlayed += 1 ; 
			PlayerPrefs.SetInt("Times" , TimesPlayed) ; 
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (PlayerStartMove == true) {
			AnimatedPlayer.transform.Translate ( Time.deltaTime * 4.00f, 0, 0); 
		}

		if (AnimatedPlayer.transform.position.x > -0.98f) {
			AnimatedPlayer.GetComponent<SpriteRenderer>().enabled = false ;
			Player.transform.position = new Vector2 (-0.98f , Player.transform.position.y)  ; 	
			Player.GetComponent<SpriteRenderer>().enabled = true ; 
			float goUp = 8.0f * Time.deltaTime  ; 
			Player.transform.Translate(0 , - goUp , 0) ;
		}

		if (Player.transform.position.y < -6.29f) {
			Application.LoadLevel(1) ; 
		}
	}
	
	public void StartGame(){
		AnimatedPlayer.GetComponent<SpriteRenderer> ().enabled = true; 
		Player.GetComponent<SpriteRenderer> ().enabled = false;
		PlayerStartMove = true; 
	}

	public void Upgrade(){
		Application.LoadLevel (2); 
	}

}
