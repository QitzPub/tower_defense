using UnityEngine;
using UnityEngine.UI;

public class PaymentButton : MonoBehaviour
{
    [SerializeField]
    int paymentPrice;
    [SerializeField]
    Button targetButton;
    [SerializeField]
    MoneyManager moneyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetButton.interactable=false;
        targetButton.onClick.AddListener(Pay);
    }

    void Pay()
    {
        moneyManager.Pay(paymentPrice);
    }

    // Update is called once per frame
    void Update()
    {
        targetButton.interactable=moneyManager.Money>=paymentPrice;
    }
}
