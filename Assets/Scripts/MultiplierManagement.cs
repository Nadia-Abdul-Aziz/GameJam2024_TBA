using UnityEngine;
using UnityEngine.UI;

public class MultiplierManagement : MonoBehaviour
{
    [SerializeField] Text multiplierPriceTxt;
    [SerializeField] Text currentMultiplierTxt;
    [SerializeField] Button multiplierButton;
    [SerializeField] Image multiplierImage;
    [SerializeField] Text multiplierNameTxt;

    public int multiplierStartPrice = 100;
    public int multiplierValue = 2;
    public string multiplierName;
    public int[] multiplierTable;

    public GameManager gameManager;

    int multiplierLevel = 0;
    int currentPrice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPrice = multiplierStartPrice;
        //UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyMultiplier(){
        bool purchaseMultiplierPossible = gameManager.PurchasePossible(currentPrice);
        if (purchaseMultiplierPossible){
            CalculateMultiplierPrice();
            multiplierLevel++;
            //UpdateUI();
        }
    }

    void CalculateMultiplierPrice(){
        currentPrice *= multiplierTable[multiplierLevel];
    }

    public int CummulativeMultiplier(){
        return multiplierValue*multiplierLevel;
    }
}
