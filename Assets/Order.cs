using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Order : MonoBehaviour
{
    public TextMeshProUGUI cashRegisterText;

    private bool hasEntered = false;

    public delegate void CustomerEntryAction(GameObject[] orderArray);
    public static event CustomerEntryAction OnEntry;
    public static event CustomerEntryAction OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Customer" && !hasEntered)
        {
            hasEntered = true;
            other.gameObject.tag = "CurrentCustomer";
            GameObject[] orderArray = other.gameObject.GetComponent<CustomerOrder>().orderArray; ;

            if (orderArray != null)
            {
                OnEntry?.Invoke(orderArray);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Customer" && hasEntered)
        {
            hasEntered = false;
            OnExit?.Invoke(null);
        }
    }
}
