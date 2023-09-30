using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class FishScript : MonoBehaviour
{
    public Text timerText;
    public float speed;
    public GameObject queueBall;

    float _startTime;
    Rigidbody2D _rbody;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _startTime = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        if(_startTime - ((int)Time.time) < 0)
        {
            Time.timeScale = 0;

        }
        timerText.text ="Time: " +(_startTime - ((int)Time.time)).ToString();


        Vector2 direction = Vector2.zero;
         if(Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }

        _rbody.velocity = direction.normalized*speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Pocket"))
        {
            Instantiate(queueBall, new Vector3(-6, 0, 0), quaternion.identity);
            Destroy(gameObject);
            
        }
    }

    void axisDirection()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector2 direction = (new Vector2(xDir, yDir)).normalized;

        _rbody.velocity = direction.normalized * speed;
    }
}
