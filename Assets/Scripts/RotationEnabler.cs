using UnityEngine;
using System.Collections;

public class RotationEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{   
		if (other.gameObject.tag == "Thing") {

			if (!GameObject.Find("Microwave").GetComponent<MicrowaveBehaviour>().objectsInMicrowave.Contains(other.gameObject)) {
				GameObject.Find("Microwave").GetComponent<MicrowaveBehaviour>().objectsNearMicrowave.Remove(other.gameObject);
				other.transform.parent = GameObject.Find("parentMePlate").transform.parent;
				other.gameObject.transform.localScale += new Vector3(0.00001f, 0, 0);
				other.gameObject.transform.localScale -= new Vector3(0.00001f, 0, 0);
				GameObject.Find("Microwave").GetComponent<MicrowaveBehaviour>().objectsInMicrowave.Add(other.gameObject);
				//print ("Object " + other.gameObject.name + " added to list!");
			}
		}
	}
}
