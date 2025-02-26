using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] GameObject runner;
    [SerializeField] Animator animator;

    enum State { run1, jump1};
    State myState = State.run1;
    float y0;

    Vector3 velocity = Vector3.zero;
    Vector3 gravity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        y0 = runner.transform.position.y;
        animator.speed = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (myState == State.run1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                velocity = new Vector3(0, 4*7.5f/2, 0);
                gravity = new Vector3(0, -40, 0);
                myState = State.jump1;
                animator.speed = 1;
            }
        }
        if (myState == State.jump1)
        {
            velocity += gravity * Time.deltaTime;
            runner.transform.position += velocity * Time.deltaTime;
            if (runner.transform.position.y < y0) 
            {
                velocity = Vector3.zero;
                gravity = Vector3.zero;
                myState = State.jump1;
                animator.speed = 0;
            }
        }
    }
}
