using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerScript : MonoBehaviour
{

    public float speed;
    Rigidbody2D _rbody;
    SpriteRenderer _srenderer;
    Vector2 direction = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
   
        //base direction vector
        float xDir = Input.GetAxis("Horizontal");
        float yDir = 0;
        if (xDir == 0)
        {
            yDir = Input.GetAxis("Vertical");
        }
        Vector2 direction = (new Vector2(xDir, yDir)).normalized;


        //set direction based on direction
        _rbody.velocity = direction * speed;


        //continue sliding if not stopped by wall
        Vector2 current = _rbody.velocity;
        direction = current.normalized;
        Vector2 newVelocity = direction * speed;
        _rbody.velocity = newVelocity;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _srenderer.color = Color.blue;
    }








}
