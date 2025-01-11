using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public VisualElement ui;

    public Button resumeButton;
    public Button quitButton;

    public MenuHandler menuHandler;

    bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        
    }
    private void OnEnable()
    {
        resumeButton = ui.Q<Button>("Resume");
        quitButton = ui.Q<Button>("Quit");
        resumeButton.clicked += menuHandler.OnResumeButtonClicked;
        quitButton.clicked += OnQuitButtonClicked;
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = menuHandler.isPaused;
        ui.style.display = CheckPaused();
        
    }

    DisplayStyle CheckPaused()
    {
        return isPaused ? DisplayStyle.Flex : DisplayStyle.None;
    }

    

    private void OnQuitButtonClicked()
    {
        Debug.Log("Quitting App");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
