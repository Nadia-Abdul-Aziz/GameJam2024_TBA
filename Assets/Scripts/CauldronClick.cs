using UnityEngine;

public class CauldronClick : MonoBehaviour
{
    public GameObject cauldron;

    public void OnClick(){
        cauldron.SetActive (true);
    }
}
