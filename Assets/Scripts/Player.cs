using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed = 50f;
	private float maxSpeed = 3;
	private float JumpPower = 300f;
	public bool grounded = false; //<<Verificar PlayerCheck.cs para grounded

	private Rigidbody2D rb2d; //É um corpo no jogo afetado pela fisica relacionado ao player
	private Animator anim; //<<Serve para controlar as animacoes do player

	//Inicializando componentes e variaveis
	//@override
	void Start () {
		rb2d = GameObject.FindObjectOfType<Rigidbody2D> ();
		anim = GameObject.FindObjectOfType<Animator> ();
	}
	
	//Update is called once per frame
	//@override
	void Update () {
		updatePlayerAnimations ();
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

	//Atualiza as animacoes do player conforme ele se mexe.
	private void updatePlayerAnimations(){
		//Seta um valor ao parametro 'speedParam' se o player estiver se movento no eixo x
		//e como 'speedParam' esta configurado no animator do player, ele vai iniciar a animacao de andar.
		anim.SetFloat ("speedParam", Mathf.Abs (rb2d.velocity.x)); //<<Mathf.Abs retorna um valor absoluto e positivo

		//Informando ao animator pelo parametro 'groundedParam' se o player esta no chao ou nao.
		anim.SetBool ("groundedParam", grounded); 	
	}
}
