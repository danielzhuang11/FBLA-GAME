using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    Vector3 mousePosition;
    Vector3 direction;
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0F;
        direction = (mousePosition - transform.position).normalized;
        
    }

    void Update()
    {


        transform.up = direction;
        transform.position += direction * speed * Time.deltaTime;
    }
}
