using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public GameObject waveanim;
	public float waveTime = 4f;
	public float tempTime = 0f;

	public void wave()
	{
		waveanim.SetActive (true);
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<GameOver> ().gameOver) {
			waveanim.SetActive(false);
		}
		if (waveanim.activeInHierarchy) {
			if (tempTime <= waveTime) {
				tempTime+=Time.deltaTime;
			}
			else{
				waveanim.SetActive(false);
				tempTime = 0;
			}
		}
	}

}
