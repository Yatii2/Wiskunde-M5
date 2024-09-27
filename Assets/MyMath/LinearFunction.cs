using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearFunction 
{
    public float slope;
    public float intercept;

    public float getY(float x) 
    { 
        return slope * x + intercept; 
    }
}
