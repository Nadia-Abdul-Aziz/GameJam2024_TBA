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
    public int[] multiplierTable = {5,10,100,100,100,1000,1000,1000,1000,10000,10000,10000,10000,10000};

    public GameManager gameManager;

    int multiplierLevel = 0;
    int currentPrice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPrice = multiplierStartPrice;
        UpgradeMultiplierUI();
        multiplierValueTxt.text = "x2 " + linkedIngredientName;
    }

    public void buyMultiplier(){
        bool purchaseMultiplierPossible = gameManager.PurchasePossible(currentPrice);
        if (purchaseMultiplierPossible){
            CalculateMultiplierPrice();
            multiplierLevel++;
            UpgradeMultiplierUI();
        }
    }

    public void UpgradeMultiplierUI() {
        multiplierPriceTxt.text = "Cost: " + currentPrice.ToString();
        
        bool canBuyMultiplier = gameManager.countValue >= currentPrice;
        multiplierButton.interactable = canBuyMultiplier;

        bool MultiplerIsPurchased = multiplierLevel <= 1 || gameManager.countValue >= currentPrice;
        multiplierImage.color = MultiplerIsPurchased ? Color.white : Color.black;
        multiplierNameTxt.text = MultiplerIsPurchased ? multiplierName : "???";
        multiplierNameDesc.text = MultiplerIsPurchased ? multiplierName : "???";
        multiplierDescTxt.text = MultiplerIsPurchased ? multiplierDesc : "???";
    }

    void CalculateMultiplierPrice(){
        currentPrice *= multiplierTable[multiplierLevel];
    }

    public int CummulativeMultiplier(){
        if (multiplierLevel > 0){
           return multiplierValue*multiplierLevel; 
        }
        return 1;
    }
}
