using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternWave : MonoBehaviour
{
    public AudioClip fireSound;
    AudioSource asrc;
    public GameObject[] bullets = new GameObject[2];
    int playerNumber = 1;
    public int numberOfShots;
    int shotsFired = 0;

    PlayerController pc;

    public float fireRate, spread;
    float nextFire, bulletDirection;

    private void Start()
    {
        pc = gameObject.GetComponentInParent<PlayerController>();
        playerNumber = pc.playerNumber;

        asrc = GetComponent<AudioSource>();
        asrc.PlayOneShot(fireSound);

        nextFire = -fireRate;
    }

    void FixedUpdate()
    {
        if (fireRate < Time.time - nextFire)
        {
            bulletDirection = -spread + ((2 * spread)/(numberOfShots-1)) * shotsFired;
            Instantiate(bullets[playerNumber - 1], transform.position, transform.rotation * Quaternion.Euler(0, 0, bulletDirection));
            nextFire = Time.time;
            shotsFired++;
        }

        if (shotsFired >= numberOfShots)
        {
            Destroy(gameObject);
        }
    }
}
