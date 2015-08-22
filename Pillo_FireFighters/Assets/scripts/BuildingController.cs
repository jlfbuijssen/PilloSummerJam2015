using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

	public bool raining = false;
	public float spreadTimer = 10.0F;
//	public float elapsedTime;
	public GameObject[] window;
	float spreadDelay;

	// public constants
	public static bool RANDOM = true;
	public static float MAX_RUN_TIME;
//	public static int WINDOW_ROWS = 3;
//	public static int WINDOW_COLUMNS = 4;
	public static float INIT_SPREAD_DELAY = 0.0F;
	public static float SPREAD_TIMER_RATE = 10.0F;
	public static int LIGHT_ATTEMPTS = 50;
	public static string WINDOW_TAG = "Window";



	// Use this for initialization
	void Start () {

		// Init
		spreadDelay = INIT_SPREAD_DELAY;
		// 
		window = GameObject.FindGameObjectsWithTag (WINDOW_TAG);

		for (int i = 0; i<window.Length; i++) {
			Debug.Log ("Window "+i+ " is called: "+window[i].name);
		}

		StartCoroutine (spreadRoutine(INIT_SPREAD_DELAY));
		Invoke ("startRain()", MAX_RUN_TIME);
	}

	// Update is called once per frame
	void Update () {
		if (raining) {
			// Stop the fire from spreading
			StopAllCoroutines();
		}
	}

	IEnumerator spreadRoutine(float delay){
		yield return new WaitForSeconds(delay);

		spreadFire ();
		StartCoroutine ("spreadRoutine", spreadDelay);
	}

	void spreadFire(){
		int r;
		int c = LIGHT_ATTEMPTS;
		do {
			r = Random.Range (0, window.Length);
			c--;
		} while(!window [r].GetComponent<WindowController>.burning && c > 0);

		window[r].GetComponent<WindowController>.burning = true;
	}

	void startRain(){
		raining = true;
	}

}
