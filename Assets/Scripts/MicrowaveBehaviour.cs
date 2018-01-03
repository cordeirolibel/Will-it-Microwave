using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MicrowaveBehaviour : MonoBehaviour 
{
	public List<GameObject> objectsInMicrowave = new List<GameObject>();
	public List<GameObject> objectsNearMicrowave = new List<GameObject>();
	public List<string> objectsMicrowaved = new List<string>();
	int microwaved = 0;
	const int numObj = 8;

	public AudioSource[] audios; 

	public string scoreText;
	public string achTitle;
	public string achDesc;
	public bool showAchievement = false;

	public int achTimer = 0;

	public bool inst = true;

	private int repeat = 0;
	private float speed = 100.0f;
	private bool doorState = false;
	private int time = 0;

	private GameObject plate;
	private GameObject door;
	private GameObject uWave;
	private GameObject intlight;

    // Use this for initialization
    void Start () 
	{
		plate = GameObject.Find("Plate");
		door = GameObject.Find("Door");
		uWave = GameObject.Find("Microwave");
		intlight = GameObject.Find("IntLight");
		audios = GetComponents<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			inst = false;
		}

		if (Input.GetKeyUp (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		scoreText = microwaved + "/" + numObj;

		if(achTimer <= 0)
		{
			achTitle = "";
			achDesc = "";
			showAchievement = false;
		}
		else
		{
			achTimer--;
		}
		
		// ABERTO
        if ((door.transform.eulerAngles.y - uWave.transform.eulerAngles.y) > 10) {

			//Mudança de estado da porta
			if(doorState == false)
			{
				audios[1].Play();
			}


			// Animaçao de desaceleraçao
			if(repeat-- > 0)
			{
				speed -= 0.833f;
				plate.transform.RotateAround(plate.collider.bounds.center, Vector3.up, speed * Time.deltaTime);
			}

			// Desliga luz interna
			intlight.light.intensity = 0.0f;

			doorState = true;

			audios[3].Stop ();
		} 
		// FECHADO
		else 
		{
			//Mudança de estado da porta
			if(doorState == true)
			{
				audios[0].Play();
				audios[2].Play();
				time = 300; // 5 segundos
			}


			// Timer
			if(time > 0)
			{
				time--;
				//print("Time left: " + time);
			}
			else
			{
				int i;

				for(i = 0; i < objectsInMicrowave.Count; i++)
				{
					if(objectsInMicrowave[i].name == "cash")
					{
						audios[6].Play();

						objectsInMicrowave[i].rigidbody.useGravity = false;
						achTitle = "sdasa!";
						achDesc = "dasd";
						showAchievement = true;
						achTimer = 350;
					}
					else if(objectsInMicrowave[i].name == "knife_01")
					{
						audios[5].Play();
						objectsInMicrowave[i].rigidbody.AddForce(0,100.0f,-500.0f, ForceMode.Impulse);
						objectsInMicrowave[i].rigidbody.transform.eulerAngles.Set(270.0f, 360.0f, 0.0f);
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;

							achTitle = "Stab Stab Stab!";
							achDesc = "It was knife knowing you";
							showAchievement = true;
							achTimer = 350;
						}
					}
					else if(objectsInMicrowave[i].name == "LilMicrowave")
					{
						if(!audios[4].isPlaying)
							audios[4].Play();
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;

							GameObject exp = GameObject.Find("Exp");
							exp.transform.position = objectsInMicrowave[i].collider.bounds.center;
							exp.particleSystem.Play();

							achTitle = "Inception";
							achDesc = "A Microwave within a Microwave?\nAm I dreaming?";
							showAchievement = true;
							achTimer = 350;
						}

						//Explode
						Destroy(objectsInMicrowave[i]);
						objectsInMicrowave.RemoveAt(i);
					}
					else if(objectsInMicrowave[i].name == "nokia")
					{
						if(!audios[7].isPlaying)
							audios[7].Play();

						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;

							audios[9].Play();
							GameObject exp = GameObject.Find("Exp");
							exp.transform.position = objectsInMicrowave[i].collider.bounds.center;
							exp.particleSystem.Play();

							achTitle = "Indestructible";
							achDesc = "What did you expect?";
							showAchievement = true;
							achTimer = 350;
						}

					}
					else if(objectsInMicrowave[i].name == "goldbar")
					{

						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;

							if(!audios[8].isPlaying)
								audios[8].Play();
							
							achTitle = "Gold Digger";
							achDesc = "gib gold coins plox";
							showAchievement = true;
							achTimer = 350;
						}

						Destroy(objectsInMicrowave[i]);
						objectsInMicrowave.RemoveAt(i);

						GameObject coin = GameObject.Find("Coins");
						coin.transform.position = new Vector3(0.26f, 16.05f, 23.89f);										
					}
					else if(objectsInMicrowave[i].name == "Handy")
					{
						
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;
							
							achTitle = "Give me a hand!";
							achDesc = "hehe";
							showAchievement = true;
							achTimer = 350;					
						}
					}
					else if(objectsInMicrowave[i].name == "Clock")
					{
						
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;
							
							achTitle = "HAMMER TIME!";
							achDesc = "Can't touch this";

							GameObject hammer = GameObject.Find("hammer");
							hammer.transform.position = new Vector3(-3.47f, 27.62f, 23.97f);	

							showAchievement = true;
							achTimer = 350;		

							audios[9].Play();
							GameObject exp = GameObject.Find("Exp");
							exp.transform.position = objectsInMicrowave[i].collider.bounds.center;
							exp.particleSystem.Play();

							Destroy(objectsInMicrowave[i]);
							objectsInMicrowave.RemoveAt(i);
						}
					}
					else if(objectsInMicrowave[i].name == "bread")
					{
						
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;
							
							achTitle = "Gluten Nightmare";
							achDesc = "BEWARE";
							
							showAchievement = true;
							achTimer = 350;		

							//Destroy(objectsInMicrowave[i]);
							//objectsInMicrowave.RemoveAt(i);
						}

						objectsInMicrowave[i].transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
					}
					else if(objectsInMicrowave[i].name == "radio")
					{
						
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;
							
							achTitle = "MUTE";
							achDesc = "???";
							
							showAchievement = true;
							achTimer = 350;		
						}
						
						objectsInMicrowave[i].audio.pitch += Time.deltaTime * 0.2f;
						objectsInMicrowave[i].audio.dopplerLevel += Time.deltaTime * 0.2f;
						objectsInMicrowave[i].audio.volume += Time.deltaTime * 0.2f;

						if(objectsInMicrowave[i].audio.dopplerLevel > 2.6f)
						{
							audios[9].Play();
							GameObject exp = GameObject.Find("Exp");
							exp.transform.position = objectsInMicrowave[i].collider.bounds.center;
							exp.particleSystem.Play();

							Destroy(objectsInMicrowave[i]);
							objectsInMicrowave.RemoveAt(i);
						}
					}
					/*
					else if(objectsInMicrowave[i].name == "cheese")
					{
						
						if(!objectsMicrowaved.Contains(objectsInMicrowave[i].name))
						{
							objectsMicrowaved.Add(objectsInMicrowave[i].name);
							microwaved++;
							
							achTitle = "Sometimes I dream about cheese";
							achDesc = "Can't have enought of these...";
							
							showAchievement = true;
							achTimer = 350;		
						}
						Instantiate(objectsInMicrowave[i], objectsInMicrowave[i].transform.position + Vector3(8f,8f,8f), objectsInMicrowave[i].transform.rotation);
					}
					*/
				}
			}

			//audio loop
			if(!audios[3].isPlaying)
				audios[3].Play();

			// Liga a luz interna
			intlight.light.intensity = 3.0f;

			// Gira prato
			speed = 100.0f;
			repeat = 120;
			plate.transform.RotateAround(plate.collider.bounds.center, Vector3.up, speed * Time.deltaTime);
			doorState = false;
		}
	}
}
