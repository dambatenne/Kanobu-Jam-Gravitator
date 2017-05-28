using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	[SerializeField] private bool TutorialOn = false;

	// Use this for initialization
	void Start () {

		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		if (TutorialOn) {
			gameManager.GetComponent <GameManager> ().IsTutorialMode = true;
		} else {
			gameManager.GetComponent <GameManager> ().IsTutorialMode = false;
		}

	}

}
