using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class text : MonoBehaviour {

   public Text answers;
 public GameObject target;
 void Start()
 {
     
     
 }
    void Update () 
    {
        transform.position = (target.transform.position + new Vector3(2.0f, -0.5f,0.0f));

        GameObject levels = GameObject.Find("Game Controller");
        GameController script = levels.GetComponent<GameController>();
        if (script.level >= 2)
        {

            char answer = System.Convert.ToChar(script.assignment[(int.Parse(this.gameObject.name)) - 1]);
           answers.text = answer.ToString();
            
        }
     // public Vector2 offset = new Vector2 (example x, example y);
      
    }
 }

