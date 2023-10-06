using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MSManagerScript : MonoBehaviour
{
    public int _level;
    public GameObject _prefabRing;
    public Text _movesText;
    public int moves = 100;
    public int chipCount = 0;
    public GameObject _closedDoor;
    public GameObject _openDoor;
    GameObject[] chips;
    PlayerScript _player;


    // Start is called before the first frame update
    void Start()
    {
        moves = 100;
        _player = FindObjectOfType<PlayerScript>();
        _openDoor.SetActive(false);
        _closedDoor.SetActive(true);

        chips = GameObject.FindGameObjectsWithTag("Ring");
        foreach (GameObject chip in chips)
        {
            chip.SetActive(false);
        }
        print("moves" + moves);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(moves <= 0)
        {
            if(_level == 1){
                PlayerPrefs.SetInt("success1", 0);
            } else if(_level == 2)
            {
                PlayerPrefs.SetInt("success2", 0);
            }
            _player.failGame();
        }

        if (chipCount == 9)
        {
            _closedDoor.SetActive(false);
            _openDoor.SetActive(true);
        }
        _movesText.text = "Moves: " + moves.ToString();
    }

    public void HitCoin()
    {
        if (_level == 1)
        {
            Instantiate(_prefabRing, new Vector3(10, 5, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(1.5f, 5, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(1.5f, 2.5f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(7.5f, 2.5f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(8.5f, .25f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(13.5f, .25f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(1, -4.5f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(-1.5f, 2.5f, 0), Quaternion.identity);
            Instantiate(_prefabRing, new Vector3(-9.5f, 4.3f, 0), Quaternion.identity);
        } else
        {
            print("setChips");
            foreach (GameObject chip in chips)
            {
                chip.SetActive(true);
            }
        }
    }
    public void LevelComplete()
    {
        _openDoor.SetActive(false);
        _closedDoor.SetActive(true);

        if (_level == 1)
        {
            PlayerPrefs.SetInt("success1", 1);
            SceneManager.LoadScene("Level2");
        } else if(_level == 2)
        {
            PlayerPrefs.SetInt("success2", 2);
            SceneManager.LoadScene("EndScreen");
        }

    }
}
