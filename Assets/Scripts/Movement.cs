using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    public float speed;
    private Vector2 moveVelocity;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        
        mousePosition.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
          
        
        
	}
   
    
   
}
