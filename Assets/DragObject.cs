/*
    +- работает, но нужно улучшить
*/

using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject myPrefab;
    public int maxRange = 5;

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
        else if (Input.GetMouseButtonDown(2))
        {
            GameObject spawnedProduct = Instantiate(myPrefab, transform.position, Quaternion.identity);
            spawnedProduct.name = spawnedProduct.name.Replace("(Clone)", "");
            Destroy(gameObject);
            //Debug.Log("<color=magenta>Box destroyed, spawning</color> [ " + myPrefab.name + " ]");
        }
    }
    void OnMouseDrag()
    {
        if (mouseZCoordinate < 3)       // ограничение дистанции хватани€
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
            mouseZCoordinate = 0; // Z сохран€етс€ после отпускани€ объекта
                                  // обнул€ю, чтобы Z < 3 не было true
        }
        //Debug.Log("3 Z: " + mouseZCoordinate);

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;   // (x, y, _)
        mousePoint.z = mouseZCoordinate;            // z

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
