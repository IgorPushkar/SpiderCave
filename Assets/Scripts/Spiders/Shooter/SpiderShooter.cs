using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;

	void Start () {
		StartCoroutine (Attack ());
	}

	IEnumerator Attack(){
		yield return new WaitForSeconds (Random.Range (2, 7));

		Instantiate (bullet, transform.position, Quaternion.identity);
		StartCoroutine (Attack ());
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Destroy (other.gameObject);
		}
	}
}
