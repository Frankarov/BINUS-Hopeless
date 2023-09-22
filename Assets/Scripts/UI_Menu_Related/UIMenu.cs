using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();
        startPanelStarted();
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    public int sceneIndex = 0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelCurrent)
            {
                levelButtons[i].GetComponentInChildren<Text>().color = Color.black;
                levelButtons[i].interactable = false;

            }
        }
    }
    #endregion

    #region Panel Management

    [Header("Panel yang start")]
    public GameObject startPanel;

    [Header("Panel for level")]
    public GameObject levelPanel;

    public void startPanelOn()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void levelPanelOn()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        checkIsStarted();

    }

    private void checkIsStarted()
    {
        Debug.Log("isStartedTrue");
        GameManager.Instance.isStarted = true;
    }

    private void startPanelStarted()
    {
        if (isStarted())
        {
            levelPanelOn();
            Debug.Log("levelpanelON");
        }
        else
        {
            startPanelOn();
            Debug.Log("startpanelON");
        }



    }

    private bool isStarted()
    {
        return GameManager.Instance.isStarted;
    }



    #endregion
}
