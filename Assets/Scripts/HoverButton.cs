using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Button button;
    public Color wantedColor;
    private Color originalColor;
    private ColorBlock cb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cb = button.colors;
        originalColor = cb.selectedColor;

    }

    public void changeWhenHover(){
        cb.selectedColor = wantedColor;
        button.colors = cb;

    }

    public void changeWhenLeaves(){
        cb.selectedColor = originalColor;
        button.colors = cb;
    }

}
