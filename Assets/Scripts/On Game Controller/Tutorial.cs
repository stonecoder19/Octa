using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {
	//tutorial Gameobjects
	public GameObject stepText;
	public GameObject rotArrows;
	public GameObject pointerAnim;
	public Text pointerAnimText;
	public GameObject tutScreen;
	public GameObject instruct;
	public GameObject label;
	public GameObject skipButton;
	public GameObject backButton;
	public GameObject comments;

	//other game objects
	public Camera cam;
	public GameObject startMenu;
	public TowerProperties tower;
	public TowerHit hp;
	public TowerRotation tap;
	public ShieldCollision shield;
	public StartGame startGame;
	public GameObject projectile;
	public GameObject health;
	public int step = 1;
	public float delayTime = 1f;

	//private variables
	public float counter = 0f;
	private bool attack;
	private Vector3 pointerPos1,pointerPos2,arrowPos1,arrowPos2,center,labelPos,instructPos,projPos1,projPos2;
	private Animator rotateAnim;	
	private Vector3 tempVelocity = Vector3.zero;
	private GameObject tutorialProj = null;
	private GameObject tutorialheal = null;
	private Button skip,back;
	private bool passStep3 = false;
	private bool passStep4 = false;
	private ProjectileProperties projprop;
	private Color tempColor ;
	private Text CommentText;
	private bool returnToStep;


	void Awake(){
		rotateAnim = rotArrows.GetComponent<Animator> ();
		CommentText = comments.GetComponent<Text> ();
		tempColor = CommentText.color;
	}
	// Use this for initialization
	void Start () {
		startMenu.SetActive (false);
		ResetValues ();
		//set the default positions of the tutorial objects
		pointerPos1 = cam.WorldToScreenPoint (new Vector3 (5f, -1.5f, 0f));
		pointerPos2 = cam.WorldToScreenPoint (new Vector3 (-5f,-1.5f, 0f));
		center = cam.WorldToScreenPoint (new Vector3 (0f,0f,0f));
		labelPos = cam.WorldToScreenPoint (new Vector3(2f,4f,0f));
		instructPos = cam.WorldToScreenPoint (new Vector3(2.5f,-1f,0f));
		projPos1 = new Vector3 (2, 3.5f, 0);
		projPos2 = new Vector3 (2, 3.5f, 0);

		//skip button functionality
		skip = skipButton.GetComponent<Button> ();
		skip.onClick.AddListener(() => finished());
		back = backButton.GetComponent<Button> ();
		back.onClick.AddListener(() => MainMenu());

		rotArrows.transform.position = center;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			MainMenu();
		}
		switch (step) {
		case 1: StepOne();//tap right side of screen
			break;
		case 2: StepTwo();//tap left side of screen
			break;
		case 3: if(Delay(1.2f)){comments.SetActive(false);StepThree();}//block projectile
			break;
		case 4: if(Delay(1.2f)){comments.SetActive(false);StepFour();}//collect health
			break;
		case 5: if(Delay(1.2f)){comments.SetActive(false);StepFive();}//hint towards powerups
			break;
		case 6: finished();//start game animation
			break;
		default: break;
		}
	}

	void StepOne( )
	{
		stepText.GetComponent<Text> ().text = "Step " + step + "/4";
		pointerAnim.transform.position = pointerPos1;
		if(tap.touchRight && Delay(delayTime)){
			counter = 0f;
			step = 2;
		}
	}

	void StepTwo(){
		stepText.GetComponent<Text> ().text = "Step " + step + "/4";
		pointerAnimText.text = "tap\nto rotate\nanti-clockwise";
		rotateAnim.SetBool("anticlockwise",true);
		rotArrows.transform.localScale = new Vector3(1,-1,1);
		pointerAnim.transform.position = pointerPos2;
		if(tap.touchLeft && Delay(delayTime)){
			counter = 0f;
			step = 3;
			comments.SetActive (true);
		}
	}

	void StepThree(){
		stepText.GetComponent<Text> ().text = "Step " + step + "/4";//set text to display current step

		counter = 0f;//set delay counter to zero
		pointerAnim.SetActive (false);//disable previous step animation
		rotArrows.SetActive (false);//disable previous step animation
			
		tutorialProj = Instantiate (projectile, projPos1, Quaternion.identity) as GameObject;
		projprop = tutorialProj.GetComponent<ProjectileProperties> ();
		projprop.damage = 0;

		attack = true;			
		tutScreen.SetActive (true);
		Time.timeScale = 0f;

		label.transform.position = labelPos;
		instruct.transform.position = instructPos;

		if (attack) {
			StartCoroutine (stayFrozen ());		
		}

	}

	void StepFour(){
		if (Delay (4f) && shield.blocked) {
			counter = 0f;
			passStep3 = true;
		}
		if (Delay (8f) && !shield.blocked) {
			counter = 0f;
			CommentText.text = "Try Again :(";
			CommentText.color = Color.red;
			StartCoroutine(commentWait());
			step--;			
			Debug.Log("Try step 3 again");
		}		
		if (passStep3) {
			if(!returnToStep)
			{
				//Debug.Log("pass step 3");
				CommentText.text = "Good Job :)";
				CommentText.color = tempColor;
				StartCoroutine(commentWait());
			}
			stepText.GetComponent<Text> ().text = "Step " + step + "/4";
			counter = 0f;		

			tutorialheal = Instantiate(health,projPos2,Quaternion.identity) as GameObject;				

			attack = true;			
			tutScreen.SetActive(true);
			Time.timeScale = 0f;
						
			label.GetComponent<Text>().text = "good circle";
			label.GetComponent<Text>().color = Color.green;
			instruct.GetComponent<Text>().text = "collect circle with body of octa";
			
			if(attack)
			{
				StartCoroutine(stayFrozen());		
			}			
		}

	}

	void StepFive(){	
		if (Delay (4f) && hp.collect) {
			counter = 0f;
			passStep4 = true;
		}
		if (Delay (8f) && !hp.collect) {
			counter = 0f;
			CommentText.text = "Try Again :(";
			//Debug.Log("Try step 4 again");
			CommentText.color = Color.red;
			StartCoroutine(commentWait());
			returnToStep = true;
			step--;
		}
		if(passStep4){
			//Debug.Log("pass step 4");
			CommentText.text = "Good Job :)";
			CommentText.color = tempColor;
			StartCoroutine(commentWait());
			stepText.GetComponent<Text> ().text = "COMPLETED";
			counter = 0f;
			tutScreen.SetActive(true);
			Time.timeScale = 0f;
			label.SetActive(false);
			instruct.GetComponent<Text>().text = "Look out for \nother interesting\nthings to collect";			
			StartCoroutine(stayFrozen());
		}
	}

	void finished(){		
		//lets go animation and text
		//tap.enabled = false;
		PlayerPrefs.SetInt ("tutFin", 1);
		this.gameObject.SetActive(false);	
		tutScreen.SetActive(false);	
		Time.timeScale = 1f;
		step = 1;
		counter = 0f;
		startGame.startGame ();
		//Application.LoadLevel("GameScene");

	}

	void MainMenu(){	
		ResetValues ();	
		Destroy (tutorialProj);
		Destroy (tutorialheal);
		startMenu.SetActive(true);
		startGame.returnToMenu = true;
		this.gameObject.SetActive(false);
	}

	void ResetValues(){		
		comments.SetActive (false);
		tap.enabled = true;
		shield.blocked = false;
		pointerAnim.SetActive (true);
		pointerAnimText.text = "tap\nto rotate\nclockwise";
		rotArrows.SetActive (true);
		rotArrows.transform.localScale = new Vector3(1,1,1);
		pointerAnim.transform.position = pointerPos1;
		tap.touchLeft = false;
		tap.touchRight = false;
		tutScreen.SetActive(false);	
		step = 1;	
		counter = 0f;
		attack = false;
		passStep3 = false;
		passStep4 = false;
		returnToStep = false;
		Time.timeScale = 1f;

	}
	bool Delay(float time){
		counter += Time.deltaTime;//increment counter
		return counter > time;//return true when the counter has reached the desired time
	}

	IEnumerator commentWait()
	{
		comments.SetActive (true);   
		yield return StartCoroutine (WaitForRealSeconds (1.2f));		
		comments.SetActive (false);	
	}

	IEnumerator stayFrozen()    
	{   
		yield return StartCoroutine (WaitForRealSeconds(4f));	
		Time.timeScale = 1f; //unfreezes game
		
		tutScreen.SetActive(false);	
		step++;
	}
	
	IEnumerator WaitForRealSeconds (float waitTime) {
		float endTime = Time.realtimeSinceStartup+waitTime;
		
		while (Time.realtimeSinceStartup < endTime) {
			yield return null;
		}
	}
}
