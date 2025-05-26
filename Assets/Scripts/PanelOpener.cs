using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void panelOpen()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

    }
}