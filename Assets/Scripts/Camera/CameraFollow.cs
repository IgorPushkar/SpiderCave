using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float minX, maxX;

	private Transform player;
	private float offset;

	void Start(){
		player = GameObject.Find ("Player").transform;
		offset = transform.position.y - player.position.y;
	}

	void Update(){
		if(player != null){
			Vector3 temp = transform.position;
			temp.x = player.position.x;
			if(temp.x < minX){
				temp.x = minX;
			}
			if(temp.x > maxX){
				temp.x = maxX;
			}

			temp.y = player.position.y + offset;
			transform.position = temp;
		}
	}
}
