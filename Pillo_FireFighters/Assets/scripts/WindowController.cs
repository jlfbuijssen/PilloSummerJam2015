using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {

	public static string COLLIDER_TAG = "Water";
	public bool debug_col;

//	// Use this for initialization
//	void Start () {
//	
//	}
	void OnCollisionEnter(Collision col){
		if (col.collider.tag.Equals (COLLIDER_TAG)) {
			debug_col = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.collider.tag.Equals (COLLIDER_TAG)) {
			debug_col = false;
		}
	}
}
