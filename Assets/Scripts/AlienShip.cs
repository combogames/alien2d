using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour {

	public float speed = 1f;
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		TranslateAlien ();
	}

	void TranslateAlien() {
		transform.Translate (Vector2.up * speed * Time.deltaTime);
	}


}
