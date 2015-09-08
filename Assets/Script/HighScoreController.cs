using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class HighScoreController : MonoBehaviour {
	private int oldHighScore ; 
	private int newHighscore ;

	Text HiScoreText ; 

	private int HiScore ; 

	void Start () {
		HiScoreText = GetComponent<Text> ();  
	}
	

	void Update () {  
		//use this to reset the score ;
		PlayerPrefs.SetInt ("highscore"	, 0 ); 

		oldHighScore = PlayerPrefs.GetInt ("highscore"); 
		newHighscore = Camera.main.GetComponent<MainGameContoller> ().score; 

		if (newHighscore > oldHighScore) {
			PlayerPrefs.SetInt ("highscore", newHighscore); 
			HiScore = newHighscore; 
		} else {
			HiScore = oldHighScore ; 
		}

		HiScoreText.text = " " + HiScore;
	}
}
