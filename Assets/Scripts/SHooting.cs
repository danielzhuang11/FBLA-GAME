using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHooting : MonoBehaviour {

    public GameObject shot;
    private Transform playerpos;
	// Use this for initialization
	void Start () {
        playerpos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, playerpos.position, Quaternion.identity);
        }
	}
}
