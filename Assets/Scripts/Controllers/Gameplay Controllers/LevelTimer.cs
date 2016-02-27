using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	private Image slider;
	private GameObject player;
	private float timeBurn = 1f;
	private float time;

	public float maxTime = 10f;

	void Awake(){
		GetReferences ();
	}

	void GetReferences (){
		slider = GameObject.Find ("Time Bar").GetComponent<Image> ();
		player = GameObject.Find ("Player");
		time = maxTime;
	}

	void Update () {
		if(!player){
			return;
		}

		if(time > 0){
			time -= timeBurn * Time.deltaTime * Time.timeScale;
			slider.fillAmount = time / maxTime;
		} else {
			Destroy (player);
		}
	}

	public void Add(float amount){
		if(amount != 0 && time != 0){
			time += amount;
			time = Mathf.Clamp (time, 0, maxTime);
		}
	}
}
