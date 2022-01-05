#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    public Text scoreText;
    public InputField userName;

    void Start()
    {
        if(MenuManager.Instance.userName != null || !MenuManager.Instance.userName.Equals(""))
        {
            userName.text = MenuManager.Instance.userName;
        }
        string bestUser = MenuManager.Instance.bestUser != null ? MenuManager.Instance.bestUser : "";
        int bestScore = MenuManager.Instance.bestScore > 0 ? MenuManager.Instance.bestScore : 0;
        scoreText.text = "Best Score: " + bestUser + ": " + bestScore;
    }

    public void StrtGame()
    {
        MenuManager.Instance.userName = userName.text;
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        MenuManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
