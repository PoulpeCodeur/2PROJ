using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PanelType
{
    None,
    Main,
    Options,
    Credits,
}

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        foreach (var panel in panelsList)
        {
            if (panel) panelsDict.Add(panel.GetPanelType(), panel);
        }

        OpenOnePanel(PanelType.Main);
    }

    private void OpenOnePanel(PanelType type)
    {
        foreach (var panel in panelsList)
        {
            panel.ChangeState(false);
        }

        if (type != PanelType.None)
        {
            panelsDict[type].ChangeState(true);
        }
    }

    public void OpenPanel(PanelType type)
    {
        OpenOnePanel(type);
    }

    public void SwitchScene(string sceneName)
    {
        gameManager.SwitchScene(sceneName);
    }

    public void QuitGame()
    {
        gameManager.QuitGame();
    }
}
