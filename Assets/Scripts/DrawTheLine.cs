using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTheLine : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    LinearFunction f = new LinearFunction();
    [SerializeField] DraggablePoint A;

    void Start()
    {
        A.color = Color.green;
        f.slope = 0.5f;
        f.intercept = 0f;

        lineRenderer.SetPosition(0, new Vector3(-3,f.getY(-3),0));
        lineRenderer.SetPosition(1, new Vector3(3, f.getY(3),0));
    }

    void Update()
    {
        if(A.transform.position.y > f.getY(A.transform.position.x))
        {
            A.color = Color.red;
        } else
        {
            A.color = Color.green;
        }
        
    }
}
