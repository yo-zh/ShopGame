using System.Collections;
using UnityEngine;

// Настроить возможность доставки только с закрытыми воротами

public class BoxSpawner : MonoBehaviour
{
    public GameObject spawnArea;
    [SerializeField] GameObject[] prefabArray;
    public GameObject gate;
    public Material material1;
    public Material material2;

    private void OnCollisionEnter(Collision collision)
    {
        int randomIndex;
        GameObject productPrefab;

        for (var i = 0; i < 3; i++)
        {
            randomIndex = Random.Range(0, prefabArray.Length);
            productPrefab = prefabArray[randomIndex];
            Instantiate(productPrefab, spawnArea.transform.position + new Vector3(Random.Range(-2, 2), 1, Random.Range(-2,2)), Random.rotation);
        }
        gate = GameObject.Find("DeliveryGate");
        gate.transform.position = gate.transform.position + Vector3.up * 3;
        transform.GetComponent<Renderer>().material = material1;
        transform.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(DeliveryPeriod());
    }

    IEnumerator DeliveryPeriod()
    {
        yield return new WaitForSeconds(10);
        transform.GetComponent<Renderer>().material = material2;
        transform.GetComponent<BoxCollider>().enabled = true;
        gate.transform.position = gate.transform.position + Vector3.down * 3;
    }
}
