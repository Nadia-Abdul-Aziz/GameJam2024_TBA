using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierManagement : MonoBehaviour
{
    [SerializeField] Text multiplierPriceTxt;
    [SerializeField] string linkedIngredientName;
    [SerializeField] Text MultiplierValueTxt = "x2 " + linkedIngredientName;
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
        multiplierPriceTxt.text = "Cost: " + CalculateMultiplierPrice().ToString();
        
        bool canBuyMultiplier = gameManager.countValue >= CalculateMultiplierPrice();
        multiplierButton.interactable = canBuy;

        bool MultiplerIsPurchased = level <= 1 || gameManager.countValue >=
        multiplierImage.color = isPurchased ? Color.white : Color.black;
        multiplierNameTxt.text = isPurchased ? multiplierName : "???";
        multiplierNameDesc.text = isPurchased ? multiplierName : "???";
        multiplierDescTxt.text = isPurchased ? multiplierDesc : "???";
    }

    void CalculateMultiplierPrice(){
        currentPrice *= multiplierTable[multiplierLevel];
    }

    public int CummulativeMultiplier(){
        return multiplierValue*multiplierLevel;
    }
}
