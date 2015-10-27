using UnityEngine;
using System.Collections;
using System.Collections.Generic; // lets you access List

public class SpawnParticles : MonoBehaviour {

	// put this script on a game object with a sphere collider, and make the sphere collider kinda big
	SphereCollider spawnTrigger;
	
	// let's make this an object pool so I don't drive myself
	// fucking totally crazy
	public GameObject particle; // really whatever prefab I've made
	public float spawnTime = 2.0f;
	
	public int pooledAmount = 10;
	List<GameObject> particles;
	
	
	// Use this for initialization
	void Start () {
		particles = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject)Instantiate (particle);
			obj.SetActive (false);
			particles.Add(obj);
		}
		spawnTrigger = GetComponent<SphereCollider>();
		
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn() {
		for (int i = 0; i < particles.Count; i++) 
		{
			if (particles[i] != null && !particles[i].activeInHierarchy)
			{
				Vector3 spawnPosition;
				Vector3 randomPosition;
				if (spawnTrigger) {
					randomPosition = Random.insideUnitSphere * spawnTrigger.radius;
					spawnPosition = new Vector3(randomPosition.x, randomPosition.y, -1);
					particles[i].transform.position = spawnPosition;
					particles[i].transform.rotation = Quaternion.identity;
				} else {
					particles[i].transform.position = transform.position;
					particles[i].transform.rotation = transform.rotation;
				}
				
				particles[i].SetActive(true);
				particles[i].GetComponent<Renderer>().enabled = true;
				ParticleScript script = (ParticleScript) particles[i].GetComponent(typeof (ParticleScript));
				script.life = 500;
				break;
			}
		}
	}
	
	public void Pause()
	{
		spawnTime = 1000f;
		Invoke("Restart", 5);
	}
	
	public void Restart()
	{
		spawnTime = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
