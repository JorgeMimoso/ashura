using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    public static AudioClip coinSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

        coinSound = Resources.Load<AudioClip>("coin");
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            

        }
    }
}
