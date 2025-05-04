using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSelector : MonoBehaviour
{
    int category_selected_index = 0;
    VisualElement _selected_item;
    VisualElement _category_selected_it;
    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement equipment_menu = root.Q("EquipmentMenu");
        VisualElement selectable_cat = equipment_menu.Q("SelectableCategoriesSpace");
        selectable_cat.RegisterCallback<ClickEvent>(seleccionaCategoria);
        VisualElement selectable_it = equipment_menu.Q("SelectableItemsSpace");
        selectable_it.RegisterCallback<ClickEvent>(seleccionaItem);
        _category_selected_it = selectable_cat.ElementAt(0);
        //Item current_selected;
        _selected_item = equipment_menu.Q("CurrentSelectedItemMidSpace").ElementAt(0);
    }
    void seleccionaCategoria(ClickEvent evt)
    {
        VisualElement miTarjeta = evt.target as VisualElement;
        _category_selected_it = miTarjeta as Item;
        (_selected_item as Item).AssignItem(_category_selected_it);
    
        //Cambiar items por coger
    }
    void seleccionaItem(ClickEvent evt)
    {
        VisualElement miTarjeta = evt.target as VisualElement;
        Item selected = miTarjeta as Item;
        (_selected_item as Item).AssignItem(selected);
        (_category_selected_it as Item).AssignItem(selected);
    }
}
