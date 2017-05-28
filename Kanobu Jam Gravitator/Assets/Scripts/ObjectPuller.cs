using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour {

    [SerializeField] private float pullForce = 1;
 

	void OnTriggerStay(Collider other) {

		if (other.tag == "Player") {

			Vector3 forceDirection = transform.position - other.transform.position;
			other.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);

		}


    }

}
