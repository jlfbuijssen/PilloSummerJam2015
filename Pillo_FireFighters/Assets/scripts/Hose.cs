using UnityEngine;
using System.Collections;
using Pillo;

public class Hose : MonoBehaviour {

	public float turnSpeed = 1.0f;
	public float maxTurnAngle = 25.0f;
	public float addedPressure = 20.0f;
	public float pressureLoss = 1.0f;
	public float maxHeight = -50.0f;
	public GameObject water;

	private float maxPressure = 100.0f;


	private float turnDirection = 0.0f;
	private bool pumpPressed = false;
	private float pumpPressure = 0.0f;
	private float turnHeight = 0.0f;



	// Use this for initialization
	void Start () {
	
	}

	void Player1(){


		turnDirection = (Mathf.Round(((PilloController.GetSensor (PilloID.Pillo1) - 0.5f) * turnSpeed)*10))/10;

		if ((this.transform.eulerAngles.y < maxTurnAngle || this.transform.eulerAngles.y > maxTurnAngle + 10.0f ) && turnDirection > 0.0f) {

			this.transform.Rotate (new Vector3 (0, turnDirection, 0));

		}

		if ((this.transform.eulerAngles.y > 360 - maxTurnAngle || this.transform.eulerAngles.y < 350- maxTurnAngle) && turnDirection < 0.0f) {

			this.transform.Rotate (new Vector3 (0, turnDirection, 0));

		}
	
	}

	void Player2(){

		//pump up
		if (PilloController.GetSensor (PilloID.Pillo2) == 0 && pumpPressed == true) {
		
			pumpPressed = false;
		
		}

		//pump down
		if (PilloController.GetSensor (PilloID.Pillo2) > 0 && pumpPressed == false) {
			
			pumpPressed = true;

			pumpPressure +=	addedPressure;

			if (pumpPressure > maxPressure){

				pumpPressure = maxPressure;

			}
		}

		//pressure down
		if (pumpPressure > 0) {

			pumpPressure -= pressureLoss;

		}

		turnHeight = pumpPressure - 100*(water.transform.eulerAngles.x/maxHeight);

		print (turnHeight);

		water.transform.Rotate(new Vector3(turnHeight/(100/maxHeight), 0, 0));


	}

	
	// Update is called once per frame
	void Update () {

		Player1 ();
		
		Player2 ();
	
	}
}
