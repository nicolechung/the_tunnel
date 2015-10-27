using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	// This script gets the particle to move in the direction
	// of a target that I set up behind / around the camera
	GameObject playerTarget;
	SpawnParticles spawner;
	GameObject spawnSphere;
	PlayerHealth playerHealth;
	PlayerScore playerScore;
	
	public float speed = 5.0f;
	
	float count = 0;
	
	bool turnedOn = false;
	int damage = 10;
	int score = 0;
	
	public int life = 500;
	
	
	// Use this for initialization
	void Awake () {
		playerTarget = GameObject.Find ("PlayerTarget");
		playerHealth = (PlayerHealth) playerTarget.GetComponent(typeof(PlayerHealth));
		playerScore = (PlayerScore) playerTarget.GetComponent (typeof (PlayerScore));
		spawnSphere = GameObject.Find ("Spawner Sphere");
		spawner = (SpawnParticles) spawnSphere.GetComponent(typeof(SpawnParticles));		
	}
	
	public void TurnOn() 
	{
		turnedOn = true;
	}	
	
	public void TurnOff()
	{
		turnedOn = false;
	}
	
	private bool IsHand(Collider other) {
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
		{
			return true;
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (playerTarget.transform);
		transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position, Time.deltaTime);
		if (transform.position.z < -12) {
			gameObject.SetActive(false);
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		life--;
		if (life <= 0) {
			gameObject.SetActive(false);
			gameObject.GetComponent<Renderer>().enabled = false;
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if (turnedOn == true) {
			if (collision.collider.tag == "Player") {
				GameObject.Find("HurtAudioSource").GetComponent<AudioSource>().Play();
				gameObject.SetActive(false);
				gameObject.GetComponent<Renderer>().enabled = false;
				count++;
				playerHealth.TakeDamage(damage);
				
			}
			
			if (IsHand (collision.collider)) {
				GameObject.Find("ZapAudioSource").GetComponent<AudioSource>().Play();
				gameObject.SetActive(false);
				gameObject.GetComponent<Renderer>().enabled = false;
				count++;
				playerScore.IncreaseScore();
			}
			
			if (collision.collider.tag == "Respawn" || collision.collider.tag == "Background") 
			{
				Debug.Log ("respawn");
				Debug.Log (gameObject);
				gameObject.SetActive(false);
				gameObject.GetComponent<Renderer>().enabled = false;
			}
			
			if (count % 5 == 0) {
				spawner.spawnTime -= 0.2f;
//				Debug.Log ("---spawn time change---");
//				Debug.Log (spawner.spawnTime);
				if (spawner.spawnTime == 0) {
					spawner.spawnTime = 2.0f;
				}
			}
		}
			
		
	}
}
