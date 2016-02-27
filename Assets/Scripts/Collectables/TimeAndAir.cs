using UnityEngine;
using System.Collections;

public class TimeAndAir : MonoBehaviour {

	public float addAmount;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if(gameObject.name == "Air Collectable"){
				GameObject.Find ("Gameplay Controller").GetComponent<AirTimer> ().Add (addAmount);
			} else {
				GameObject.Find ("Gameplay Controller").GetComponent<LevelTimer> ().Add (addAmount);
			}
			Destroy (gameObject);
		}
	}
}
