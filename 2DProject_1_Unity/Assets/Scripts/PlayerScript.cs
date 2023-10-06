using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SortingLayer))]
[RequireComponent(typeof(Renderer))]
public class PlayerScript : MonoBehaviour
{

    public float _speed;
    MSManagerScript _managerScript;
    Rigidbody2D _rbody;
    SpriteRenderer _spriteRenderer;
    Renderer _renderer;

    bool _moving = false;
    bool _getsMove = false; //keeps track if # moves needs updated
    int _oldRotation = 0; //used to decide if _getsMove needs updated
    // Start is called before the first frame update
    void Start()
    {
        _getsMove = false;
        _rbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _managerScript = FindObjectOfType<MSManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(_rbody.velocity.magnitude <= 0 )
        {
            //check if # moves should be updates
            if(_getsMove) 
            { 
                _managerScript.moves--; 
                _getsMove = false; 
            }
            _moving = false;
            _rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        float force = _speed;
        if (!_moving)
        {
            // get player input
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _rbody.velocity = Vector2.up * force;
                _rbody.rotation = 0; 
                _moving = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                _rbody.velocity = Vector2.down * force;
                _rbody.rotation = 180;
                _moving = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _rbody.velocity = Vector2.right * force;
                _rbody.rotation = 270;
                _moving = true;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rbody.velocity = Vector2.left * force;
                _rbody.rotation = 90;
                _moving = true;

            }
            //checks if player actually moved on button press
            if(_oldRotation != _rbody.rotation)
            {
                _getsMove = true;
                _oldRotation = (int)_rbody.rotation;
            }
        }
        else
        {
            //player keeps moving in chosen direction
            Vector2 current = _rbody.velocity.normalized;
            float x = Math.Abs(current.x);
            float y = Math.Abs(current.y);
            if (x >= y) //restricts movement in any other direction
            {
                _rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else {
                _rbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            Vector2 newVelocity = current * force;
            _rbody.velocity = newVelocity;
        }

    }

    public void failGame()
    {
        PlayerPrefs.SetInt("success", 0);
        SceneManager.LoadScene("EndScreen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToString() == "Goal")
        {
            endGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.ToString() == "Coin")
        {
            _managerScript.HitCoin();
            collision.gameObject.SetActive(false);
            
        }
        if (collision.gameObject.tag.ToString() == "Ring")
        {
            _managerScript.chipCount++;
            collision.gameObject.SetActive(false);
        }

    }

    private void endGame()
    {
        _rbody.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Default");
        _managerScript.LevelComplete();
    }

}
