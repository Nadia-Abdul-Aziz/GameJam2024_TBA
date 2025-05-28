using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour {

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupPriceText;
    [SerializeField] private TextMeshProUGUI popupIncomeText;
    [SerializeField] private TextMeshProUGUI popupNameText;
    [SerializeField] private TextMeshProUGUI popupDescriptionText;



    public void PanelOpen() {
        popup.SetActive(true);
    }

    public void PanelClose() {
        popup.SetActive(false);
    }


    public void SetPrice(string value) {
        popupPriceText.text = value;
    }

    public void SetIncome(string value) {
        popupIncomeText.text = value;
    }

    public void SetName(string value) {
        popupNameText.text = value;
    }

    public void SetDescription(string value) {
        popupDescriptionText.text = value;
    }
}

