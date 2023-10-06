using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public GameObject _successRoomba;
    public GameObject _failRoomba;
    public GameObject _failRoombaStation;
    public Text _Results;

    // Start is called before the first frame update
    void Start()
    {
        if(1 == PlayerPrefs.GetInt("success"))
        {
            _Results.text = "Great Job Buddy :(";
            _successRoomba.SetActive(true);
            _failRoomba.SetActive(false);
            _failRoombaStation.SetActive(false);
        }
        else
        {
            _Results.text = "You Ran Out Of Battery :,(";
            _successRoomba.SetActive(false);
            _failRoomba.SetActive(true);
            _failRoombaStation.SetActive(true);
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
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
