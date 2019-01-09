using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardingParty : MonoBehaviour {
    Vector3 direction;
    public float speed;
    private bool flyingback;
	// Use this for initialization

	void Start () {

        speed += UponLoadTitle.streak / 10;
        direction = Vector3.down;
     
	}
	
	// Update is called once per frame
	void Update () {

        if ((!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive))
        {
            transform.up = direction;
            transform.position += direction * speed * Time.deltaTime;
        }



	}

    public void flyback()
    {
        Transform Base = GameObject.Find("EnemyBig").GetComponent<Transform>();
       

            direction = (Base.position - transform.position).normalized;
            transform.up = direction;
            transform.position += direction * speed * Time.deltaTime;
           
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        GameController gc = GameObject.Find("Game Controller").GetComponent<GameController>();
        
        if (other.CompareTag("PlayerBig"))
        {
            gc.gameOver();
            flyback();
        }

     

        string thing="";
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other);
            if (this.gameObject.name == "AParty") 
            {thing = "A";} 
            else if (this.gameObject.name=="BParty")
            { thing ="B" ;}  
            else if (this.gameObject.name=="CParty") 
            { thing ="C";} 
            else if (this.gameObject.name=="DParty") 
            {thing = "D";}
            
            gc.checkAns(thing);
            
        }
      
    }

    
}
