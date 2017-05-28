using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	[SerializeField] private float ballSpeed = .3f;
	[SerializeField] private GameObject finish;

	private Collider curCollider;

	// Update is called once per frame
	void Update () {
		//ChangeLookAtObject ();
		gameObject.transform.Translate(Vector3.forward * ballSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {

		curCollider = other;
		if (curCollider.tag == "obstacle") {
				Destroy (gameObject);
			}


    }

    public void StopAllForces () {

		gameObject.GetComponent <Rigidbody> ().velocity =  Vector3.zero;
		gameObject.GetComponent <Rigidbody> ().angularVelocity =  Vector3.zero;

    }

	/*void OnTriggerExit(Collider other) {

		curCollider = null;

    }

    void ChangeLookAtObject () {

    	if (curCollider != null) {
			if (!curCollider.gameObject.activeInHierarchy) {
				Debug.Log("Not active: " + curCollider.gameObject.ToString());
				gameObject.transform.LookAt(finish.transform);
			} else if (curCollider.tag == "gravityZone") {
				gameObject.transform.LookAt(curCollider.transform);
			}
		} else {
			gameObject.transform.LookAt(finish.transform);
		}
		
    }*/

}
