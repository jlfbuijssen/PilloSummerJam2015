using UnityEngine;
using System.Collections;
using Pillo;

public class Hose : MonoBehaviour {

	public float turnSpeed = 1.0f;

	private float turnDirection = 0.0f;
	private bool pumpPressed = false;


	// Use this for initialization
	void Start () {
	
	}

	void Player1(){


		turnDirection = (Mathf.Round(((PilloController.GetSensor (PilloID.Pillo1) - 0.5f) * turnSpeed)*10))/10;

		this.transform.Rotate (new Vector3 (0, turnDirection, 0));
	
	}

	void Player2(){
		if (PilloController.GetSensor (PilloID.Pillo2) == 0) {
		

		
		}
	}

	
	// Update is called once per frame
	void Update () {

		Player1 ();
		
	
	
	}
}
