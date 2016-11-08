using UnityEngine;
using System.Collections;

public class Spectrum: MonoBehaviour{
	
	//public GameObject prefab;
	public int numberOfObjects = 4;
	//public float radius = 5f;
	private GameObject[] cubes;

	void Start(){

		/*for(int i=0;i<numberOfObjects;i++){

			float angle = i*Mathf.PI*2/numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle))*radius;
			Instantiate(prefab,pos,Quaternion.identity);
		}*/

		cubes = GameObject.FindGameObjectsWithTag("bars");

	}

	void Update(){
		float[] spectrum = AudioListener.GetSpectrumData(1024,0,FFTWindow.Hamming);
		for(int i =0;i<numberOfObjects;i++){
			Vector3 previousScale = cubes[i].transform.localScale;
			previousScale.y = Mathf.Lerp(previousScale.y,spectrum[i]*20,Time.deltaTime*30);
			cubes[i].transform.localScale = previousScale;
		}

	}
}
