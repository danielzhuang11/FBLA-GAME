using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    public float speed;
    public GameObject target;
    Vector3 direction;
    // Use this for initialization
    public GameObject missile;

    public void FireMissile(GameObject Target)
    {
        target = Target;
        Instantiate(missile, GameObject.Find("Player").transform.position, Quaternion.identity);

        GameObject.Find("choosePanel").SetActive(false);

    }
	void Start () {
        direction = (target.transform.position  - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.up = direction;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,speed * Time.deltaTime);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("boardingParty"))
        {
            Destroy(gameObject);

        }
    }
   
}
