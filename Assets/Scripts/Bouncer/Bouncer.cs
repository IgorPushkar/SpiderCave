using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	public float force = 500f;

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();
	}

	IEnumerator AnimateBouncer(){
		anim.Play ("Bouncer Up");
		yield return new WaitForSeconds (0.5f);
		anim.Play ("Bouncer Down");
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if(other.gameObject.GetComponent<Player> ().BouncePlayer (force)){
				StartCoroutine (AnimateBouncer ());
			}
		}
	}
}
