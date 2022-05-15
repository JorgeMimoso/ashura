using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {

    public GameObject[] tilesPrefab; // array de objectos que guarda os varios caminhos para fazer a estrada
    private Transform playerTransform; // posiçao do avatar

    private float Z = 0; // em que ponto de z queremos colocar o nosso pedaço de estrada
    private float tileLenght = 7; // tamanho da estrada
    private int nTiles = 10; // numero de caminhos que estao sempre activos no jogo
    private float safeZone = 15; // safe zone definida para apagar os troços deixados para tras
    private int lastPrefabIndex = 0; // variavel que vai guradar o ultimo troço de aminho gerado para esta nao se voltar a repetir

    private List<GameObject> activeTiles = new List<GameObject>();

	// Use this for initialization
	private void Start () {
 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < nTiles; i++)
        {
            if (i < 3)
                spawnTile(0); // gera caminhos sem nada para que ao inicio nao haja bugs 

            else
                spawnTile(1); // depois de acontecer a animação da camara, gera caminhos com obstaculos
        }

    }

    // Update is called once per frame
    private void Update () {
        if (playerTransform.position.z - safeZone > (Z - nTiles * tileLenght))
        { 
            spawnTile(1); // gera um novo troço de caminho
            deleteTile(); // apaga o primeiro troço na lista de caminhos

        }
    }

    private void spawnTile(int prefabIndex)
    {

        GameObject go;
        if(prefabIndex != 0)
            go = Instantiate(tilesPrefab[randomPrefabIndex()]) as GameObject; // instancia um dos caminhos do array de caminhos de forma random
        else
            go = Instantiate(tilesPrefab[prefabIndex]) as GameObject;  // instancia o caminho na posiçao 0 para que nao haja obstaculos logo ao inicio

        go.transform.SetParent(transform); // coloca o novo troço como parent deste transform
        go.transform.position = Vector3.forward * Z; // este troço vai ficar à frente do anterior, usando o spawnZ que nos diz qual o tamanho actual da estrada
        Z += tileLenght; // incrementa o spawnZ para se saber qual o tamanho da estrada actual
        activeTiles.Add(go); //adiciona troço à lista de caminhos

    }

    private void deleteTile()
    {
        Destroy(activeTiles[0]); // destroi o objecto do index 0 da lista
        activeTiles.RemoveAt(0); // remove o que está no index 0 da lista 
    }

    private int randomPrefabIndex()
    {
        int randomIndex = lastPrefabIndex;

        while(randomIndex == lastPrefabIndex)
        {

            randomIndex = Random.Range(0, tilesPrefab.Length);
        }


        lastPrefabIndex = randomIndex;
        return randomIndex; 
    }
}
