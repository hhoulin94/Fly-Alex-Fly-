using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class HighScoreController : MonoBehaviour {

	public GameObject star ; 

	private int oldHighScore ; 
	private int newHighscore ;

	Text HiScoreText ; 

	private int HiScore ; 

	void Start () {
		star.GetComponent<SpriteRenderer> ().enabled = false; 
		HiScoreText = GetComponent<Text> ();  
	}
	

	void Update () {  
		//use this to reset the score ;
		 

		oldHighScore = PlayerPrefs.GetInt ("highscore"); 
		newHighscore = Camera.main.GetComponent<MainGameContoller> ().score; 

		if (newHighscore > oldHighScore) {
			PlayerPrefs.SetInt ("highscore", newHighscore); 
			HiScore = newHighscore; 
			star.GetComponent<SpriteRenderer>().enabled = true ; 
		} else {
			HiScore = oldHighScore ; 
		}

		HiScoreText.text = " " + HiScore;
	}
}
