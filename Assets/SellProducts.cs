using System.Collections.Generic;
using UnityEngine;

public class SellProducts : MonoBehaviour
{
    [SerializeField] GameObject customer = null;
    [SerializeField] GameObject[] orderArray;
    [SerializeField] List<string> orderList;

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectsWithTag("CurrentCustomer") != null && customer == null)
        {
            customer = GameObject.FindGameObjectWithTag("CurrentCustomer");
            orderArray = customer.GetComponent<CustomerOrder>().orderArray;
            foreach (GameObject order in orderArray)
            {
                orderList.Add(order.gameObject.name);
            }
        }
        else if (customer != null)
        {
            if (orderList.Contains(other.gameObject.name))
            {
                orderList.Remove(other.gameObject.name);
                Destroy(other.gameObject);
            }
            if (orderList.Count == 0)
            {
                Destroy(customer.GetComponent<CustomerOrder>());
            }
        }
    }
}
