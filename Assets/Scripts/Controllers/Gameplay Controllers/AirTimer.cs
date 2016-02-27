using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirTimer : MonoBehaviour {

	private Image slider;
	private GameObject player;
	private float airBurn = 1f;
	private float air;

	public float maxAir = 10f;

	void Awake(){
		GetReferences ();
	}

	void GetReferences (){
		slider = GameObject.Find ("Air Bar").GetComponent<Image> ();
		player = GameObject.Find ("Player");
		air = maxAir;
	}

	void Update () {
		if(!player){
			return;
		}

		if(air > 0){
			air -= airBurn * Time.deltaTime * Time.timeScale;
			slider.fillAmount = air / maxAir;
		} else {
			Destroy (player);
		}
	}

	public void Add(float amount){
		if(amount != 0 && air != 0){
			air += amount;
			air = Mathf.Clamp (air, 0, maxAir);
		}
	}
}
