using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UponLoadTitle : MonoBehaviour {
    public static int streak = 0;
    public Text streakTxt;
	// Use this for initialization
	void Start () {
        AudioManager.instance.Play("Title");
        streakTxt.text = "Current streak: " + streak;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
