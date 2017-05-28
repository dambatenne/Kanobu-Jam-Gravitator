using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorGrav : MonoBehaviour {

	void ActivateHint () {

		for (int i = 0; i < gameObject.transform.childCount; i++) {

			if (gameObject.transform.GetChild (i).tag == "Hint") {
				gameObject.transform.GetChild (i).gameObject.SetActive (true);
			}

		}

	}

	public IEnumerator ActivateHintWitDelay (float dealy) {
		yield return new WaitForSeconds(dealy);
		ActivateHint ();
    }
}
