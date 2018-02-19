using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSplitter : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D c;

    public float speed, distanceBeforeSplitting, splitSector;
    Vector3 initialTransform = new Vector3();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initialTransform = transform.position;

        rb.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        if( Mathf.Abs(transform.position.magnitude - initialTransform.magnitude) >= distanceBeforeSplitting)
        {
            Instantiate(this.gameObject, transform.position, transform.rotation * Quaternion.Euler(0, 0, -(splitSector / 2)));
            Instantiate(this.gameObject, transform.position, transform.rotation * Quaternion.Euler(0, 0, (splitSector / 2)));
            Destroy(this.gameObject);
        }
    }
}
