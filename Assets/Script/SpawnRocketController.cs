using UnityEngine;
using System.Collections;

public class SpawnRocketController : MonoBehaviour {

	public GameObject Rocket ; 

	private GameObject FlyingRocket ; 
	private float spawnTimeControl, currentspawnTimeLeft, spawnTimeTemp, goleft ;
	private int MinAmount; 
	private float RandomY ; 
	// Use this for initialization
	void Start () {
		MinAmount = 1; 
	}
	
	// Update is called once per frame
	void Update () {

		if (Camera.main.GetComponent<MainGameContoller> ().SpawnRocket == true) {
			RandomY = Random.Range (-1.99f , 1.24f);
			SpawnRocket (); 
			Camera.main.GetComponent<MainGameContoller> ().SpawnRocket = false; 
		}
	}

	void SpawnRocket(){
		currentspawnTimeLeft = Time.time - spawnTimeTemp; 

		spawnTimeControl = 0.1f; 
		
		if (currentspawnTimeLeft >= spawnTimeControl) {
			for (int i = 0; i < MinAmount; i++) {
				if (i < MinAmount) { 
					FlyingRocket = (GameObject) Instantiate (Rocket, new Vector3 (1.96f, RandomY , 0), Quaternion.identity); 
				}
			}
			spawnTimeTemp = Time.time ; 
			currentspawnTimeLeft = 0 ; 
		}
	}
}
