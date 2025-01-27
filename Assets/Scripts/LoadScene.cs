using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void goToMainScene(){
        SceneManager.LoadScene("Game");
    }
}
