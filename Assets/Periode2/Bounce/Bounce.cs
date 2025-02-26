using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] GameObject Ball;

    Vector3 Velocity = new Vector3(2, 3, 0);
    Vector3 Acceleration = new Vector3 (0, -1, 0);
    Vector2 Min;
    Vector2 Max;

    void Start()
    {
        Min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }
    void Update()
    {
        Velocity += Acceleration * Time.deltaTime;
        Ball.transform.position += Velocity * Time.deltaTime;

        if (Ball.transform.position.y > Max.y - Ball.transform.localScale.y / 2)
        {
            Velocity = new Vector3(Velocity.x, -Velocity.y, 0);
        }

        if (Ball.transform.position.x > Max.x - Ball.transform.localScale.x / 2)
        {
            Velocity = new Vector3(-Velocity.x, Velocity.y, 0);
        }

        if (Ball.transform.position.y < Min.y + Ball.transform.localScale.y / 2)
        {
            Velocity = new Vector3(Velocity.x, -Velocity.y, 0);
        }

        if (Ball.transform.position.x < Min.x + Ball.transform.localScale.x / 2)
        {
            Velocity = new Vector3(-Velocity.x, Velocity.y, 0);
        }
    }
}