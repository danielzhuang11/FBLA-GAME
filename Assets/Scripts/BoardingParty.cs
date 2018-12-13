using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardingParty : MonoBehaviour {
      
    public bool active = false;
    Vector3 direction;
    public float speed;

	// Use this for initialization
	void Start () {
        
        
        direction = Vector3.down;
       

        
	}
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
           
           
            transform.up = direction;
            transform.position += direction * speed * Time.deltaTime;
        }



	}

    void UpdateText()
    {


    }
    void OnTriggerEnter2D(Collider2D other)
    {


        GameController gc = GameObject.Find("Game Controller").GetComponent<GameController>();
        if (other.CompareTag("PlayerBig"))
        {

            gc.gameOver();
        }

        

        string thing="";
        if (other.CompareTag("Projectile") && gc.level == 2)
        {
            
            if (this.gameObject.name == "one") 
            {thing = "1";} 
            else if (this.gameObject.name=="two")
            { thing ="2" ;}  
            else if (this.gameObject.name=="three") 
            { thing ="3";} 
            else if (this.gameObject.name=="four") 
            {thing = "4";}
                
            gc.checkAns(thing);

        }
    }

    
}
