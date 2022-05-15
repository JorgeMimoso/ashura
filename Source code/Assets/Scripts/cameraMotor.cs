using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotor : MonoBehaviour
{

    private Transform avatarPosition; // variavel para apanhar a posiçao do avatar enquanto este se mexe
    private Vector3 startPos; // variavel para guardar a posiçao inicial da camera
    private Vector3 moveVector; // variavel para definir a posiçao da camara

    private float transition = 0; // variavel para a transiçao da camara no inicio do jogo
    private float animTime = 3; // duraçao da animaçao da camara

    private Vector3 relativePos; // variavel da posiçao relativa ao avatar


    // Use this for initialization
    void Start()
    {

        avatarPosition = GameObject.FindGameObjectWithTag("Player").transform; // apanha a posiçao do avatar que está definida no transform
        startPos = transform.position - avatarPosition.position; // a camara ficará posicionada consoante a posiçao desta e do avatar
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = avatarPosition.position + startPos;// defino que a posiçao da camara é igual à variavel avatarPosition + a posiçao inicial da camara
        moveVector.x = 0; // a camara está sempre centrada ao meio do mapa
        moveVector.y = Mathf.Clamp(moveVector.y, 3, avatarPosition.position.y + 5); // define os pontos maximos e minimos da altura da camara
        moveVector.z = avatarPosition.position.z - 5; // define a posiçao da camara em z em relaçao ao avatar

        relativePos = (avatarPosition.position + new Vector3(0, 0, 0)) - transform.position;

        if (transition > 1) // se passamos a animaçao
        {
            transform.position = moveVector; // move a camara atras do boneco
        }

        else // se começou o jogo entao haverá a animaçao inicial da camara
        {
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, transition);
            transform.Translate(0, 0, 0);

            transition += Time.deltaTime / animTime; // a cada um segundo, o tempo sera dividido pela duraçao da animaçao.
        }

    }
}

