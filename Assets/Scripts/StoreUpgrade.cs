using UnityEngine;
using UnityEngine.UI;

public class StoreUpgrade : MonoBehaviour
{
    [SerializeField] Text priceValue;
    [SerializeField] Text income;
    public int startPrice = 20;
    public float priceMultiplier;
    public float numPerUpgrade = 0.1f;

    int level = 0;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        priceValue.text = CalculatePrice().ToString();
        income.text = level.ToString() + " x " + numPerUpgrade + "/s";
    }
    int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startPrice * Mathf.Pow(priceMultiplier, level));
        return price;
    }

    public float IncomePerSecond()
    {
        return numPerUpgrade * level;
    }
}
