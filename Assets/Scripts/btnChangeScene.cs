using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnChangeScene : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	public void ChangeScene (int scene) {
        Application.LoadLevel(scene);
		
	}
}
