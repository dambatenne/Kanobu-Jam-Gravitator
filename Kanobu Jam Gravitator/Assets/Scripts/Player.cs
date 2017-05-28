using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private GameObject explosionPrefab;
	private GameObject gameManager;

	void Start () {

		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		gameManager.GetComponent <GameManager> ().DisplayScore ();

	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "obstacle") {

			GameOver ();

		} else if (other.tag ==  "Collectable") {

			IncreaseScore ();

		}


    }

    private void GameOver () {

    	// Create an explosion and destroy the Player
		GameObject explosion = (GameObject) Instantiate (explosionPrefab);
		explosion.transform.position = gameObject.transform.position;

		// Go to game over screen
		gameManager.GetComponent <GameManager> ().GameOver ();

		Destroy (gameObject);
    }

    private void IncreaseScore () {

		gameManager.GetComponent <GameManager> ().AddScore (1);

    }
}
