using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform lookTarget;
    public Transform walkTarget;

    void Update()
    {
        float singleStep = speed * Time.deltaTime;
        Vector3 targetDirection = lookTarget.position - transform.position;
        Vector3 targetPosition = new(walkTarget.position.x, transform.position.y, walkTarget.position.z);
        float distance = (targetPosition - transform.position).magnitude;
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Vector3 position = Vector3.MoveTowards(transform.position, targetPosition, singleStep);
        transform.SetPositionAndRotation(distance > 1.5 ? position : transform.position, Quaternion.LookRotation(direction));
    }
}
