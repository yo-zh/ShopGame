using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SellProducts : MonoBehaviour
{
    private List<string> orderList = new();

    private void OnEnable()
    {
        Order.OnEntry += KeepOrderList;
    }

    private void OnDisable()
    {
        Order.OnEntry -= KeepOrderList;
    }

    void KeepOrderList(GameObject[] orderArray)
    {
        if (orderList.Count <= 0)
        {
            foreach (GameObject order in orderArray)
            {
                orderList.Add(order.name);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (orderList.Contains(other.gameObject.name))
        {
            orderList.Remove(other.gameObject.name);
            Destroy(other.gameObject);
        }
        if (orderList.Count == 0)
        {
            GameObject customer = GameObject.FindGameObjectWithTag("CurrentCustomer"); // Not great, needs rework
            Destroy(customer.GetComponent<CustomerOrder>());
        }
    }
}
