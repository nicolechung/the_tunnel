using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Button playText;
	public Canvas gameOver;
	public Canvas startMenu;
	public Canvas HUD;
	public GameObject[] particles;
	public GameObject spawner;
	public SpawnParticles spawnerScript;
	
	HandleCollision handleCollision;

	
	// Use this for initialization
	void Start () {
		PauseGameMechanic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void PauseGameMechanic()
	{
		gameOver.enabled = false;
		HUD.enabled = false;
		/* Game Objects */
		handleCollision = GameObject.Find ("HandController").GetComponent<HandleCollision>();
		handleCollision.enabled = false;
		particles = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject particle in particles) {
			particle.GetComponent<ParticleScript>().TurnOff ();
		}
	}
	
	void ResumeGameMechanic()
	{
		handleCollision.enabled = true;
		startMenu.enabled = false;
		particles = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject particle in particles) {
			particle.GetComponent<ParticleScript>().TurnOn ();
		}
		spawner = GameObject.Find ("Spawner Sphere");
		spawnerScript = (SpawnParticles) spawner.GetComponent(typeof(SpawnParticles));
		spawnerScript.Pause ();
		GameObject playerTarget = GameObject.Find ("PlayerTarget");
		PlayerHealth playerHealth = (PlayerHealth) playerTarget.GetComponent (typeof (PlayerHealth));
		playerHealth.RestartGame();
	}
	
	public void StartGame() 
	{
		ResumeGameMechanic();
	}
}
