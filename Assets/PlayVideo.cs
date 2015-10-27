using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movie;
	public MovieTexture flash;
	
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = movie;
		movie.loop = true;
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Resume() {
		
	}
	
	public void Damage() {
	}
}
