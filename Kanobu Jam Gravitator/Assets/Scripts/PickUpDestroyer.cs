using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDestroyer : MonoBehaviour {

	AudioSource audioSrc;

	void Start () {

		audioSrc = gameObject.GetComponent <AudioSource> ();

	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			audioSrc.Play ();
			StartCoroutine ("DestroyWithDelay");

		}

	}

	IEnumerator DestroyWithDelay () {

		yield return new WaitForSeconds (audioSrc.clip.length);
		Destroy (gameObject);

	}
}
