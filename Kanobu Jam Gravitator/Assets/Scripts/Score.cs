using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Display score
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		gameObject.GetComponent <Text> ().text = "Your score: " + gameManager.GetComponent <GameManager> ().Score.ToString ();
	}

}
