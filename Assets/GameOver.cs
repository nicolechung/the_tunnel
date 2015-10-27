using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Button restart;
	public Button exit;
	public Canvas gameOver;
	public Canvas startMenu;
	public Canvas HUD;
	
	
	GameObject[] particles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Restart()
	{
		startMenu.enabled = false;
		particles = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject particle in particles) {
			particle.GetComponent<ParticleScript>().TurnOn ();
		}
		
		GameObject playerTarget = GameObject.Find ("PlayerTarget");
		PlayerHealth playerHealth = (PlayerHealth) playerTarget.GetComponent(typeof(PlayerHealth));
		playerHealth.RestartGame();
	}
	
	public void Exit()
	{
		startMenu.enabled = true;
		particles = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject particle in particles) {
			particle.GetComponent<ParticleScript>().TurnOff ();
		}
		gameOver.enabled = false;
		HUD.enabled = false;
		
	}
}
