using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {
	
	public bool raining = false;
	//	public float elapsedTime;
	public GameObject[] window;
	public int initialFires = 3;
	public int burningWindows;


	// public constants
	//public static bool RANDOM = true;
	public float gameRunTime = 100.0F;
	//	public static int WINDOW_ROWS = 3;
	//	public static int WINDOW_COLUMNS = 4;
	public float initSpreadDelay = 2.0F;
	public float spreadDelay = 2.0F;
	public int lightAttempts = 50;
	private static string WINDOW_TAG = "Window";
	private static KeyCode RESTART_BUTTON = KeyCode.R;
	private bool youAreTheBestAround = false;
	

	// Use this for initialization
	void Start () {
		
		// Init
		//burningWindows = initialFires;
		// 
		window = GameObject.FindGameObjectsWithTag (WINDOW_TAG);
		
		//		for (int i = 0; i<window.Length; i++) {
		//			.Log ("Window "+i+ " is called: "+window[i].name);
		//		}
		for (int i = 0; i < initialFires; i++) spreadFire ();
		StartCoroutine ("spreadRoutine", initSpreadDelay);
		Invoke ("startRain", gameRunTime);
	}
	
	// Update is called once per frame
	void Update () {

		if(youAreTheBestAround == false){
			if (raining) {
				// Stop the fire from spreading
				StopAllCoroutines();
			}

			if (burningWindows <= 0) {
				gameOver ();
			}
		} else {
			if(Input.GetKeyDown(RESTART_BUTTON)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		print (burningWindows);
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
		int c = lightAttempts;
		do {
			////Debug.Log ("Generating random number to select a window");
			r = Random.Range (0, window.Length);
			c--;
			////Debug.Log(window [r].GetComponent<WindowController>().burning+ "  "+c);
		} while (c > 0 && window [r].GetComponent<WindowController>().burning);
		////Debug.Log ("Lighting fire to window "+r+".");
		if(!window [r].GetComponent<WindowController> ().burning){
			window [r].GetComponent<WindowController> ().burning = true;
			if(burningWindows <= window.Length){
				burningWindows++;
			}
				
		}
	
		////Debug.Log ("Burning value of Window["+ r +"] = "+ window[r].GetComponent<WindowController>().burning);
		
	}
	
	void startRain(){
		//Debug.Log ("Start Raining");
		raining = true;
	}

	void gameOver(){
		raining = false;
		CancelInvoke ("startRain");
		//TODO Queue you're the best around
		//print ("DIE!!!");
		GameObject.Find("Main Camera").GetComponent<CameraSound>().PlayThatMusic();
		youAreTheBestAround = true;

	}
	
}
