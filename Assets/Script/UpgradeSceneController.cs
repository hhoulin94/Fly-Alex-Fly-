using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeSceneController : MonoBehaviour {

	public Text speedText ; 
	public Text CoinText ; 
	public Text AccelerationText ; 
	public Text DeAccelText ; 

	private int coin ;

	private int SpeedScore , AccelerationScore , DeAccelScore ;
	private int Speed , acceleration , DeAcceleration ; 
	private bool SpeedIncrease , AccelerationIncrease , DeaccelerationIncrease; 

	// Use this for initialization
	void Start () {
		//coin = PlayerPrefs.GetInt ("coin"); 
		//speedText.text = " " + Speed ; 
		SpeedIncrease = false; 
		AccelerationIncrease = false; 
		coin = PlayerPrefs.GetInt("coin"); 
		Speed = PlayerPrefs.GetInt ("Speed"); 
		acceleration = PlayerPrefs.GetInt ("Acceleration"); 
		DeAcceleration = PlayerPrefs.GetInt ("DeAcceleration"); 
	}
	
	// Update is called once per frame
	void Update () {

		CoinText.text = " " + coin;
		speedText.text = " " + Speed ;
		AccelerationText.text = " " + acceleration ; 
		DeAccelText.text = " " + DeAcceleration; 

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

		if (DeaccelerationIncrease == true) {
			DeAcceleration = DeAcceleration + 1 ; 
			DeaccelerationIncrease = false ;  
			PlayerPrefs.SetInt("DeAcceleration", DeAcceleration) ;
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

	public void ClickPlusDeAccel(){
		
		if (coin >= 100) {
			coin = coin - 100; 
			DeaccelerationIncrease = true ; 
		} else {
			Debug.Log ("nothing happen") ; 
		}
	}

}
