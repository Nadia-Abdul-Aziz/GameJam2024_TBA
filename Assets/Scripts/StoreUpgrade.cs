using UnityEngine;
using UnityEngine.UI;

//This script handles the upgrades, their cost and their effect on the "currency per second"
public class StoreUpgrade : MonoBehaviour
{
    //Fields to link through Unity interface to be able to update the text on the upgrade buttons
    [SerializeField] Text priceValue;
    [SerializeField] Text income;
    [SerializeField] Button upgradeButton;
    [SerializeField] Image ingredientImage;
    [SerializeField] Text ingredientName;


    // Variables to change in the unity window to be able to reuse the script no matter the cost/effect of the upgrade
    public int startPrice = 20;
    public float numPerUpgrade = 0.1f;
    public string ingredient;

    //Game manager object to have access to "GameManager.cs" functions
    public GameManager gameManager;


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
        int price = CalculatePrice();
        bool purchasePossible = gameManager.PurchaseUpgrade(price);
        if (purchasePossible){
            level++;
            UpdateUI();
        }
    }

    //  Updates both price and effect of the upgrade on the upgrade button
    public void UpdateUI()
    {
        priceValue.text = CalculatePrice().ToString();
        income.text = level.ToString() + " x " + numPerUpgrade + "/s";
        bool canBuy = gameManager.countValue >= CalculatePrice();
        upgradeButton.interactable = canBuy;

        bool isPurchased = level <= 1 && gameManager.countValue >= CalculatePrice();
        ingredientImage.color = isPurchased ? Color.white : Color.black;

        ingredientName.text = isPurchased ? ingredient : "???";
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
