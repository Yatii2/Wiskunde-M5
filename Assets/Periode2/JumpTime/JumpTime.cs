using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class JumpTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject Brick;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;
    enum States { wait, active, finished }
    States myState = States.wait;

    float t = 0f;
    float y0;

    void Start()
    {
        timer.text = t.ToString();
        y0 = Brick.transform.position.y;
    }

    void Update()
    {
        if (myState == States.wait)
        {
            if (Input.GetMouseButtonUp(0)) 
            {
                acceleration = new Vector3(0,-1,0);
                velocity = new Vector3(0, 4, 0);
                myState = States.active;
            }
        }
        if (myState == States.active)
        {
            velocity += acceleration * Time.deltaTime;
            Brick.transform.position += velocity * Time.deltaTime;
            t += Time.deltaTime;
            timer.text = t.ToString("F3");
            if (Brick.transform.position.y < y0)
            {
                myState = States.finished;
            }
        }
        if (myState == States.finished)
        {
            Brick.transform.position = new Vector3(Brick.transform.position.x, y0, 0);
            myState = States.wait;
            t = 0f;
        }
    }
}
