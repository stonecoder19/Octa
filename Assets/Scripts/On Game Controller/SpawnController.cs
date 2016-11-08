using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {
	public GameObject[] spawnSpots;//array of points for spawning projectiles
	public GameObject[] projectiles;//projectile to be spawned
	List<GameObject>projectileList;
	public GameObject[] powerUps;//powerups to be spawned
	public GameOver game;//
	public float spawnDelay=1f;//time before spawn
	public float maxSpeed = 5.5f;//fastest projectile can go

	private int ran;//random value to select spawn spot
	public bool isPowerUp = false;
	public bool isHealth = false;
	public float speed = 1f;//speed of current projectile
	public float spawnWait;//time between each spawn
	public float gameTime = 0f;
	private Vector3[] spawnPositions;
	public GameObject superShield;
	public bool freeze = false;
	private float tempGameTime;
	private float healthTimer = 0f;
	public float healthTime = 6f;

	// Use this for initialization
	void Start () {

		projectileList = new List<GameObject> ();

		for (int i =0; i<projectiles.Length; i++) {

			GameObject proj = (GameObject)Instantiate(projectiles[i]);
			proj.SetActive(false);
			projectileList.Add(proj);

		}
		
		StartCoroutine(spawnProjectiles());
		///setUpSpawnPoints ();
	}
	
	// Update is called once per frame
	void Update () {
		gameTime+= Time.deltaTime;
		healthTimer += Time.deltaTime;
		if (gameTime >= 10f) {
			if (healthTimer >= healthTime) {
				isHealth = true;

			}
		}
	

	}
	IEnumerator spawnProjectiles(){
		yield return new WaitForSeconds (spawnDelay); 
		while (!game.gameOver) {
			spawnWait = calcSpawnWait ();
			speed = calcDifficultySpeed ();
			GameObject projectile = null;
				
			if(!isPowerUp){
				//Debug.Log("Spawning");
					/*GameObject tempProj = projectiles [Random.Range (0, projectiles.Length)];
					if(tempProj.tag == "Health" && superShield.activeInHierarchy){
						tempProj = projectiles[0];
					}
					
					projectile = (Instantiate (tempProj,
				                        spawnSpots [Random.Range (0, spawnSpots.Length)].transform.position,
				                        Quaternion.identity)) as GameObject;*/

					for(int i=0;i<projectileList.Count;i++){
					if(projectileList[i]!=null){
						if(isHealth){
							if(projectileList[i].tag == "Health"){
								projectile = projectileList[i];
								projectileList[i].transform.position = spawnSpots [Random.Range (0, spawnSpots.Length)].transform.position;
								projectileList[i].transform.rotation = Quaternion.identity;
								projectileList[i].SetActive(true);
								isHealth = false;
								healthTimer = 0f;
								break;
							}


						}else{
							if(!projectileList[i].activeInHierarchy){
									projectileList[i].transform.position = spawnSpots [Random.Range (0, spawnSpots.Length)].transform.position;
									projectileList[i].transform.rotation = Quaternion.identity;
									projectileList[i].SetActive(true);
									projectile = projectileList[i];
									break;
								
							}
						}
					}

					}
			}
				else{
					projectile = (Instantiate (powerUps [Random.Range (0, powerUps.Length)],
					                    spawnSpots [Random.Range (0, spawnSpots.Length)].transform.position,
					                    Quaternion.identity)) as GameObject;
					isPowerUp = false;//wait for next powerup time
				}
		
				FollowTower followTower = projectile.GetComponent<FollowTower> ();
				if (followTower != null) {
					//if(!freeze){
						
						followTower.setFollowSpeed (speed); //sets speed of projectiles
					//}else{
					///	followTower.setFollowSpeed (1.5f);
					//}
				
				}
			
				yield return new WaitForSeconds (spawnWait); //time delay before spawning orojectile			
			}	

	}


	float calcDifficultySpeed(){		
		if(gameTime>=10)
			//speed = Mathf.Log((gameTime/10),2)*2 + 1; //logarithmic increase in speed
		  //   if(speed<=maxSpeed){
			 	speed = (gameTime/14f)+0.5f;
		//	}else{
		//		speed = Mathf.Log((gameTime/10),2)*2 + 1;
				//speed = (gameTime/15f)+2.5f;
		//	}
		//}
		//return speed;
		return speed>=maxSpeed?maxSpeed:speed;
	}

	float calcSpawnWait(){
		if (gameTime < 20f) {
			return 1.5f;
		} else {
			return 1.5f - Mathf.Clamp((1.5f*(1-(1/(gameTime/20)))),0,1.0f);
		}
	}

	/*void setUpSpawnPoints(){
		Vector3 centre = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width / 2, Screen.height / 2, 0f));
		Vector3 vertoffset = Camera.main.ScreenToWorldPoint(new Vector3 (0f, Screen.width / 2, 0f));
		Vector3 swOffset = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width / 2, 0f, 0f));
		Vector3 spawnSpot1 = centre + vertoffset;
		Vector3 spawnSpot2 = spawnSpot1 + swOffset;
		Vector3 spawnSpot3 = centre + swOffset;
		Vector3 spawnSpot4 = spawnSpot3 - vertoffset;
		Vector3 spawnSpot5 = centre - vertoffset;
		Vector3 spawnSpot6 = spawnSpot5 - swOffset;
		Vector3 spawnSpot7 = centre - swOffset;
		Vector3 spawnSpot8 = spawnSpot7 + vertoffset;

		spawnPositions = new Vector3[] {spawnSpot1,spawnSpot2,spawnSpot3,spawnSpot4,spawnSpot5,spawnSpot6,spawnSpot7,spawnSpot8};



	}*/


	
}
