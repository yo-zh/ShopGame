using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] GameObject[] prefabArray;
    public GameObject[] orderArray;
    void Start()
    {
        int randomIndex;
        GameObject productPrefab;

        for (int i = 0; i < orderArray.Length; i++) {
            randomIndex = Random.Range(0, orderArray.Length);
            productPrefab = prefabArray[randomIndex];
            orderArray[i] = productPrefab;
        }
    }
}