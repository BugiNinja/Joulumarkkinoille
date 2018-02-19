using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpray : MonoBehaviour
{
    public AudioClip fireSound;
    AudioSource asrc;
    public GameObject[] bullets = new GameObject[2];
    int playerNumber = 1;
    public int numberOfShots, spread;
    int shotsFired = 0;

    PlayerController pc;

    public float fireRate;
    float nextFire;

    private void Start()
    {
        pc = gameObject.GetComponentInParent<PlayerController>();
        playerNumber = pc.playerNumber;

        asrc = GetComponent<AudioSource>();
        asrc.PlayOneShot(fireSound, 0.5f);

        nextFire = -fireRate;
    }

    void FixedUpdate()
    {
        float randomRotationDegrees = Random.Range(-spread, spread);

        if (fireRate < Time.time - nextFire)
        {
            Instantiate(bullets[playerNumber - 1], transform.position, transform.rotation * Quaternion.Euler(0, 0, randomRotationDegrees));
            nextFire = Time.time;
            shotsFired++;
        }

        if(shotsFired >= numberOfShots)
        {
            Destroy(gameObject);
        }
    }
}
