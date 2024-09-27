using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMesh : MonoBehaviour
{
    public Vector3 myVector = new Vector3(3,4,0);
    Mesh mesh;
    float angle = 0;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        angle = Mathf.Atan2(myVector.y, myVector.x);
        transform.rotation = Quaternion.Euler(0,0,angle * Mathf.Rad2Deg);
        drawShape();
        
    }


    void drawShape()
    {
        float arrowHeight = .5f;

        float headHeight = 1.5f;
        float headWidth = 2;
        float arrowWidth = Mathf.Abs(myVector.magnitude - headWidth);

        mesh.Clear();

        mesh.vertices = new Vector3[]{
            new Vector3(0,arrowHeight,0),
            new Vector3(arrowWidth,arrowHeight,0),
            new Vector3(arrowWidth,headHeight,0),
            new Vector3(arrowWidth + headWidth,0,0),
            new Vector3(arrowWidth,-headHeight,0),
            new Vector3(arrowWidth,-arrowHeight,0),
            new Vector3(0,-arrowHeight,0)

        };
        mesh.triangles = new int[]
        {
            0,1,5,
            5,6,0,
            2,3,4
        };
        mesh.RecalculateNormals();
    }
        
}
