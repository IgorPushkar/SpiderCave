using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {

	public void PlayLevel(string level){
		SceneManager.LoadScene ("Gameplay" + level);
	}

	public void BackToMain(){
		SceneManager.LoadScene ("MainMenu");
	}
}
