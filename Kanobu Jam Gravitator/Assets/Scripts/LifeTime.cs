using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

	[SerializeField] private float lifeTime = 10f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifeTime);
	}

}
