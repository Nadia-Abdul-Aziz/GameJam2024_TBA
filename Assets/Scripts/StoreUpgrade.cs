using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This script handles the upgrades, their cost and their effect on the "currency per second"
public class StoreUpgrade : MonoBehaviour
{
    //Fields to link through Unity interface to be able to update the text on the upgrade buttons
    [SerializeField] Text upgradePrice;
    [SerializeField] Text incomePerSecond;
    [SerializeField] Button upgradeButton;
    [SerializeField] Image ingredientImage;
    [SerializeField] Text ingredientName;
    [SerializeField] TMP_Text ingredientNameDesc;
    [SerializeField] Text ingredientDescTxt;
    [SerializeField] string ingredientDesc;


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
        UpdateIngredientUI();
    }

    //checks if it's possible to buy the upgrade
    public void BuyUpgrade(){
        int price = CalculatePrice();
        bool purchasePossible = gameManager.PurchasePossible(price);
        if (purchasePossible){
            level++;
            UpdateIngredientUI();
        }
    }

    //  Updates both price and effect of the upgrade on the upgrade button
    // NEED TO DOUBLE CHECK THIS PART AND POTENTIALLY MAKE DIFFERENT UI UPDATES FOR INGREDIENTS VS MULTIPLIERS
    public void UpdateIngredientUI() {
        upgradePrice.text = "Cost: " + CalculatePrice().ToString();
        incomePerSecond.text = numPerUpgrade + "   /s";

        bool canBuy = gameManager.countValue >= CalculatePrice();
        upgradeButton.interactable = canBuy;

        bool isPurchased = level <= 1 || gameManager.countValue >= CalculatePrice();
        ingredientImage.color = isPurchased ? Color.white : Color.black;
        ingredientName.text = isPurchased ? ingredient : "???";
        ingredientNameDesc.text = isPurchased ? ingredient : "???";
        ingredientDescTxt.text = isPurchased ? ingredientDesc : "???";
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
