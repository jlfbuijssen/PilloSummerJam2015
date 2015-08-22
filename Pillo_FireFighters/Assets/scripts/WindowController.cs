using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {

	public static string COLLIDER_TAG = "Water";
	public bool debug_col;

//	// Use this for initialization
//	void Start () {
//	
//	}
//	void OnTriggerEnter(Collider col){
//		print ("TEST");
//	
//	}

	void OnTriggerEnter(Collider col){
		print (col.tag);
		if (col.GetComponent<Collider>().CompareTag (COLLIDER_TAG)) {
			print ("Trigger Entered");
			debug_col = true;
		}
	}

//	void OnTriggerExit(Collider col){
//		if (col.tag.Equals (COLLIDER_TAG)) {
//			print ("Exit Trigger");
//			debug_col = false;
//		}
//	}
}
