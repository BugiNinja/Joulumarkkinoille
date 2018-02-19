using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSineWave : MonoBehaviour
{
    public GameObject bullet;

    public int numberOfShots;
    int shotsFired = 0;

    public float fireRate, sineAmplitude, sineFrequency;
    float nextFire, bulletDirection;

    private void Start()
    {
        nextFire = -fireRate;
    }

    void FixedUpdate()
    {
        if (fireRate < Time.time - nextFire)
        {
            bulletDirection = Mathf.Sin(Time.time * sineFrequency) * sineAmplitude;
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, bulletDirection));
            nextFire = Time.time;
            shotsFired++;
        }

        if (shotsFired >= numberOfShots)
        {
            Destroy(gameObject);
        }
    }
}
