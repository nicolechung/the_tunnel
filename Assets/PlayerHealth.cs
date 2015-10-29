using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public AudioSource deathClip;
	public AudioSource hurtClip;
	public Canvas gameOver;
	public Canvas HUD;
	public GameObject damage;
	Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, .99f);	
	bool isDead;
	bool damaged;
	
	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
		damageImage = damage.GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			// transition the colour back to clear
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			
		}
		
		damaged = false;
	}
	
	public void TakeDamage (int amount) 
	{
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		hurtClip.Play ();
		
		if (currentHealth <= 0 && !isDead) 
		{
			Death();
		}
	}
	
	void Death(){
		isDead = true;
		
		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		
		// play hurt sound
		deathClip.Play();
		
		StopGame();
	}
	
	public void RestartGame() {
		HUD.enabled = true;
		gameOver.enabled = false;
		currentHealth = startingHealth;
		isDead = false;
	}
	
	void StopGame() {
		gameOver.enabled = true;
		HUD.enabled = false;
		GameObject playerTarget = GameObject.Find ("PlayerTarget");
		PlayerScore playerScore = (PlayerScore) playerTarget.GetComponent (typeof (PlayerScore));
		playerScore.ResetScore();
		/* Remove Particles */
		GameObject[] particles = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject particle in particles) {
			Destroy(particle);
		}
	}
}
