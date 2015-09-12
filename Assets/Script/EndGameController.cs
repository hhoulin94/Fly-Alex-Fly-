using UnityEngine;
using UnityEngine.UI ; 
using System.Collections;

public class EndGameController : MonoBehaviour {
	 
	public GameObject ReplayButton ;
	public GameObject HomeButton ;

	public GameObject ScoreBackground ; 
	public GameObject ScoreAtTop ; 

	public GameObject HiScoreLabel ;
	public GameObject ScoreLabel ; 
	public GameObject ScoreAtcenter ; 
	public GameObject HiScoreAtCenter ; 
	public GameObject TutorialText ; 

	private int timer = 50;  
	// Use this for initialization
	void Start () {
		TutorialText.SetActive (true); 
		ReplayButton.SetActive(false) ; 
		HomeButton.SetActive (false); 
		HiScoreLabel.SetActive (false);
		ScoreLabel.SetActive (false); 
		ScoreAtcenter.SetActive (false); 
		HiScoreLabel.SetActive (false);
		HiScoreAtCenter.SetActive (false);

		ScoreBackground.SetActive (true);
		ScoreAtTop.SetActive (true);  
	}
	
	// Update is called once per frame
	void Update () {

		timer--; 

		//Debug.Log (timer);

		if (timer < 0) {
			TutorialText.SetActive(false) ; 
			timer = 0 ; 
		}

		if (Camera.main.GetComponent<MainGameContoller> ().Gameover == true) {
			TutorialText.SetActive(false) ; 

			ReplayButton.SetActive(true) ; 
			HomeButton.SetActive(true) ; 
			HiScoreLabel.SetActive (true);
			ScoreLabel.SetActive (true); 
			ScoreAtcenter.SetActive (true); 
			HiScoreLabel.SetActive (true);
			HiScoreAtCenter.SetActive (true);


			ScoreBackground.SetActive (false);
			ScoreAtTop.SetActive (false);
		}
	}

	public void Restart(){
		Application.LoadLevel (1); 
	}

	public void Home(){
		Application.LoadLevel (0); 
	}


}
