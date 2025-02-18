using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{

    [SerializeField] private PanelType type;

    private MenuController menuController;
    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    public void OnClick()
    {
        menuController.OpenPanel(type);
    }
}
