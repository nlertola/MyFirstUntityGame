using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int score = 0;
    public Text scoreUI;
    public float Speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;
    public GameObject explosionEffect;
    bool movingRight = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
        }
        if (transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
        }
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            rb.MovePosition(rb.position + new Vector2(rightPoint.position.x + Speed, 0f) * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(leftPoint.position.x - Speed, 0f) * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dart")
        {
            score++;
            scoreUI.text = "Score: " + score;
            Speed += .25f;
            Instantiate(explosionEffect, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
