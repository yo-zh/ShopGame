using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] int Cash = 0;
    // Start is called before the first frame update
    void Start()
    {
        CustomerOrder.Paid += DepositCash;
    }

    private void OnDestroy()
    {
        CustomerOrder.Paid -= DepositCash;
    }

    private void DepositCash(int Money)
    {
        Cash += Money;
    }
}
