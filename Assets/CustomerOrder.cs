using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] GameObject[] prefabArray;
    public GameObject[] orderArray;
    private int Money;

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
        Debug.Log("I don't have any money, but thanks for the goods anyway"); // Prints text several times for some reason
    }
}