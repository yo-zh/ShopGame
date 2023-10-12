using UnityEngine;

public class DestroyCustomer : MonoBehaviour
{
    public delegate void DestroyAction();
    public static event DestroyAction OnDestroy;
    bool collisonOccured = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collisonOccured)
        {
            return;
        }

        if (collision.gameObject.name == "Customer" && collision.gameObject.GetComponent<CustomerOrder>() == null)
        {
            Destroy(collision.gameObject);
            OnDestroy?.Invoke();
            collisonOccured = true;
        }
        else
        {
            collisonOccured = false;
        }
    }
}
