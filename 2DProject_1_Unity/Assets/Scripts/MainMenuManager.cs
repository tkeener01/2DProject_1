using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("success1"))
        {
            PlayerPrefs.DeleteKey("success1"); //if the player won the game previously
        }
        if (PlayerPrefs.HasKey("success2"))
        {
            PlayerPrefs.DeleteKey("success2"); //if the player won the game previously
        }
        if (!PlayerPrefs.HasKey("low")) //value of the overall lowest score
        {
            PlayerPrefs.SetInt("low", 100);
        }

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
