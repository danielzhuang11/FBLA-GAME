
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public Text healthDisplay;

    // Update is called once per frame

    void Update()
    {
        
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            }

            if (Input.GetAxisRaw("Vertical") > -.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            }
        if (health <= 0)
        {

            SceneManager.LoadScene("GameOver");
        }
        healthDisplay.text = "HEALTH: " + health;
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
