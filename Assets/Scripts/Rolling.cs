using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour {
    Rigidbody2D rb;
    public float speed = 100;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.angularVelocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
