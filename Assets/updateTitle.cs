using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateTitle : MonoBehaviour {

	Text title;
	
	// Use this for initialization
	void Start () {
		title = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		title.text = GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achTitle;
		if (GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().showAchievement)
			title.enabled = true;
		else
			title.enabled = false;

	}
}
