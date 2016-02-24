using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;

	private Rigidbody2D body;
	private Animator anim;
	private bool isGrounded = true;

	void Awake(){
		InitializeVariables ();
	}

	void Start () {
	
	}

	void FixedUpdate () {
		PlayerWalkKeyboard ();
	}

	void InitializeVariables(){
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void PlayerWalkKeyboard(){
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (body.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if(h > 0){
			if(vel < maxVelocity){
				if(isGrounded){
					forceX = moveForce;
				} else {
					forceX = moveForce * 1.1f;
				}

			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);
		} else if (h < 0){
			if(vel < maxVelocity){
				if(isGrounded){
					forceX = -moveForce;
				} else {
					forceX = -moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);
		} else if (h == 0){
			anim.SetBool ("Walk", false);
		}

		if(Input.GetKey(KeyCode.Space)){
			if(isGrounded){
				isGrounded = false;
				forceY = jumpForce;
				anim.SetBool ("Jump", true);
			}
		}

		body.AddForce (new Vector2 (forceX, forceY));
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Ground"){
			isGrounded = true;
			anim.SetBool ("Jump", false);
		}
	}

	public bool BouncePlayer(float force){
		if(isGrounded){
			isGrounded = false;
			body.AddForce (new Vector2 (0, force));
			return true;
		}

		return false;
	}
}