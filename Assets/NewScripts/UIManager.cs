using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverDisplay;
    [SerializeField]
    GameObject gameClearDisplay;
    [SerializeField]
    TextMeshProUGUI moneyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverDisplay.SetActive(false);
        gameClearDisplay.SetActive(false);
    }
    public void ShowGameOver()
    {
        gameOverDisplay.SetActive(true);
    }
    public void ShowGameClear()
    {
        gameClearDisplay.SetActive(true);
    }
    public void SetMoneyText(int value)
    {
        moneyText.text = "$"+value;
    }

}
