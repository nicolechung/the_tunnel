using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public Text playerScore;
	int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void IncreaseScore()
	{
		score++;
		playerScore.text = score.ToString();
	}
	
	public void ResetScore() {
		score = 0;
		playerScore.text = score.ToString();
	}
}
