using UnityEngine;
using System.Collections;

public class cakeIsALie : MonoBehaviour {
	bool done = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (!done) {
			done = true;
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achTitle = "The cake is...";
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achDesc = "...a lie";
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().showAchievement = true;
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achTimer = 350;
		}
	}
}
