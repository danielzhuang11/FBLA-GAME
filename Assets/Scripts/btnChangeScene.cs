using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnChangeScene : MonoBehaviour {

    
	public void ChangeScene (int scene) {

        AudioManager.instance.Stop();
 
        SceneManager.LoadScene(scene);
		
	}

    public void Quit()
    {
        Application.Quit();

    }

    public void btnSound()
    {
        AudioManager.instance.Play("Button");
    }

    
}
