using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Start")
                {
                    SceneManager.LoadScene(1);
                }
                else if (hit.transform.name == "Controls")
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }
}