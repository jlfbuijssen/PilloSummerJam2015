using UnityEngine;
using System.Collections;
using Pillo;

public class Hose : MonoBehaviour {

	public float turnSpeed = 1.0f;
	public float maxTurnAngle = 25.0f;
	public float addedPressure = 20.0f;
	public float pressureLoss = 1.0f;
	public float maxHeight = -50.0f;
	public float fireGrowRate = 1.0f;
	public float hoseStrength = 5.0f;

	public GameObject animState1;
	public GameObject animState2;
	public GameObject animState3;

	public float audioVolume = 0.5f;

	private float maxPressure = 100.0f;
	private GameObject water;
	private AudioSource sounds1;
	private AudioSource sounds2;


	private float turnDirection = 0.0f;
	private bool pumpPressed = false;
	private float pumpPressure = 0.0f;
	private float turnHeight = 0.0f;



	// Use this for initialization
	void Start () {

		water = GameObject.Find ("water1337");

		AudioSource[] allSounds = GetComponents<AudioSource>();

		sounds1 = allSounds[0];
		sounds1.volume = 1.0f;
		sounds1.Play ();

		sounds2 = allSounds[1];
		sounds2.volume = 0.0f;
		sounds2.Play ();
	
	}

	void Player1(){

		turnDirection = (Mathf.Round(((PilloController.GetSensor (PilloID.Pillo1) - 0.5f) * turnSpeed*Time.deltaTime)*10))/10;

		if ((this.transform.eulerAngles.y < maxTurnAngle || this.transform.eulerAngles.y > maxTurnAngle + 10.0f ) && turnDirection > 0.0f) {

			this.transform.Rotate (new Vector3 (0, turnDirection, 0));

		}

		if ((this.transform.eulerAngles.y > 360 - maxTurnAngle || this.transform.eulerAngles.y < 350- maxTurnAngle) && turnDirection < 0.0f) {

			this.transform.Rotate (new Vector3 (0, turnDirection, 0));

		}


	
	}

	void Player2(){

		if (animState2.activeSelf == true) {
		
			if(pumpPressed){
				animState3.SetActive(true);
			}
			else{
				animState1.SetActive(true);
			}

			animState2.SetActive(false);
		}

		//pump up
		if (PilloController.GetSensor (PilloID.Pillo2) == 0 && pumpPressed == true) {
		
			pumpPressed = false;

			animState3.SetActive(false);
			animState2.SetActive(true);
		
		}

		//pump down
		if (PilloController.GetSensor (PilloID.Pillo2) > 0 && pumpPressed == false) {
			
			pumpPressed = true;

			animState1.SetActive(false);
			animState2.SetActive(true);

			pumpPressure +=	addedPressure;

			if (pumpPressure > maxPressure){

				pumpPressure = maxPressure;

			}
		}

		//pressure down
		if (pumpPressure > 0) {

			pumpPressure -= pressureLoss*Time.deltaTime;

		}

		turnHeight = pumpPressure - 100*(water.transform.eulerAngles.x/maxHeight);

		water.transform.Rotate(new Vector3(turnHeight/(100/maxHeight), 0, 0));

		//sounds
		sounds1.volume = (1 - (pumpPressure / maxPressure))*audioVolume;
		sounds2.volume = (pumpPressure / maxPressure)*audioVolume;


	}


	
	// Update is called once per frame
	void Update () {

		Player1 ();
		
		Player2 ();
	
	}
}
