/*
    +- работает, но нужно улучшить:
        1) перемещение без джиттера
        2) клиппинг сквозь объекты
*/

using UnityEngine;

public class DragProduct : MonoBehaviour
{
    //public int maxRange = 5;

    private Rigidbody rb;
    private Vector3 mouseOffset;
    private float mouseZCoordinate;

    private Vector3 oldpos;
    private Vector3 newpos;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        oldpos = transform.position;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            //Debug.Log("1 Z: " + mouseZCoordinate);
        }
    }
    void OnMouseDrag()
    {
        if (mouseZCoordinate < 3)       // ограничиваю дистанцию хватани€
        {
            //Debug.Log("2 Z: " + mouseZCoordinate);
            transform.position = GetMouseWorldPos() + mouseOffset;

            newpos = transform.position;
            var media = (newpos - oldpos);
            velocity = media / Time.deltaTime;
            oldpos = newpos;
            newpos = transform.position;
        }
    }
    void OnMouseUp()
    {
        if (mouseZCoordinate < 3)
        {
            rb.velocity = velocity / 3;
            mouseZCoordinate = 0;
        }
        //Debug.Log("3 Z: " + mouseZCoordinate);
        // Z сохран€етс€ после отпускани€ объекта
        // обнул€ю, чтобы Z < 3 не было true
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;   // (x, y, _)
        mousePoint.z = mouseZCoordinate;            // z

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
