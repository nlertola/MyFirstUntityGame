using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dart : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, Speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Backboard")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
