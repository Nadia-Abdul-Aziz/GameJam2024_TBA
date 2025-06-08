using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This script handles the upgrades, their cost and their effect on the "currency per second"
public class StoreUpgrade : MonoBehaviour
{

    [SerializeField] private IngredientInfo info;
    [SerializeField] private PopupManager popupManager;
    //Fields to link through Unity interface to be able to update the text on the upgrade buttons
    
    [SerializeField] Button upgradeButton;
    [SerializeField] Image ingredientImage;
    [SerializeField] Text ingredientName;

    [SerializeField] TMP_Text listNameAndQuantity;
    [SerializeField] TMP_Text listMultiplier;
    [SerializeField] TMP_Text listTotalEffect;
    [SerializeField] Image listIcon;
    [SerializeField] MultiplierManagement multiplier;



    //Game manager object to have access to "GameManager.cs" functions
    public GameManager gameManager;


    //Set price multiplier for all the upgrades of the game. Changing it will change the price curve & pace of the game
    float priceMultiplier = 1.1f;

    // Corresponds to the amount of updates bought in that category
    int level = 0;


    public void PanelOpen() {
        popupManager.PanelOpen();
        SetPopup();
    }

    public void PanelClose() {
        popupManager.PanelClose();
        SetPopup();
    }


    //At start, updates the UI to allow 
    void Start()
    {
        UpdateIngredientUI();
    }

    //checks if it's possible to buy the upgrade
    public void BuyUpgrade(){
        int price = CalculatePrice();
        bool purchasePossible = gameManager.PurchasePossible(price);
        if (purchasePossible) {
            level++;
            UpdateIngredientUI();
            SetPopup();
        }
    }

    //  Updates both price and effect of the upgrade on the upgrade button
    // NEED TO DOUBLE CHECK THIS PART AND POTENTIALLY MAKE DIFFERENT UI UPDATES FOR INGREDIENTS VS MULTIPLIERS
    public void UpdateIngredientUI() {
        //changes elements in dessc tab

        //checks if the player has enough to buy, if yes, makes the button interactable
        bool canBuy = gameManager.countValue >= CalculatePrice();
        upgradeButton.interactable = canBuy;

        //
        bool isPurchased = level >= 1 | gameManager.countValue >= CalculatePrice();
        ingredientImage.color = isPurchased ? Color.white : Color.black;
        ingredientName.text = isPurchased ? info.ingredient : "???";
        UpgradeListUI(isPurchased);
    }

    private void SetPopup() {
        Debug.Log(info.ingredient);
        bool isPurchased = level >= 1 | gameManager.countValue >= CalculatePrice();
        popupManager.SetPrice("Cost: " + CalculatePrice().ToString());
        popupManager.SetIncome(info.numPerUpgrade + "  /s");
        popupManager.SetName(isPurchased ? info.ingredient : "???");
        popupManager.SetDescription(isPurchased ? info.ingredientDesc : "???");
    }

    //Function to update the list
    public void UpgradeListUI(bool isPurchased){
        listIcon.color = isPurchased ? Color.white : Color.black;
        listNameAndQuantity.text = isPurchased ? (info.ingredient + " x" + level.ToString()) : "???";
        listMultiplier.text = isPurchased ? ("Multiplier: x" + (multiplier.multiplierLevel+1)) : "???";
        listTotalEffect.text = isPurchased ? TotalEffectCalculator() : "No Effect \n0 /s";
    }

    //
    string TotalEffectCalculator(){
        float total = info.numPerUpgrade*level*(multiplier.multiplierLevel+1);
        return info.numPerUpgrade.ToString() + " x " + level.ToString() + " x " + (multiplier.multiplierLevel+1).ToString() + "\n Total: +" + total.ToString() + " /s";
    }

    //Function that does the math for calculating the upgrade price
    int CalculatePrice()
    {
        int price = Mathf.RoundToInt(info.startPrice * Mathf.Pow(priceMultiplier, level));
        return price;
    }

    public float IncomePerSecond()
    {
        return info.numPerUpgrade * level;
    }
}
