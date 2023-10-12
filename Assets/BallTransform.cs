using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallTransform : MonoBehaviour
{
    public Vector3 scaleChange;
    public Vector3 scaleLimit;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.localScale.magnitude < scaleLimit.magnitude)
        {
            transform.localScale += scaleChange;
        }
        
    }
}
