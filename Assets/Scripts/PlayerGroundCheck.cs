using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour {

	//Referenciando o Script Player.cs
	private Player player;

	//@override
	void Start(){
		
		//Instanciando o Script Player.cs
		//Como este script está contido no objeto filho do Player
		//foi usado o comando GetComponentInParent 
 		player = gameObject.GetComponentInParent<Player> (); 

	}

	//Nota, para usar este tipo de colisao 'trigger'
	//o collider2d tem que estar setado como 'is trigger'
	//@override
	void OnTriggerEnter2D(Collider2D col){
		player.grounded = true;
	}

	//@override
	void OnTriggerStay2D(Collider2D col){
		player.grounded = true;
	}

	//@override
	void OnTriggerExit2D(Collider2D col){
		player.grounded = false;
	}

}
