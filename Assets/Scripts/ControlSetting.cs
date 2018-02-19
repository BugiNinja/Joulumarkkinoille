using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlSetting : MonoBehaviour
{

    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;


    void Start()
    {

        menuPanel = transform.Find("Panel");
        waitingForKey = false;

        for (int i = 0; i < menuPanel.childCount; i++)
        {
            if (menuPanel.GetChild(i).name == "upP1")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.upP1.ToString();
            else if (menuPanel.GetChild(i).name == "downP1")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.downP1.ToString();
            else if (menuPanel.GetChild(i).name == "leftP1")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.leftP1.ToString();
            else if (menuPanel.GetChild(i).name == "rightP1")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.rightP1.ToString();
            else if (menuPanel.GetChild(i).name == "fireP1")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.fireP1.ToString();
            else if (menuPanel.GetChild(i).name == "upP2")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.upP2.ToString();
            else if (menuPanel.GetChild(i).name == "downP2")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.downP2.ToString();
            else if (menuPanel.GetChild(i).name == "leftP2")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.leftP2.ToString();
            else if (menuPanel.GetChild(i).name == "rightP2")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.rightP2.ToString();
            else if (menuPanel.GetChild(i).name == "fireP2")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.fireP2.ToString();
            else if (menuPanel.GetChild(i).name == "return")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = "return";
        }
    }


    void Update()
    {

    }

    void OnGUI()
    {
        /*keyEvent dictates what key our user presses
		 * bt using Event.current to detect the current
		 * event
		 */
        keyEvent = Event.current;

        //Executes if a button gets pressed and
        //the user presses a key
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }

    /*Buttons cannot call on Coroutines via OnClick().
	 * Instead, we have it call StartAssignment, which will
	 * call a coroutine in this script instead, only if we
	 * are not already waiting for a key to be pressed.
	 */
    public void StartAssignment(string keyName)
    {
        if(keyName == "return")
        {
            SceneManager.LoadScene(0);
        }
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    //Assigns buttonText to the text component of
    //the button that was pressed
    public void SendText(Text text)
    {
        buttonText = text;
    }

    //Used for controlling the flow of our below Coroutine
    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    /*AssignKey takes a keyName as a parameter. The
	 * keyName is checked in a switch statement. Each
	 * case assigns the command that keyName represents
	 * to the new key that the user presses, which is grabbed
	 * in the OnGUI() function, above.
	 */
    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key

        switch (keyName)
        {
            case "upP1":
                GameManager.GM.upP1 = newKey; //Set forward to new keycode
                buttonText.text = GameManager.GM.upP1.ToString(); //Set button text to new key
                PlayerPrefs.SetString("forwardKey", GameManager.GM.upP1.ToString()); //save new key to PlayerPrefs
                break;
            case "downP1":
                GameManager.GM.downP1 = newKey; //set backward to new keycode
                buttonText.text = GameManager.GM.downP1.ToString(); //set button text to new key
                PlayerPrefs.SetString("backwardKey", GameManager.GM.downP1.ToString()); //save new key to PlayerPrefs
                break;
            case "leftP1":
                GameManager.GM.leftP1 = newKey; //set left to new keycode
                buttonText.text = GameManager.GM.leftP1.ToString(); //set button text to new key
                PlayerPrefs.SetString("leftKey", GameManager.GM.leftP1.ToString()); //save new key to playerprefs
                break;
            case "rightP1":
                GameManager.GM.rightP1 = newKey; //set right to new keycode
                buttonText.text = GameManager.GM.rightP1.ToString(); //set button text to new key
                PlayerPrefs.SetString("rightKey", GameManager.GM.rightP1.ToString()); //save new key to playerprefs
                break;
            case "fireP1":
                GameManager.GM.fireP1 = newKey; //set jump to new keycode
                buttonText.text = GameManager.GM.fireP1.ToString(); //set button text to new key
                PlayerPrefs.SetString("jumpKey", GameManager.GM.fireP1.ToString()); //save new key to playerprefs
                break;
            case "upP2":
                GameManager.GM.upP2 = newKey; //Set forward to new keycode
                buttonText.text = GameManager.GM.upP2.ToString(); //Set button text to new key
                PlayerPrefs.SetString("forwardKey", GameManager.GM.upP2.ToString()); //save new key to PlayerPrefs
                break;
            case "downP2":
                GameManager.GM.downP2 = newKey; //set backward to new keycode
                buttonText.text = GameManager.GM.downP2.ToString(); //set button text to new key
                PlayerPrefs.SetString("backwardKey", GameManager.GM.downP2.ToString()); //save new key to PlayerPrefs
                break;
            case "leftP2":
                GameManager.GM.leftP2 = newKey; //set left to new keycode
                buttonText.text = GameManager.GM.leftP2.ToString(); //set button text to new key
                PlayerPrefs.SetString("leftKey", GameManager.GM.leftP2.ToString()); //save new key to playerprefs
                break;
            case "rightP2":
                GameManager.GM.rightP2 = newKey; //set right to new keycode
                buttonText.text = GameManager.GM.rightP2.ToString(); //set button text to new key
                PlayerPrefs.SetString("rightKey", GameManager.GM.rightP2.ToString()); //save new key to playerprefs
                break;
            case "fireP2":
                GameManager.GM.fireP2 = newKey; //set jump to new keycode
                buttonText.text = GameManager.GM.fireP2.ToString(); //set button text to new key
                PlayerPrefs.SetString("jumpKey", GameManager.GM.fireP2.ToString()); //save new key to playerprefs
                break;
        }

        yield return null;
    }
}


