using UnityEngine;

public class DestroyCustomer : MonoBehaviour
{
    public delegate void DestroyAction();
    public static event DestroyAction OnDestroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Customer" && other.gameObject.GetComponent<CustomerOrder>() == null)
        {
            Destroy(other.gameObject);
            OnDestroy?.Invoke();
        }
    }
}
