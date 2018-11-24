
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //private Rigidbody2D rb2d;
    public float moveSpeed;
    /*  private void Start()
      {
          rb2d = GetComponent<Rigidbody2D>();
      }
      void FixedUpdate()
      {
          float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");
          Vector2 movement = new Vector2(moveHorizontal, moveVertical);
          rb2d.AddForce(movement * moveSpeed);
      }*/


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
    }
}
