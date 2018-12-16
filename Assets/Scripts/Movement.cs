using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Text healthDisplay;
    public float speed;
   
    private Vector2 moveVelocity;
    public int health;
    
	// Use this for initialization
	void Start () {
       
      
	}
	
	// Update is called once per frame
	void Update () {

        if (!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
        {

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

            mousePosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            healthDisplay.text = "HEALTH: " + health;
            if (health <= 0)
            {

                SceneManager.LoadScene("GameOver");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
             health--;
             Destroy(other.gameObject);
        }
    }
   
    
   
}
