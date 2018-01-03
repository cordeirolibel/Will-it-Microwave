using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	AudioSource audio3;
	// Use this for initialization
	void Start () {
		audio3 = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision ){
		audio3.pitch = (Random.Range(0.8f, 1.2f));
		if (collision.relativeVelocity.magnitude > 5) {
			audio3.Play ();
		}
	}
}
