using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {
	
	public bool raining = false;
	public float spreadTimer = 10.0F;
	//	public float elapsedTime;
	public GameObject[] window;
	float spreadDelay;
	public int initialFires = 3;


	// public constants
	//public static bool RANDOM = true;
	public static float MAX_RUN_TIME = 100.0F;
	//	public static int WINDOW_ROWS = 3;
	//	public static int WINDOW_COLUMNS = 4;
	public static float INIT_SPREAD_DELAY = 2.0F;
	public static float SPREAD_TIMER_RATE = 2.0F;
	public static int LIGHT_ATTEMPTS = 50;
	public static string WINDOW_TAG = "Window";
	
	
	
	// Use this for initialization
	void Start () {
		
		// Init
		spreadDelay = SPREAD_TIMER_RATE;
		// 
		window = GameObject.FindGameObjectsWithTag (WINDOW_TAG);
		
		//		for (int i = 0; i<window.Length; i++) {
		//			.Log ("Window "+i+ " is called: "+window[i].name);
		//		}
		for (int i = 0; i < initialFires; i++) spreadFire ();
		StartCoroutine ("spreadRoutine", INIT_SPREAD_DELAY);
		Invoke ("startRain", MAX_RUN_TIME);
	}
	
	// Update is called once per frame
	void Update () {
		if (raining) {
			// Stop the fire from spreading
			StopAllCoroutines();
		}
	}
	
	IEnumerator spreadRoutine(float delay){
		////Debug.Log ("Spreading fire in " + delay + " seconds...");
		yield return new WaitForSeconds(delay);
		
		//	//Debug.Log ("Calling spreadFire()");
		spreadFire ();
		StartCoroutine ("spreadRoutine", spreadDelay);
	}
	
	void spreadFire(){
		//Debug.Log ("Calling spreadFire()");
		int r;
		int c = LIGHT_ATTEMPTS;
		do {
			////Debug.Log ("Generating random number to select a window");
			r = Random.Range (0, window.Length);
			c--;
			////Debug.Log(window [r].GetComponent<WindowController>().burning+ "  "+c);
		} while (c > 0 && window [r].GetComponent<WindowController>().burning);
		////Debug.Log ("Lighting fire to window "+r+".");
		window [r].GetComponent<WindowController> ().burning = true;
		////Debug.Log ("Burning value of Window["+ r +"] = "+ window[r].GetComponent<WindowController>().burning);
		
	}
	
	void startRain(){
		//Debug.Log ("Start Raining");
		raining = true;
	}
	
}
