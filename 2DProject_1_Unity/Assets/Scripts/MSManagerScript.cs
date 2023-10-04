using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSManagerScript : MonoBehaviour
{

    public GameObject _prefabRing;
    public Text _movesText;
    public int moves;
    public int chipCount = 0;
    private float _startTime;
    public GameObject _closedDoor;
    public GameObject _openDoor;

    // Start is called before the first frame update
    void Start()
    {
        moves = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(chipCount == 9)
        {
            Destroy(_closedDoor);
            Instantiate(_openDoor, new Vector3(-9, 1, 0), Quaternion.identity);
        }
        _movesText.text = "Moves: " + moves.ToString();
    }

    public void HitCoin()
    {
        _startTime = Time.time;
        Instantiate(_prefabRing, new Vector3(10,5,0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(1.5f, 5, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(1.5f, 2.5f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(7.5f, 2.5f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(8.5f, .25f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(13.5f, .25f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(1, -4.5f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(-1.5f, 2.5f, 0), Quaternion.identity);
        Instantiate(_prefabRing, new Vector3(-9.5f, 4.3f, 0), Quaternion.identity);
    }
}
