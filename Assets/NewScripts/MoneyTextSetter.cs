using UnityEngine;

public class MoneyTextSetter : MonoBehaviour
{
    [SerializeField]
    MoneyManager moneyManager;
    [SerializeField]
    UIManager uIManager;

    // Update is called once per frame
    void Update()
    {
        uIManager.SetMoneyText(moneyManager.Money);
    }
}
