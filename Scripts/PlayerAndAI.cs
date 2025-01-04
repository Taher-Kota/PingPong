using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndAI : MonoBehaviour
{
    Vector2 Movement;
    public bool isAI;
    public float Speed;
    public GameObject Ball;
    void Start()
    {
        Movement = Vector2.zero;
    }

    void Update()
    {
        if (isAI)
        {
            MoveAI();
        }
        else
        {
            MovePlayer();
        }
        transform.Translate(Movement * Speed * Time.deltaTime);
        Vector2 temp = transform.position;
        temp.y = Mathf.Clamp(temp.y, -3.4f, 3.4f);
        transform.position = temp;
    }

    void MoveAI()
    {
        if (transform.position.y > Ball.transform.position.y + .5f)
        {
            Movement = new Vector2(0, -1);
        }
        else if(transform.position.y < Ball.transform.position.y - .5f)
        {
            Movement = new Vector2(0, 1);
        }
        else
        {
            Movement = Vector2.zero;
        }
    }

    void MovePlayer()
    {
        Movement = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }
}
