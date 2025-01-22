using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public RectTransform upgrades , multipliers , ingredients;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       upgrades.DOAnchorPos(Vector2.zero,0.25f); 

    }

    public void multiplierButton(){
        // upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        upgrades.DOAnchorPos(new Vector2(-300,0),0.25f);
        ingredients.DOAnchorPos(new Vector2(-600,0),0.25f);
        
        
    }

    public void UpgradeButton(){
        multipliers.DOAnchorPos(new Vector2(-300,0),0.25f);
        ingredients.DOAnchorPos(new Vector2(-600,0),0.25f);

    }

   


    public void ingredientButton(){
        multipliers.DOAnchorPos(new Vector2(-300,0),0.25f);
        upgrades.DOAnchorPos(new Vector2(-600,0),0.25f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
