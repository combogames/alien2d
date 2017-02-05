using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed = 50f;
	private float maxSpeed = 3;
	private float JumpPower = 250f;
	public bool grounded = false; //<<Verificar PlayerCheck.cs para grounded

	private Rigidbody2D rb2d;
	private Animator anim;

	//Inicializando componentes e variaveis
	//@override
	void Start () {
		rb2d = GameObject.FindObjectOfType<Rigidbody2D> ();
		anim = GameObject.FindObjectOfType<Animator> ();
	}
	
	//Update is called once per frame
	//@override
	void Update () {

		//'anim' seta a animacao apropriada do player para determinada acao.
		//Estas animacoes e parametros estao configuradas dentro do Animator do player
		anim.SetBool ("groundedParam", grounded); 

		//Mathf.Abs retorna um valor absoluto e positivo, ficando um numero menor e mais maleavel.
		anim.SetFloat ("speedParam", Mathf.Abs (Input.GetAxis ("Horizontal")));

	}

	//FixedUpdate nao sofre interferencia do device ao atualizar
	//sendo sempre fixo e melhor para interagir com controles
	//@override
	void FixedUpdate(){
		MovePlayer ();
	}

	//Movimenta o personagem com as teclas/inputs
	void MovePlayer(){

		//movendo na horizontal com as teclas
		float h = Input.GetAxis ("Horizontal");
		rb2d.AddForce ((Vector2.right * speed) * h);

		//Limitando a velocidade do player, caso contrario ele fica muito rápido
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}		
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}		

		//Pula ao apertar espaço no teclado, se o personagem estiver no chao
		if (Input.GetButtonDown ("Jump") && grounded) {
			rb2d.AddForce (Vector2.up * JumpPower);
		}

		invertPlayerSpriteByDirection (h);
	}

	//Inverte o sprite de lado para ao andar para a esquerda ou direita
	private void invertPlayerSpriteByDirection(float horizAxis){
		if (horizAxis < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}else if (horizAxis > 0.1f) {
			transform.localScale = new Vector3 ( 1, 1, 1);
		}	
	}
}
