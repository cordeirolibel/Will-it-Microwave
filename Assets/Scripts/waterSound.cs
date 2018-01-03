using UnityEngine;
using System.Collections;

public class waterSound : MonoBehaviour {
	bool oneTime = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		audio.pitch = (Random.Range(0.8f, 1.2f));
		audio.Play();

		if (other.gameObject.name == "cash" && !oneTime) {
			oneTime = true;
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achTitle = "Money Laundry";
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achDesc = "Literally";
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().showAchievement = true;
			GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achTimer = 350;
		}
		float force =  other.gameObject.transform.position.y - transform.position.y;
		other.gameObject.rigidbody.AddForce(0,force*3,0, ForceMode.VelocityChange);
	}
}
