using UnityEngine;
using System.Collections;

public class Diamonds : MonoBehaviour {

	void Start(){
		if(Door.instance != null){
			Door.instance.collectiblesCount++;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if(Door.instance != null){
				Door.instance.DecrementCollectables ();
				Destroy (gameObject);
			}
		}
	}
}
