using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;
    int p1Wins = 0;
    int p2Wins = 0;
    public KeyCode fireP1 { get; set; }
    public KeyCode upP1 { get; set; }
    public KeyCode downP1 { get; set; }
    public KeyCode leftP1 { get; set; }
    public KeyCode rightP1 { get; set; }
    public KeyCode fireP2 { get; set; }
    public KeyCode upP2 { get; set; }
    public KeyCode downP2 { get; set; }
    public KeyCode leftP2 { get; set; }
    public KeyCode rightP2 { get; set; }

    public AudioClip[] aClips = new AudioClip[2];
    AudioSource asrc;

    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
        fireP1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireP1", "E"));
        upP1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upP1", "W"));
        downP1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downP1", "S"));
        leftP1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftP1", "A"));
        rightP1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightP1", "D"));
        fireP2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireP2", "M"));
        upP2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upP2", "UpArrow"));
        downP2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downP2", "DownArrow"));
        leftP2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftP2", "LeftArrow"));
        rightP2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightP2", "RightArrow"));

        asrc = GetComponent<AudioSource>();

        asrc.clip = aClips[0];
        asrc.Play();
    }
    void Start()
    {

    }
    public void Player1Died()
    {
        if (p1Wins + p2Wins == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            p1Wins++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Player2Died()
    {
        if (p1Wins + p2Wins == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            p2Wins++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
