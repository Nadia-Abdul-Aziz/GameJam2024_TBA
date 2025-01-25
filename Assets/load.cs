using Unity.VisualScripting;
using UnityEngine;

public class load : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        GameObject[] buttonSound = GameObject.FindGameObjectsWithTag("button");
        if (buttonSound.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
