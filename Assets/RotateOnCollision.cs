using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnCollision : MonoBehaviour
{
    public Transform customPivot;
    private bool isTouched = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RollingSphere")
        {
            //Debug.Log("Sphere arrived at rotating gate position");
            isTouched = true;
        }
    }

    private void Update()
    {
        if (isTouched && transform.localEulerAngles.x > 30)
        {
            transform.RotateAround(customPivot.position, Vector3.left, 20 * Time.deltaTime);
            
        }
    }
    // Нужно перенести плавное вращение в Update, начинать при активации OnCollisionEnter
}
