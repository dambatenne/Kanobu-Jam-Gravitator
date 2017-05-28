using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitatorSpawner : MonoBehaviour {

	[SerializeField] private LayerMask fieldMask;
	[SerializeField] private LayerMask gravMask;
	[SerializeField] private GameObject gravitatorPrefab;
	[SerializeField] private bool inTutorialMode = false;

	private float hintDelay = 0f;

	public float HintDelay {

		get {return hintDelay;}
		set {hintDelay = value;}

	}

	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

		// On left mouse click actions
		if (Input.GetMouseButtonDown(0)) {

			if (Physics.Raycast(ray, out hit, 100, gravMask, QueryTriggerInteraction.UseGlobal)) {

				// If player clicks on the gravitator, it destroys
				Destroy (hit.collider.gameObject);

			} else if (Physics.Raycast(ray, out hit, 100, fieldMask, QueryTriggerInteraction.UseGlobal)) {

				// If player clicks on the field a new gravitator is created
				GameObject obj = (GameObject)Instantiate(gravitatorPrefab);
				obj.transform.position = new Vector3(hit.point.x, .5f, hit.point.z);

				// If in tutorial mode hide the hint after creation
				if (inTutorialMode) {

					StartCoroutine (obj.GetComponent <TutorGrav> ().ActivateHintWitDelay(hintDelay));
					DestroyAllHints ();
				}
				
			} 

		}
	}

	void DestroyAllHints () {

		GameObject[] hints = GameObject.FindGameObjectsWithTag ("Hint");

		for (int i = 0; i < hints.Length; i++) {

			if (hints[i].transform.GetChild(0).gameObject.activeSelf) {
				Destroy (hints[i]);
			}

		}

	}

}
