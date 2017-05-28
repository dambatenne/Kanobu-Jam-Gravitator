using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	private AudioSource audioSrc;
	private GameObject gameManager;

	void Start () {

		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		audioSrc = gameObject.GetComponent <AudioSource> ();

	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			audioSrc.Play ();
			StartCoroutine ("FinishLevelWithDelay");

		}

	}

	IEnumerator FinishLevelWithDelay () {

		yield return new WaitForSeconds (audioSrc.clip.length);

		if (gameManager.GetComponent <GameManager> ().SceneIndex == 5) {

			gameManager.GetComponent <GameManager> ().LoadLevel ("Win menu");
				
		} else {

			gameManager.GetComponent <GameManager> ().FinishLevel ();

		}

	}

}
