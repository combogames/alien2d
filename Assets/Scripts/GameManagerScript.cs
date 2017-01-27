using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	/*
	 * Carrega uma cena 
	 */
	public void LoadGameScene(){
		SceneManager.LoadScene ("scene2");
	}
}
