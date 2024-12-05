using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudConfig : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keysText;
    [SerializeField] AnimationPlayer animPlayerConfigs;
    [SerializeField] GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        keysText.SetText("You have " + animPlayerConfigs.keys + " Keys");
        if(animPlayerConfigs.life == false)
        {
            gameOver.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
