using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public void Player1Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Player2Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

