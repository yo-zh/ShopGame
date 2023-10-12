using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Order : MonoBehaviour
{
    public TextMeshProUGUI cashRegisterText;

    private GameObject[] orderArray;
    private bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Customer" && !hasEntered)
        {
            other.gameObject.tag = "CurrentCustomer";
            hasEntered = true;
            orderArray = other.gameObject.GetComponent<CustomerOrder>().orderArray;
            for (int i = 0; i < orderArray.Length; i++)
            {
                cashRegisterText.text += "\n" + orderArray[i].name;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Customer" && hasEntered)
        {
            hasEntered = false;
            cashRegisterText.text = "";
        }
    }
}
