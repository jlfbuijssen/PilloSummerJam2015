using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {

	public static string COLLIDER_TAG = "Water";

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
			Debug.Log("Trigger Entered");

		}
	}

//	void OnTriggerExit(Collider col){
//		if (col.tag.Equals (COLLIDER_TAG)) {
//			print ("Exit Trigger");
//			debug_col = false;
//		}
//	}
}
