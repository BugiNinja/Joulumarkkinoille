using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternShotgun : MonoBehaviour
{
    public AudioClip fireSound;
    AudioSource asrc;

    public GameObject[] pellets = new GameObject[2];

    PlayerController pc;

    public int numberOfPelletsPerShot, spread;
    int playerNumber = 1;
    float destroyAfter = 1.248f;

    private void Start()
    {
        pc = gameObject.GetComponentInParent<PlayerController>();
        playerNumber = pc.playerNumber;

        asrc = GetComponent<AudioSource>();
        asrc.PlayOneShot(fireSound, 0.5f);

        for (int pelletsFired = 0; pelletsFired <= numberOfPelletsPerShot; pelletsFired++)
        {
            Instantiate(pellets[playerNumber - 1], transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-spread, spread)));
        }
    }

    void FixedUpdate()
    {
        destroyAfter -= Time.deltaTime;
        if (destroyAfter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
