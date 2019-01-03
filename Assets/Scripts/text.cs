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
       transform.position = (target.transform.position);

        //GameObject levels = GameObject.Find("Game Controller");
 
        if (GameController.level >= 2)
        {

            char answer = System.Convert.ToChar(GameController.assignment[(int.Parse(this.gameObject.name)) - 1]);
           answers.text = answer.ToString();
            
        }
     // public Vector2 offset = new Vector2 (example x, example y);
      
    }
 }

