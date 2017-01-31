using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipGreen : MonoBehaviour {

	// Use this for initialization
	public float speed = 5f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TranslateAlien ();
	}

	void TranslateAlien() {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
}
