using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Diagnostics;
using TMPro;
// using System.Numerics;

public class UiManager : MonoBehaviour
{
    public RectTransform upgrades , multipliers , ingredients,buttonUpg,buttonMul,buttonIng,buttonExi;
    private bool cond = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }

    public void multiplierButton(){
        // upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        ingredients.DOAnchorPos(new Vector2(-600,0),0.25f);
        multipliers.DOAnchorPos(new Vector2(0,0),0.25f);
        
    }

    public void UpgradeButton(){
      
            upgrades.DOAnchorPos(new Vector2(0,0),0.25f);
            multipliers.DOAnchorPos(new Vector2(-300,0),0.25f);
            ingredients.DOAnchorPos(new Vector2(-300,0),0.25f);
            

    }

   


    public void ingredientButton(){
        multipliers.DOAnchorPos(new Vector2(-300,0),0.25f);
        upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        ingredients.DOAnchorPos(new Vector2(0,0),0.25f);


    }

    public void exitButton(){
        upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        multipliers.DOAnchorPos(new Vector2(-300,0),0.25f);
        ingredients.DOAnchorPos(new Vector2(-300,0),0.25f);
        buttonUpg.DOAnchorPos(new Vector2(-600,0),0.25f);
        buttonMul.DOAnchorPos(new Vector2(-600,0),0.25f);
        buttonIng.DOAnchorPos(new Vector2(-600,0),0.25f);

    }

  
}
