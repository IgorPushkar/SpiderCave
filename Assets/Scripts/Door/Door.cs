using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public static Door instance;
	[HideInInspector]
	public int collectiblesCount;

	private BoxCollider2D box;
	private Animator anim;

	void Awake(){
		MakeInstance ();
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider2D> ();
	}

	void MakeInstance(){
		if(instance == null){
			instance = this;
		}
	}

	public void DecrementCollectables(){
		collectiblesCount--;
		if(collectiblesCount == 0){
			StartCoroutine (OpenDoor ());
		}
	}

	IEnumerator OpenDoor(){
		anim.Play ("Door Open");
		yield return new WaitForSeconds (0.7f);
		box.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			GameObject temp = GameObject.Find ("Gameplay Controller");
			if(temp){
				temp.GetComponent<GameplayController> ().PlayerDied ();
			}
		}
	}
}