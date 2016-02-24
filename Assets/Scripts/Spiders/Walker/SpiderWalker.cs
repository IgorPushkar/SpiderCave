using UnityEngine;
using System.Collections;

public class SpiderWalker : MonoBehaviour {

	[SerializeField]
	private Transform startPos, endPos;
	private bool collision;
	private Rigidbody2D body;

	public float speed = 1f;

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Move ();
		ChangeDirection ();
	}

	void ChangeDirection(){
		collision = Physics2D.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("Ground"));

		if(!collision){
			Vector3 temp = transform.localScale;
			if(temp.x == 1){
				temp.x = -1;
			} else {
				temp.x = 1;
			}

			transform.localScale = temp;
		}
	}

	void Move(){
		body.velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}

	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "Player"){
			Destroy (target.gameObject);
		}
	}
}
