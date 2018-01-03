using UnityEngine;
using System.Collections;

public class CerealSound : MonoBehaviour {
	AudioSource audio2;
	// Use this for initialization
	void Start () {
		audio2 = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		audio2.pitch = (Random.Range(0.8f, 1.2f));
		if (rigidbody.velocity.magnitude > 20) {
			if(!audio2.isPlaying)
				audio2.Play ();
		}
	}
	
	void OnCollisionEnter(Collision collision ){
		audio2.pitch = (Random.Range(0.8f, 1.2f));
		if (collision.relativeVelocity.magnitude > 5) 
		audio2.Play ();
	}
}
