using UnityEngine;
using UnityEngine.Events;

public class CustomerSpawner : MonoBehaviour
{
    public UnityEvent spawnCustomer;
    public GameObject customer;
    public GameObject spawner;

    private void Start()
    {
        UpdateScreen();
    }

    private void OnEnable()
    {
        DestroyCustomer.OnDestroy += UpdateScreen;
    }

    private void OnDisable()
    {
        DestroyCustomer.OnDestroy -= UpdateScreen;
    }

    public void UpdateScreen()
    {
        GameObject currentCustomer = Instantiate(customer, transform.position, Quaternion.identity);
        currentCustomer.name = currentCustomer.name.Replace("(Clone)", "");
    }
}
