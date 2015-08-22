using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {

	public static string COLLIDER_TAG = "Water";
	public bool debug_col;

//	// Use this for initialization
//	void Start () {
//	
//	}
	void OnTriggerEnter(Collision col){
		print (col.collider.tag);
		if (col.collider.CompareTag (COLLIDER_TAG)) {
			print ("Trigger Entered");
			debug_col = true;
		}
	}

	void OnTriggerExit(Collision col){
		if (col.collider.tag.Equals (COLLIDER_TAG)) {
			print ("Exit Trigger");
			debug_col = false;
		}
	}
}
