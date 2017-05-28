using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHelper : MonoBehaviour {

	private GameObject gameManager;

	// Use this for initialization
	void Start () {

		gameManager = GameObject.FindGameObjectWithTag ("GameManager");

	}

	public void StartGame () {

		gameManager.GetComponent <GameManager> ().LoadLevel ("Level 1");

	}

	public void StartTutorial () {

		gameManager.GetComponent <GameManager> ().LoadLevel ("Tutorial menu");

	}

	public void NextLevel () {

		gameManager.GetComponent <GameManager> ().LoadNextScene ();

	}

	public void LoadMainMenu () {

		gameManager.GetComponent <GameManager> ().ResetScore ();
		gameManager.GetComponent <GameManager> ().LoadLevel ("Main menu");

	}

	public void Replay () {

		gameManager.GetComponent <GameManager> ().ReloadLastScene ();

	}

	public  void LoadTutorial (int tutorialNum) {

		gameManager.GetComponent <GameManager> ().LoadLevel ("Tutorial " + tutorialNum);

	}

}
