using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    int money = 0;
    public int Money=>money;
    [SerializeField]
    float moneyTimer=1;
    float currentTimer=0;

    public void Pay(int value)
    {
        money-=value;
    }
    // Update is called once per frame
    void Update()
    {
        currentTimer+=Time.deltaTime;
        if (currentTimer > moneyTimer)
        {
            money ++;
            currentTimer=0;
        }
    }
}
