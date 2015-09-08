
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
	public GameObject DeadPlayer ; 
	public GameObject BOOM ; 

	private float spawnTimeControl , FlyUp  , currentspawnTimeLeft , spawnTimeTemp , RandomY , goingRight;
	private bool GoDown ; 
	private int MinAmount ,timer ; 
	private GameObject FlyingObstacle , FlyingRocket; 

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f; 
		GoDown = true ; 
		FlyUp = 0.0f;
		MinAmount = 1	; 
		score = 0 ; 
		Gameover = false;  
		restarttimer = false; 
		SpawnRocket = false; 

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

			if (Player.transform.position.y < -2.9f || Player.transform.position.x < -1.875f) {
				Gameover = true;  
			}
		
			if (Player.transform.position.y >= 1.49f) {
				Player.transform.position = new Vector2 (Player.transform.position.x, 1.49f); 
			}
		
			if (Gameover == true) {
				BOOM.transform.position = new Vector2 (Player.gameObject.transform.position.x, Player.gameObject.transform.position.y); 
				DeadPlayerAnimation.gameObject.transform.position = new Vector2 (Player.gameObject.transform.position.x, Player.gameObject.transform.position.y);
				Player.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0); 
			
			}
		}
	}

	 

	void PlayerInput(){
		//control up and down 
		if (Input.GetMouseButtonDown (0)) {
			GoDown = false;	
		}
		
		if (Input.GetMouseButtonUp (0)) {
			GoDown = true ;  
			//acceleration
			FlyUp = 0.00f ;
		}
		
		if (GoDown == false) {
			Player.transform.Translate(0 , FlyUp * Time.deltaTime , 0 ) ; 
		} else {
			Player.transform.Translate(0 , -0.05f , 0  ) ; 
		}
		
		if (FlyUp < 3.0f) {
			FlyUp = FlyUp + 0.5f; 
		} else {
			FlyUp = 3.0f ; 
		}

		//save for being push 
		goingRight = 0.6f * Time.deltaTime; 
		
		if (Player.transform.position.x < 0) {
			Player.transform.Translate (goingRight, 0, 0);
		}
		
		if (Player.transform.position.x > 0) {
			this.Player.transform.position = Player.transform.position ;   
		}

	}

	void SpawnWave(){

		
		currentspawnTimeLeft = Time.time - spawnTimeTemp; 

		spawnTimeControl = 0.7f; 

		if (currentspawnTimeLeft >= spawnTimeControl) {
			for (int i = 0; i < MinAmount; i++) {
				if (i < MinAmount) {
					float RandomY = Random.Range (-1.99f , 1.24f); 
					FlyingObstacle = (GameObject)Instantiate ( Enemy, new Vector3 (1.96f, RandomY , 0), Quaternion.identity); 
				}
			}
			spawnTimeTemp = Time.time ; 
			currentspawnTimeLeft = 0 ; 
		}
	}
}
