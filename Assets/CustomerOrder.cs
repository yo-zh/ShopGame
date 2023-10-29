using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public delegate void CustomerPayment(int Money);
    public static event CustomerPayment Paid;

    [SerializeField] GameObject[] prefabArray;
    public GameObject[] orderArray;
    [SerializeField] int Money;

    void Start()
    {
        SellProducts.Sold += GiveMoney;

        int randomIndex;
        GameObject productPrefab;
        Money = Random.Range(30, 50);
        for (int i = 0; i < orderArray.Length; i++)
        {
            randomIndex = Random.Range(0, orderArray.Length);
            productPrefab = prefabArray[randomIndex];
            orderArray[i] = productPrefab;
        }
    }

    private void OnDestroy()
    {
        SellProducts.Sold -= GiveMoney;
    }

    private void GiveMoney()
    {
        Paid?.Invoke(Money);
    }
}