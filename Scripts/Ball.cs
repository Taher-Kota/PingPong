using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D mybody;
    [SerializeField]
    float speed;
    Vector2 MovingDirection;
    float ballposY, paddleposY;
    int hitcounter;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        MovingDirection = Vector2.zero;
    }

    private void Start()
    {
        Invoke("InitialMovement", 2f);
    }
    void FixedUpdate()
    {
        mybody.velocity = (MovingDirection).normalized * speed;
    }
    private void Update()
    {
        if (hitcounter > 5 && speed <= 15f)
        {
            hitcounter = 0;
            speed += .5f;
        }
    }
    void InitialMovement()
    {
        MovingDirection = Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") hitcounter++;

        if (mybody.velocity.x > 0)
        {
            MovingDirection.x = 1;
        }
        else
        {
            MovingDirection.x = -1;
        }

        ballposY = transform.position.y;
        paddleposY = collision.transform.position.y;

        float offset = (ballposY - paddleposY) / collision.collider.bounds.size.y;
        if (offset != 0)
        {
            MovingDirection.y = offset;
        }
        else
        {
            MovingDirection.y = .25f;
        }
    }
}
