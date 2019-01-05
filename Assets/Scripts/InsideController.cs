using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        Dialogue dialogue = new Dialogue(new string[] { "Congratulations for making it this far", "You have now boarded the enemy", "Use the new intel provided to find a way to the engine room" }, "Admiral Cryane");
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);


      //  string correctAns = GetComponent<Questions>().newQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
