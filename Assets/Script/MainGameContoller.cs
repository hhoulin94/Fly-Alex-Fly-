
using UnityEngine;
using System.Collections;

public class MainGameContoller : MonoBehaviour {

	public GameObject Player ; 
	public GameObject Enemy ; 
	public bool Gameover ; 
	public bool SpawnRocket ; 
	public bool restarttimer ; 
	public int score , RocketBoom; 
	public GameObject Rocket ; 
	public GameObject DeadPlayerAnimation ; 

	private float spawnTimeControl , FlyUp  , currentspawnTimeLeft , spawnTimeTemp , RandomY , goingRight;
	private bool GoDown , countcoin; 
	private int MinAmount ,timer , acceleration , speed , DeAcceleration ; 
	private GameObject FlyingObstacle , FlyingRocket; 
	private int coin ; 
	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f; 
		GoDown = true ; 
		FlyUp = 0.0f;
		MinAmount = 1	; 
		//score = 100 ; 
		Gameover = false;  
		restarttimer = false; 
		SpawnRocket = false;  
		countcoin = false; 

		acceleration = PlayerPrefs.GetInt ("Acceleration");
		speed = PlayerPrefs.GetInt ("Speed");
		DeAcceleration = PlayerPrefs.GetInt ("DeAcceleration");

		//Debug.Log (acceleration);
		//Debug.Log (speed); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Gameover == false) {
			PlayerInput (); 

			SpawnWave (); 

			if (restarttimer == true) {
				timer = 300;  
				restarttimer = false; 
			} else {
				timer--;
			}

			if (timer < 0) {
				SpawnRocket = true; 
				restarttimer = true; 
			}

			if (Player.transform.position.y < -3f || Player.transform.position.x < -4.968f) {
				Gameover = true;
				countcoin = true ; 
			}
		
			if (Player.transform.position.y >= 1.261f) {
				Player.transform.position = new Vector2 (Player.transform.position.x, 1.26f); 
			}
		}


		if (Gameover == true) { 
			DeadPlayerAnimation.gameObject.transform.position = new Vector2 (Player.gameObject.transform.position.x, Player.gameObject.transform.position.y);
			Player.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0); 
		}


		if (countcoin == true) {
			coin = PlayerPrefs.GetInt("coin") ; 
			coin = score + coin ;
			PlayerPrefs.SetInt ("coin" , coin);  
			countcoin = false ; 
		}

	}

	 

	void PlayerInput(){
		//control up and down 
		if (Input.GetMouseButtonDown (0)) {
			GoDown = false;	
			Player.GetComponent<AudioSource>().Play() ; 
		}
		
		if (Input.GetMouseButtonUp (0)) {
			GoDown = true ;  
			//acceleration
			FlyUp = 0.00f ; 
		}
		
		if (GoDown == false) {
			Player.transform.Translate(0 ,  FlyUp * Time.deltaTime , 0 ) ; 
		} else {
			float goingdown = 0.05f + (DeAcceleration/100) ;
			Debug.Log (goingdown) ; 
			if(goingdown > -0.09f){
				Player.transform.Translate(0 , -0.09f , 0  ) ;
			}else{
				Player.transform.Translate(0 , -goingdown , 0) ; 
			}
			 
		}
		
		if (FlyUp < 4.0f + (acceleration/100)) {
			FlyUp = FlyUp + 0.5f + (acceleration/100) ; 
		} else {
			FlyUp = 3.0f ; 
		}

		//save for being push 
		goingRight = (0.6f * Time.deltaTime) + (speed/100) ; 
		
		if (Player.transform.position.x < 0) {
			Player.transform.Translate (goingRight, 0, 0);
		}
		
		if (Player.transform.position.x > 0) {
			this.Player.transform.position = Player.transform.position ;   
		}

	}

	void SpawnWave(){

		
		currentspawnTimeLeft = Time.time - spawnTimeTemp; 

		if (score <= 15 && score >= 0) {
			spawnTimeControl = 0.7f; 
		}else if(score >= 16 && score <= 30) {
			spawnTimeControl = 0.6f ; 
		}else if(score >= 31 && score <= 45){
			spawnTimeControl = 0.5f ; 
		}else if(score >= 46 && score <= 60) {
			spawnTimeControl = 0.4f ; 
		}else if(score >= 61) {
			spawnTimeControl = 0.3f ; 
		}

		if (currentspawnTimeLeft >= spawnTimeControl) {
			for (int i = 0; i < MinAmount; i++) {
				if (i < MinAmount) {
					float RandomY = Random.Range (-1.771f , 0.849f); 
					FlyingObstacle = (GameObject)Instantiate ( Enemy, new Vector3 (4.96f, RandomY , 0), Quaternion.identity); 
				}
			}
			spawnTimeTemp = Time.time ; 
			currentspawnTimeLeft = 0 ; 
		}
	}
}
