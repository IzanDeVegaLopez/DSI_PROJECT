using UnityEngine;
using UnityEngine.UIElements;

public class MenuSwitcher : MonoBehaviour
{
    VisualElement mainMenu;
    VisualElement equipmentMenu;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        //MENUS
        mainMenu = root.Q("MainMenu");
        equipmentMenu = root.Q("EquipmentMenu");
        //BUTTONS
        VisualElement startGame = root.Q("StartGameButton");
        VisualElement equipmentReturn = root.Q("EquipmentReturn");
        Debug.Log(startGame);
        Debug.Log(equipmentReturn);
        startGame.RegisterCallback<ClickEvent>(
            ev=>{
                hideAll();
                equipmentMenu.style.display = DisplayStyle.Flex;
                Debug.Log("meow");
        });
        equipmentReturn.RegisterCallback<ClickEvent>(
            ev => {
                hideAll();
                mainMenu.style.display = DisplayStyle.Flex;
                Debug.Log("meow");
        });

        hideAll();
        mainMenu.style.display = DisplayStyle.Flex;
    }

    private void hideAll()
    {
        mainMenu.style.display = DisplayStyle.None;
        equipmentMenu.style.display = DisplayStyle.None;
    }
}
