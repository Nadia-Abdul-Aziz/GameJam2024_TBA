using UnityEngine;

public class CanvasOpener : MonoBehaviour
{
    public GameObject Canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void canvasOpen(){
        if (Canvas != null){
            bool isActive = Canvas.activeSelf;
            Canvas.SetActive(!isActive);
        }
    }
}
