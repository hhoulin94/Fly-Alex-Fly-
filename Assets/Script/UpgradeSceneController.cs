using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeSceneController : MonoBehaviour {

	public Text speedText ; 
	public Text CoinText ; 
	public Text AccelerationText ; 

	private int coin ;

	private int SpeedScore , AccelerationScore ;
	private int Speed , acceleration ; 
	private bool SpeedIncrease , AccelerationIncrease; 

	// Use this for initialization
	void Start () {
		//coin = PlayerPrefs.GetInt ("coin"); 
		//speedText.text = " " + Speed ; 
		SpeedIncrease = false; 
		AccelerationIncrease = false; 
		coin = PlayerPrefs.GetInt("coin"); 
		Speed = PlayerPrefs.GetInt ("Speed"); 
		acceleration = PlayerPrefs.GetInt ("Acceleration"); 
	}
	
	// Update is called once per frame
	void Update () {

		CoinText.text = " " + coin;
		speedText.text = " " + Speed ;
		AccelerationText.text = " " + acceleration ; 

		if (SpeedIncrease == true) {
			Speed = Speed + 1 ;  
			SpeedIncrease = false ; 
			PlayerPrefs.SetInt("Speed" , Speed) ; 
			PlayerPrefs.SetInt ("coin" , coin); 
		}

		if (AccelerationIncrease == true) {
			acceleration = acceleration + 1 ; 
			AccelerationIncrease = false ;  
			PlayerPrefs.SetInt("Acceleration" , acceleration) ;
			PlayerPrefs.SetInt ("coin" , coin); 
		}
	}

	public void Home(){
		Application.LoadLevel (0); 
	}

	public void PlayGame(){
		Application.LoadLevel (1); 
	}

	public void ClicPluskAccel(){
		if (coin >= 100) {
			coin = coin - 100; 
			AccelerationIncrease = true ; 
		} else {
			Debug.Log ("nothing Happen") ; 
		}
	}


	public void ClickPlusSpeed(){

		if (coin >= 100) {
			coin = coin - 100; 
			SpeedIncrease = true ; 
		} else {
			Debug.Log ("nothing happen") ; 
		}
	}

}
