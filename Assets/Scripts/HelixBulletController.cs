using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixBulletController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D c;

    Quaternion initialRotation;

    float bulletDirection;
    public float speed, sineFrequency, sineAmplitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initialRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        bulletDirection = Mathf.Sin(Time.time * sineFrequency) * sineAmplitude;

        transform.rotation = initialRotation * Quaternion.Euler(0, 0, bulletDirection);

        rb.velocity = transform.up * speed;
    }
}
