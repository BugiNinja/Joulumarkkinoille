using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * 1; //YKKÖNEN KORVATTAVA VAIKKAPA "SPEED" MUUTTUJALLA!
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "PlayArea")
        {
            Destroy(gameObject);
        }
    }
}
