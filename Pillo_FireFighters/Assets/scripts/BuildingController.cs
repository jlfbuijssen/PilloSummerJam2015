using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {
	
	private bool raining = false;
	//	public float elapsedTime;
	public GameObject[] window;
	float fireSpreadDelay;
	public int initialFires = 3;

	// Time before it starts raining
	public float delayRain = 100.0F;
	// Time before the first random spreading of fire
	public float initSpreadDelay = 2.0F;
	// Time between fire spreads
	public float fireSpreadRate = 2.0F;
	public int lightAttempts = 50;
	private int litWindows;
	public bool youAreTheBestAround = false;

	//  public constants
	//  public static bool RANDOM = true;
	//  public static int WINDOW_ROWS = 3;
	//  public static int WINDOW_COLUMNS = 4;
	private static string WINDOW_TAG = "Window";
	
	
	
	// Use this for initialization
	void Start () {

		// Init
		window = GameObject.FindGameObjectsWithTag (WINDOW_TAG);
		for (int i = 0; i < initialFires; i++) spreadFire ();
		StartCoroutine ("spreadRoutine", initSpreadDelay);
		Invoke ("startRain", delayRain);
		litWindows = initialFires;
	}
	
	// Update is called once per frame
	void Update () {
		if (!youAreTheBestAround) {
			if (raining) {
				// Stop the fire from spreading
				StopAllCoroutines ();

			}

			if (litWindows == 0) {
				gameOver ();
			} else {
				if(Input.GetKeyDown("R")){
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}
	
	IEnumerator spreadRoutine(float delay){
		////Debug.Log ("Spreading fire in " + delay + " seconds...");
		yield return new WaitForSeconds(delay);
		
		//	//Debug.Log ("Calling spreadFire()");
		spreadFire ();
		StartCoroutine ("spreadRoutine", fireSpreadDelay);
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
		window [r].GetComponent<WindowController> ().burning = true;
		////Debug.Log ("Burning value of Window["+ r +"] = "+ window[r].GetComponent<WindowController>().burning);
		
	}
	
	void startRain(){
		//Debug.Log ("Start Raining");
		raining = true;
	}

	void gameOver(){
		youAreTheBestAround = true;
		CancelInvoke("startRain");
	}
	
}
