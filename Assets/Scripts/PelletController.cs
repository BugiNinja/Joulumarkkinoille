using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * 1 * Random.Range(1f,3f); //YKKÖNEN KORVATTAVA VAIKKAPA "SPEED" MUUTTUJALLA!
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayArea")
        {
            Destroy(gameObject);
        }
    }
}
