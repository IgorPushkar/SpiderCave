using UnityEngine;
using System.Collections;

public class SpiderBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if(other.tag == "Ground"){
			Destroy (gameObject);
		}

	}
}
