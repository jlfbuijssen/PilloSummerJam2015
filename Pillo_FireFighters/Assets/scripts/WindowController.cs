using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {
	
	public static string COLLIDER_TAG = "Water";
	public float fireStrength = 0.0f;
	public bool burning = false;
	
	public GameObject fireSmall;
	public GameObject fireMedium;
	public GameObject fireLarge;

	public GameObject currentFire = null;
	
	private float waterStrength = 0.0f;
	private float fireGrowRate = 0.0f;
	private float maxFireStrength = 99.0f;
	private int maxFireState = 3;
	private int fireState = 0;
	
	//	// Use this for initialization
	void Start () {
		fireGrowRate = GameObject.Find ("Player").GetComponent<Hose>().fireGrowRate;
		waterStrength = GameObject.Find ("Player").GetComponent<Hose>().hoseStrength;
	}
	//	void OnTriggerEnter(Collider col){
	//		print ("TEST");
	//	
	//	}


	/*void OnParticleCollision(GameObject collider){
	
		Rigidbody body = collider.GetComponent<Rigidbody> ();

		if (body) {
		
		}
	
	}*/


	void OnTriggerStay(Collider col){
		//print (col.tag);
		if (col.GetComponent<Collider>().CompareTag (COLLIDER_TAG)) {
			//Debug.Log("Trigger Entered");
			
			if(burning){
				fireStrength -= waterStrength*Time.deltaTime;
				print (fireStrength);
			}
			
		}
	}
	
	void GrowFire(){
		
		fireStrength += fireGrowRate * Time.deltaTime;
		
	}
	
	
	void CheckFireState(){


		
		/*if (Input.GetKey ("space")) {
			fireStrength ++;
			print(fireStrength);
		}
		if (Input.GetKey ("x")) {
			fireStrength --;
			print(fireStrength);
		}*/
		
		if ((maxFireStrength / (maxFireState-1))* (fireState-1) > fireStrength) {
			
			fireState --;
			
			ChangeFireState();
			
		}
		
		if ((maxFireStrength / (maxFireState-1))*fireState < fireStrength) {
			
			fireState ++;
			
			ChangeFireState();
			
		}
		
		if (fireState <= 0 && burning) {
			
			burning = false;
			
			fireState = 0;

			Destroy (currentFire);
			currentFire = null;
			
		}
		
	}
	
	void ChangeFireState(){


		switch(fireState)
		{
		case 3:
			//big fire
			Destroy (currentFire);
			currentFire = null;
			currentFire = Instantiate (fireLarge,this.transform.position,Quaternion.identity) as GameObject;
			currentFire.transform.rotation = Quaternion.Euler(270,0,0);

			break;
		case 2:
			//med fire
			Destroy (currentFire);
			currentFire = null;
			currentFire = Instantiate (fireMedium,this.transform.position,Quaternion.identity) as GameObject;
			currentFire.transform.rotation = Quaternion.Euler(270,0,0);
			break;
		case 1:
			//small fire
			Destroy (currentFire);
			currentFire = null;
			currentFire = Instantiate (fireSmall,this.transform.position,Quaternion.identity) as GameObject;
			currentFire.transform.rotation = Quaternion.Euler(270,0,0);
			break;
		case 0:
			//no fire
			
			break;
		default:
			print ("no fireState detected");
			break;
		}

	}
	
	void Update(){
		
		if (burning) {
			
			GrowFire();
		}
		
		CheckFireState ();
		
	}
	//	void OnTriggerExit(Collider col){
	//		if (col.tag.Equals (COLLIDER_TAG)) {
	//			print ("Exit Trigger");
	//			debug_col = false;
	//		}
	//	}
}
