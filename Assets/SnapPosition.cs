using UnityEngine;

public class SnapPosition : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var dragScript = collision.gameObject.GetComponent<DragObject>();
        if (dragScript != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.transform.rotation = Quaternion.identity;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        var dragScript = collision.gameObject.GetComponent<DragObject>();
        if (dragScript != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
