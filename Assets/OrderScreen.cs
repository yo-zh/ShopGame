using TMPro;
using UnityEngine;

public class OrderScreen : MonoBehaviour
{
    TextMeshProUGUI cashRegisterText;
    private void Start()
    {
        cashRegisterText = GameObject.Find("OrderScreen").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Order.OnEntry += updateScreen;
        Order.OnExit += updateScreen;
    }

    private void OnDisable()
    {
        Order.OnEntry -= updateScreen;
        Order.OnExit -= updateScreen;
    }

    void updateScreen(GameObject[] orderArray)
    {
        if (orderArray != null)
        {
            for (int i = 0; i < orderArray.Length; i++)
            {
                cashRegisterText.text += "\n" + orderArray[i].name;
            }
        }
        else
        {
            cashRegisterText.text = string.Empty;
        }
       
    }
}
