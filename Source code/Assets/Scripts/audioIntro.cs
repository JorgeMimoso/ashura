using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioIntro : MonoBehaviour {

	public static AudioClip intMusic;
	public AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		intMusic = Resources.Load<AudioClip>("Koto");
		audioSrc = GetComponent<AudioSource>();
		audioSrc.PlayOneShot(intMusic);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
