using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

	public bool raining = false;
	public float spreadTimer = 10;
	public float elapsedTime;
	public GameObject[] window;

	// public constants
	public static bool RANDOM = true;
	public static float MAX_RUN_TIME;
//	public static int WINDOW_ROWS = 3;
//	public static int WINDOW_COLUMNS = 4;
	public static int INIT_SPREAD_DELAY = 0;
	public static int SPREAD_TIMER_RATE = 10;




	// Use this for initialization
	void Start () {
//		window[0][0];
//		window[1][0];
//		window[2][0];
//		window[3][0];
//		window[0][1];
//		window[1][1];
//		window[2][1];
//		window[3][1];
//		window[0][1];
//		window[1][1];
//		window[2][1];
//		window[3][1];
		window = GameObject.FindGameObjectsWithTag ("Window");
		//Invoke ("startRain()", MAX_RUN_TIME);
		//InvokeRepeating ("spreadFire()", INIT_SPREAD_DELAY, SPREAD_TIMER_RATE);


	}

	
	// Update is called once per frame
	void Update () {
		if (!raining) {
			//print ("Not raining!");
			if (spreadTimer <= 0){
				//fireSpreader();
			}
			//updateTimers ();
		}
	}

	void spreadFire(){
		int r;
		r = Random.Range (0, window.Length);

		window[r].SetActive (true);
	}


	void updateTimers(){
		elapsedTime += Time.deltaTime;
		spreadTimer -= Time.deltaTime;
		

		rainCheck ();
	}
	
	void rainCheck(){
		if (elapsedTime >= MAX_RUN_TIME) {
			raining = true;
		}
	}
}
