using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class update : MonoBehaviour {

	Text tex;
	
	// Use this for initialization
	void Start () {
		tex = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().inst) {
			tex.text = "";
		}
	}
}
