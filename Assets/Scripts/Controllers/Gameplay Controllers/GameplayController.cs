using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private Button resumeButton;

	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => ResumeGame ());
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Restart(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void PlayerDied(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => Restart ());
	}
}
