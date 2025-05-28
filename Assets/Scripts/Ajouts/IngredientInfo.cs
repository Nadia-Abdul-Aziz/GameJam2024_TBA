using UnityEngine;

[CreateAssetMenu(fileName = "IngredientInfos", menuName = "Scriptable Objects/IngredientInfos")]
public class IngredientInfo : ScriptableObject
{
    public string ingredient;
    public string ingredientDesc;
    public int startPrice;
    public float numPerUpgrade;
    public Sprite ingredientImage;
}
