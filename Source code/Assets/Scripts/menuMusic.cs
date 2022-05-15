using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour {

	public static AudioClip mMusic;
	public AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		mMusic = Resources.Load<AudioClip>("Menu");
		audioSrc = GetComponent<AudioSource>();
		audioSrc.PlayOneShot(mMusic);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
