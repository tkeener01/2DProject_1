using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class SquirrelScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D _rbody;
    // Start is called before the first frame update
    void Start()
    {
       _rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector2 dir = (new Vector2(xDir, yDir)).normalized;

        _rbody.velocity = dir.normalized * speed;
    }
}
