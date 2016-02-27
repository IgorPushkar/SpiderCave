using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private Player player;

	void Awake(){
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}

	public void OnPointerDown(PointerEventData data){
		if(gameObject.name == "Left"){
			player.SetMoveLeft (true);
		} else {
			player.SetMoveRight (true);
		}
	}

	public void OnPointerUp(PointerEventData data){
		if(gameObject.name == "Left"){
			player.SetMoveLeft (false);
		} else {
			player.SetMoveRight (false);
		}
	}
}
