using UnityEngine;
using UnityEngine.UI ; 
using System.Collections;

public class ScoreController : MonoBehaviour {
	

	private static int score ; 

	Text scoretext ;
	 
	// Use this for initialization
	void Start () {
		scoretext = GetComponent<Text> (); 

		score = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		score = Camera.main.GetComponent<MainGameContoller> ().score;  
		PlayerPrefs.SetInt ("score" , score); 
		scoretext.text = " " + score;

	}


}
