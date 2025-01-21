using UnityEngine;
using UnityEngine.UI;

//This script handles the upgrades, their cost and their effect on the "currency per second"
public class StoreUpgrade : MonoBehaviour
{
    //Fields to link through Unity interface to be able to update the text on the upgrade buttons
    [SerializeField] Text priceValue;
    [SerializeField] Text income;

    // Variables to change in the unity window to be able to reuse the script no matter the cost/effect of the upgrade
    public int startPrice = 20;
    public float numPerUpgrade = 0.1f;

    //Set price multiplier for all the upgrades of the game. Changing it will change the price curve & pace of the game
    float priceMultiplier = 1.1f;

    // Corresponds to the amount of updates bought in that category
    int level = 0;

    //At start, updates the UI to allow 
    void Start()
    {
        UpdateUI();
    }

    //
    public void BuyUpgrade(){
        
    }

    //  Updates both price and effect of the upgrade on the upgrade button
    void UpdateUI()
    {
        priceValue.text = CalculatePrice().ToString();
        income.text = level.ToString() + " x " + numPerUpgrade + "/s";
    }

    //Function that does the math for calculating the upgrade price
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
