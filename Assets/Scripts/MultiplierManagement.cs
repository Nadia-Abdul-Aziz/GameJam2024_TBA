using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierManagement : MonoBehaviour
{
    [SerializeField] Text multiplierPriceTxt;
    [SerializeField] string linkedIngredientName;
    [SerializeField] Text multiplierValueTxt;
    [SerializeField] Button multiplierButton;
    [SerializeField] Image multiplierImage;
    [SerializeField] Text multiplierNameTxt;
    [SerializeField] TMP_Text multiplierNameDesc;
    [SerializeField] Text multiplierDescTxt;
    [SerializeField] string multiplierDesc;

    public int multiplierStartPrice = 100;
    public int multiplierValue = 2;
    public string multiplierName;
    public int[] multiplierTable = { 5, 10, 100, 100, 100, 1000, 1000, 1000, 1000, 10000, 10000, 10000, 10000, 10000 };

    public GameManager gameManager;

    public int multiplierLevel = 0;
    int currentPrice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPrice = multiplierStartPrice;
        UpdateMultiplierUI();
        multiplierValueTxt.text = "x2 " + linkedIngredientName;
    }

    public void buyMultiplier()
    {
        bool purchaseMultiplierPossible = gameManager.PurchasePossible(currentPrice);
        if (purchaseMultiplierPossible)
        {
            CalculateMultiplierPrice();
            multiplierLevel++;
            UpdateMultiplierUI();
            Save();
        }
    }

    public void UpdateMultiplierUI()
    {
        multiplierPriceTxt.text = "Cost: " + currentPrice.ToString();

        bool canBuyMultiplier = gameManager.countValue >= currentPrice;
        multiplierButton.interactable = canBuyMultiplier;

        bool MultiplerIsPurchased = multiplierLevel >= 1 | gameManager.countValue >= currentPrice;
        multiplierImage.color = MultiplerIsPurchased ? Color.white : Color.black;
        multiplierNameTxt.text = MultiplerIsPurchased ? multiplierName : "???";
        multiplierNameDesc.text = MultiplerIsPurchased ? multiplierName : "???";
        multiplierDescTxt.text = MultiplerIsPurchased ? multiplierDesc : "???";
    }

    void CalculateMultiplierPrice()
    {
        currentPrice *= multiplierTable[multiplierLevel];
    }

    public float CummulativeMultiplier()
    {
        if (multiplierLevel > 0)
        {
            return multiplierValue * multiplierLevel;
        }
        return 1;
    }

    public float CurrentMultiplier()
    {
        return multiplierValue;
    }


    public void SetMultiplier(float value)
    {
        multiplierValue = (int)value;
    }

    public void Save()
    {
        // Save multiplier level and current price
        PlayerPrefs.SetInt("multiplierLevel_" + multiplierName, multiplierLevel);
        PlayerPrefs.SetInt("multiplierPrice_" + multiplierName, currentPrice);


        PlayerPrefs.SetInt("multiplierValue_" + multiplierName, multiplierValue);


        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Load saved multiplier level, price, and value
        multiplierLevel = PlayerPrefs.GetInt("multiplierLevel_" + multiplierName, 0); // Default to 0 
        currentPrice = PlayerPrefs.GetInt("multiplierPrice_" + multiplierName, multiplierStartPrice); // Default to starting price

        multiplierValue = PlayerPrefs.GetInt("multiplierValue_" + multiplierName, 2); //default 2
    }
}

