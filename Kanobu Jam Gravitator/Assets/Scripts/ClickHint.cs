using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHint : MonoBehaviour {

	[SerializeField] private float hintDelay = 0f;
	[SerializeField] private GameObject spawner;

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			gameObject.transform.GetChild(0).gameObject.SetActive (true);
			spawner.GetComponent <GravitatorSpawner> ().HintDelay = hintDelay;

		}

	}
}
