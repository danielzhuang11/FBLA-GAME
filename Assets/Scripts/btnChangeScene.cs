using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnChangeScene : MonoBehaviour {

	
	public void ChangeScene (int scene) {
        Application.LoadLevel(scene);
		
	}
}
