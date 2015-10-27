using UnityEngine;
using System.Collections;

public class HandleCollision : MonoBehaviour {

	int counter;
	int timer;
	
	ParticleSystem particles;
	// Use this for initialization
	void Awake () {
		Debug.Log ("start");
		timer = 100;
		particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnParticleCollision(GameObject other) {
		Debug.Log ("hit");
		if (other.tag == "Player") {
			Debug.Log ("Player hit");
			counter++;
			if (counter > 10) {
				StartCoroutine("PauseThenRestart");
			}
			
		}
	}
	
	IEnumerator doRestart(float wait) {
		yield return new WaitForSeconds(wait);
		particles.Play();
	}
	
	
	IEnumerator PauseThenRestart() {
		particles.Clear();
		particles.Stop();
		yield return StartCoroutine(doRestart(3.0f));
		
	}
	
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log ("trigger");
	}
}
