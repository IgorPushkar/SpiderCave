using UnityEngine;
using System.Collections;

public class SpiderJumper : MonoBehaviour {

	public float forceY = 300f;

	private Rigidbody2D body;
	private Animator anim;

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start(){
		StartCoroutine (Attack());
	}

	IEnumerator Attack(){
		yield return new WaitForSeconds (Random.Range (2, 7));

		forceY = Random.Range (250, 550);
		body.AddForce (new Vector2 (0, forceY));
		anim.SetBool ("Attack", true);

		yield return new WaitForSeconds (0.7f);
		StartCoroutine (Attack());
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Destroy (other.gameObject);
		}

		if(other.tag == "Ground"){
			anim.SetBool ("Attack", false);
		}
	}
}
