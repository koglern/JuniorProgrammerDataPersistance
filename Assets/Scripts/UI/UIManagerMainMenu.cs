using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class UIManagerMainMenu : MonoBehaviour
{
    public TextMeshProUGUI Highscore;
    public TextMeshProUGUI Playername;
    public TMPro.TMP_InputField nameInputField;
    public Button startButton;
    
    public void Start()
    {
        SaveManager.Instance.LoadHighscore();
        Highscore.SetText("" + SaveManager.Instance.Highscore);
        Playername.SetText(SaveManager.Instance.playerName);
        Debug.Log("Loaded Highscore: SaveManager.Instance.Highscore");
        Debug.Log("Loaded Playername: " + SaveManager.Instance.playerName);
        // Disable the Start button initially
        startButton.interactable = false;

        // Add a listener to check for changes in the InputField
        nameInputField.onValueChanged.AddListener(OnNameInputChanged);
        
    }
    private void OnNameInputChanged(string input)
    {
        // Enable the Start button if the name input is not empty
        startButton.interactable = !string.IsNullOrWhiteSpace(input);
        SaveManager.Instance.playerName = nameInputField.text;
    }
    private void OnDestroy()
    {
        // Remove the listener when the script is destroyed
        nameInputField.onValueChanged.RemoveListener(OnNameInputChanged);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
