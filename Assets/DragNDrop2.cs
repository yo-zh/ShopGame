using UnityEngine;

public class DragNDrop2 : MonoBehaviour
{
   //for mouse position
    Vector3 mouseScreenPos;
    Vector3 mouseWorldPos;
    Plane plane = new Plane(Vector3.down, 3);

    //for rigidbody
    Rigidbody heldRB, releasedRB;
    Vector3 releaseVelocity;
    bool readyToRelease;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            readyToRelease = false;
            GetClickedRigidBody();
            //heldRB.useGravity = false;
            heldRB.isKinematic = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            releasedRB = heldRB;

            heldRB = null;
            readyToRelease = true;

        }
    }

    void FixedUpdate()
    {
        if (releasedRB && readyToRelease)
        {
            //releasedRB.useGravity = true;
            releasedRB.isKinematic = false;

            releasedRB.velocity = releaseVelocity;
            releasedRB = null;
        }
        else if (heldRB)
        {
            SetRigibodyMotion();
            releaseVelocity = heldRB.velocity;
        }
    }

    void SetRigibodyMotion()
    {
        mouseScreenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
        if (plane.Raycast(ray, out float distanceF))
        {
            mouseWorldPos = ray.GetPoint(distanceF);
        }

        heldRB.MovePosition(mouseWorldPos); //replace with target rb pos
    }

    void GetClickedRigidBody()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit && hitInfo.collider.gameObject.GetComponent<Rigidbody>() && hitInfo.collider.tag == "Can Be Held")
        {
            heldRB = hitInfo.collider.gameObject.GetComponent<Rigidbody>();
        }
    }

}
