using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnChangeScene : MonoBehaviour {

    private AudioSource[] allAudioSources;
	public void ChangeScene (int scene) {
        
     allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
     foreach( AudioSource audioS in allAudioSources) {
         audioS.Stop();
      }
 
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
