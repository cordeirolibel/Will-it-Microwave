using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateScore : MonoBehaviour {

	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().scoreText;
	}
}
