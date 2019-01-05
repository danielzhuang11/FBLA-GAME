using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Questions : MonoBehaviour {
    public Text question;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public string newQuestion()
    {


        string path = "Assets/Resources/test.txt";
        string[] lines = System.IO.File.ReadAllLines(path);
        int random = 1;
        while (random % 2 != 0)
        {
            random = Random.Range(0, lines.Length);
        }



        question.text = lines[random];


        Debug.Log(lines[random + 1]);
        return (lines[random + 1]);

    }
    
}
