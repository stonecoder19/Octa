using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {


	public TowerProperties tower;//properties of the tower
	public Slider slider;//slider object representing health
	public Image Fill;  //fill component of the slider
	public Color MaxHealthColor = Color.green;
	public Color MinHealthColor = Color.red;	
	public int MaxHealth = 30;
	
	private void Start() {
		slider.wholeNumbers = true;// I dont want 3.543 Health but 3 or 4
		slider.minValue = 0f;
		slider.maxValue = MaxHealth;
		slider.value = MaxHealth;// start with full health
	}
	
	private void FixedUpdate() {
		UpdateHealthBar(tower.health);//represent the current health on the slider
	}
	
	public void UpdateHealthBar(float val) {
		slider.value = val;//set the slider value to the tower health
		Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)val / MaxHealth);//gradually change color
	}
}
