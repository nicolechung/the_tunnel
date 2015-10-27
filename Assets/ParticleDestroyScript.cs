using UnityEngine;
using System.Collections;

public class ParticleDestroyScript : MonoBehaviour {

	void onEnable()
	{
		Invoke ("Destroy", 2.0f);
	}
	
	void Destroy() 
	{
		gameObject.SetActive (false);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
}
