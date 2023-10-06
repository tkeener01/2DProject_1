using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("low"))
        {
            PlayerPrefs.SetInt("low", 100);
        }
        PlayerPrefs.SetInt("success1", 0); //success of 1st level
        PlayerPrefs.SetInt("success2", 0); //success of 2nd level
        PlayerPrefs.SetInt("success", 0); //success of whole game
        PlayerPrefs.SetInt("moves1", 100); //move count 1st level
        PlayerPrefs.SetInt("moves2", 100); //move count 2nd level

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("level1");
    }
}
