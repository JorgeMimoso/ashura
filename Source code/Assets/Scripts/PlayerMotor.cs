using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector; // variavel para calcular a posiçao do avatar

    private float speed = 5; // velocidade a que o avatar se desloca
    private float verticalSpeed = 0;// variavel que vai defenir a velocidade aplicada a uma queda do avatar
    private float gravity = 12; // variavel que define a força da gravidade aplicada à queda
    private float animationDuration = 3; // variavel que define o tempo da animaçao da camara no inicio do jogo
	private float starTime;

    private bool isDead = false;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
		starTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        // controller.Move(Vector3.forward);//1 meter every single frame

        if (isDead)
            return;
        

		if (Time.time - starTime < animationDuration)
            {
                controller.Move(Vector3.forward * speed * Time.deltaTime); // o boneco apenas anda em frente e nao é possivel mexe-lo
                return;
            }

            if (controller.isGrounded) // se o avatar está no chao (a pisar o chao, whatever..)
            {
                verticalSpeed = -0.05f;  // a gravidade aplicada ao jogador é 1
            }
            else
            {
                verticalSpeed -= gravity * Time.deltaTime;  // o avatar cai

            }

        moveVector = Vector3.zero; // posiçao inicial que ira ser refrescada com o 'x', 'y' e 'z'

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; // verifica o input do jogador para mover o avatar na horizontal (x).

        moveVector.z = speed; // o (z) do jogador a cada frame vai ser igual à velocidade que definimos em speed

        moveVector.y = verticalSpeed; // o avatar tem a força aplicada dependendo se está ou nao acente no chao

        controller.Move(moveVector * Time.deltaTime); // move o avatar dependendo dos valores do moveVector
    }
    public void setSpeed (float nivel)
    {
        speed += nivel;
    }

    //funçao chamada cada vez que o avatar colide com algo
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "enemy")
        {
                death();
        }

        if (hit.gameObject.tag == "coin")
        {
            soundManager.PlaySound("coin");
            DestroyObject(hit.gameObject);
            GetComponent<Score>().setScore(1); //incrementa o score em 1 por cada gema apanhada
        }

    }
    private void death()
    {

        isDead = true;
        GetComponent<Score>().onDeath();
    }
}
