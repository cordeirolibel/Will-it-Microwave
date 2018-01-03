using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateDescription : MonoBehaviour {

	Text desc;
	
	// Use this for initialization
	void Start () {
		desc = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		desc.text = GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().achDesc;
		if (GameObject.Find ("Microwave").GetComponent<MicrowaveBehaviour> ().showAchievement)
			desc.enabled = true;
		else
			desc.enabled = false;
			
	}
}
