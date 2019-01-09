using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Settings : MonoBehaviour {
    public static bool dialogueToggle = true;
	// Use this for initialization
    public AudioMixer  mixer;
	void Start () {
        GameObject.Find("ToggleDialogue").GetComponent<Toggle>().isOn = dialogueToggle;
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = GetMasterLevel();
       
	}
    public float GetMasterLevel()
    {
        float value;
        bool result = mixer.GetFloat("volume", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }
    public void Toggle(bool newValue)
    {
        dialogueToggle = newValue;
    }

    public void MusicSlider(float volume)
    {

        mixer.SetFloat("volume", volume);

    }
}
