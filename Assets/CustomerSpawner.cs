using UnityEngine;
using UnityEngine.Events;

public class CustomerSpawner : MonoBehaviour
{
    public UnityEvent spawnCustomer;
    public GameObject customer;
    public GameObject spawner;

    private void Start()
    {
        spawnCustomerPrefab();
    }

    private void OnEnable()
    {
        DestroyCustomer.OnDestroy += spawnCustomerPrefab;
    }

    private void OnDisable()
    {
        DestroyCustomer.OnDestroy -= spawnCustomerPrefab;
    }

    public void spawnCustomerPrefab()
    {
        GameObject currentCustomer = Instantiate(customer, transform.position, Quaternion.identity);
        currentCustomer.name = currentCustomer.name.Replace("(Clone)", "");
    }
}
