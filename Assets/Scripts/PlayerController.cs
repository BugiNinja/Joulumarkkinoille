using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidb;

    public int indexOfPattern;
    public int playerNumber;
    public GameObject[] pattern = new GameObject[4];
    private GameObject firingPattern;
    private Quaternion firingDirection;

    public float movementSpeed, fireRate;
    private float nextFire;

    private string horizontalInput, verticalInput, fireInput;

    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();

        //automaattinen pelaaja numeron etsiminen
        int.TryParse(gameObject.name.Substring(gameObject.name.Length - 1, 1), out playerNumber);

        //pelaajan ampumasuunnan valitseminen
        if (playerNumber == 1)
        {
            firingDirection = Quaternion.Euler(0, 0, -90);
        }
        if (playerNumber == 2)
        {
            firingDirection = Quaternion.Euler(0, 0, 90);
        }


        //PELAAJA INPUT NIMEÄMINEN
        horizontalInput = "Horizontal" + playerNumber.ToString();
        verticalInput = "Vertical" + playerNumber.ToString();
        fireInput = "Fire" + playerNumber.ToString();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        if (playerNumber == 1)
        {
            if (Input.GetKey(GameManager.GM.upP1))
            {
                moveHorizontal = 1;
            }
            if (Input.GetKey(GameManager.GM.downP1))
            {
                moveHorizontal = -1;
            }
            if (Input.GetKey(GameManager.GM.leftP1))
            {
                moveVertical = -1;
            }
            if (Input.GetKey(GameManager.GM.rightP1))
            {
                moveVertical = 1;
            }
        }
        else if (playerNumber == 2)
        {
            if (Input.GetKey(GameManager.GM.upP2))
            {
                moveHorizontal = 1;
            }
            if (Input.GetKey(GameManager.GM.downP2))
            {
                moveHorizontal = -1;
            }
            if (Input.GetKey(GameManager.GM.leftP2))
            {
                moveVertical = -1;
            }
            if (Input.GetKey(GameManager.GM.rightP2))
            {
                moveVertical = 1;
            }
        }



        Vector2 movement = new Vector2(moveVertical, moveHorizontal);
        movement = movement.normalized * Time.deltaTime;
        rigidb.velocity = movement * movementSpeed;

    }

    //AMPUMINEN JA PATTERNIT
    private void Shoot()
    {
        if (playerNumber == 1)
        {
            if (Input.GetKey(GameManager.GM.fireP1) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FirePattern(indexOfPattern);
            }
        }
        else if (playerNumber == 2)
        {
            if (Input.GetKey(GameManager.GM.fireP2) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FirePattern(indexOfPattern);
            }
        }

    }

    void FirePattern(int index)
    {
        if (index < 0 || index > pattern.Length)
        {
            Debug.LogError("Invalid index of pattern! From: " + gameObject);
            return;
        }
        firingPattern = Instantiate(pattern[index], transform.position, firingDirection);
        firingPattern.transform.parent = transform;
    }

    //KUOLEMINEN
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((playerNumber == 1 && other.gameObject.tag == "Player 2 Bullet") || (playerNumber == 2 && other.gameObject.tag == "Player 1 Bullet"))
        {
            Destroy(this.gameObject);

            if (playerNumber == 1)
            {
                GameManager.GM.Player1Died();
            }
            else if (playerNumber == 2)
            {
                GameManager.GM.Player2Died();
            }
        }
        else
        {
            Debug.Log("Unhandled player collison! From: " + gameObject);
        }
    }
}