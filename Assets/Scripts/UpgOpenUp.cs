using UnityEngine;

public class UpgOpenUp : MonoBehaviour
{
    
    public GameObject Panel;
    
    public void PanelOpener(){
        if(Panel != null){
            Debug.Log("HELLO");
            Panel.SetActive(true);
           
        }

    }
}
