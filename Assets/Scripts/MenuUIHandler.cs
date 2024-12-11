using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
       scoreText.text= GetData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DataManager.Instance.DeleteData();
            Debug.Log("Data deleted");
        }
    }

    public void OnNameInput()
    {
        DataManager.Instance.currentPlayer=playerNameInput.text;
        
    }

    private string GetData()
    {
        string text ="Best Score :"+ DataManager.Instance.playerName+" : "+DataManager.Instance.highscore;
        return text;
    }


    public void StartGame()
    {
        DataManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}


    

