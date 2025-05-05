using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSelector : MonoBehaviour
{
    int category_selected_index = 0;
    VisualElement _selected_item;
    VisualElement _category_selected_it;
    VisualElement _selected_items_stats;
    VisualElement _player_stats;
    bool _last_click_changed_cat = true;

    public int[] Items
    {
        get { return _items; }
        set { _items = value; }
    }
    int[] _items = new int[3] { -1,-1,-1};

    VisualElement[] _submenus = new VisualElement[4];
    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement equipment_menu = root.Q("EquipmentMenu");
        VisualElement selectable_cat = equipment_menu.Q("SelectableCategoriesSpace");
        _category_selected_it = selectable_cat.ElementAt(0);
        _category_selected_it.style.backgroundColor = new Color(1, 0, 0, 1);
        selectable_cat.RegisterCallback<ClickEvent>(seleccionaCategoria);
        VisualElement selectable_it = equipment_menu.Q("SelectableItemsSpace");
        selectable_it.RegisterCallback<ClickEvent>(seleccionaItem);
        for (int i = 0; i < 4; ++i)
        {
            //Debug.Log(selectable_it.ElementAt(i));
            _submenus[i] = selectable_it.ElementAt(i);
            _submenus[i].style.display = i != 0 ? DisplayStyle.None : DisplayStyle.Flex;
        }
        //_player_stats

        //Item current_selected;
        _selected_item = equipment_menu.Q("CurrentSelectedItemMidSpace").ElementAt(0);
        (_selected_item as Item).AssignItem(_category_selected_it as Item);
        _selected_items_stats = equipment_menu.Q("SelectedItemStats");
        _player_stats = equipment_menu.Q("PlayerStats");
        //Debug.Log(_player_stats);


        //LoadLoadout(new int[] { 0, 2, 1 });
    }
    void seleccionaCategoria(ClickEvent evt)
    {
        //Debug.Log("Category");
        VisualElement miTarjeta = evt.target as VisualElement;
        if (miTarjeta is Item)
        {
            _category_selected_it.style.backgroundColor = new Color(162f / 255, 229f / 255, 115f / 255, 1);
            _category_selected_it = miTarjeta as Item;
            _category_selected_it.style.backgroundColor = new Color(1, 0, 0, 1);

            int[] stats;

            if((_category_selected_it as Item).Id != 3)
                (_selected_item as Item).AssignItem(_category_selected_it);

            for (int i = 0; i < 4; ++i)
            {
                _submenus[i].style.display = (_category_selected_it as Item).Id != i ? DisplayStyle.None : DisplayStyle.Flex;
            }
            stats = (_selected_item as Item).getStats();
            for(int i = 0; i < 6; ++i)
            {
                (_selected_items_stats.ElementAt(i) as SliderInt).value = stats[i];
                //(_player_stats.ElementAt(i) as SliderInt).value = stats[i];
            }
            _last_click_changed_cat = true;
        }
    }
    void seleccionaItem(ClickEvent evt)
    {
        //Debug.Log("Item");
        VisualElement miTarjeta = evt.target as VisualElement;
        if (miTarjeta is Item)
        {
            int[] stats = (_selected_item as Item).getStats();
            //if (!_last_click_changed_cat){
                for (int i = 0; i < 6; ++i)
                {
                    (_player_stats.ElementAt(i) as SliderInt).value -= stats[i];
                }
            //}

            Item selected = miTarjeta as Item;
            (_selected_item as Item).AssignItem(selected);
            (_category_selected_it as Item).AssignItem(selected);
            stats = (_selected_item as Item).getStats();
            for (int i = 0; i < 6; ++i)
            {
                (_selected_items_stats.ElementAt(i) as SliderInt).value = stats[i];
                (_player_stats.ElementAt(i) as SliderInt).value += stats[i];
            }

            Debug.Log(selected.Id);
            _items[(_category_selected_it as Item).Id] = selected.Id;
            _last_click_changed_cat = false;
        }
    }

    public void LoadLoadout(int[] loadout_array)
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement selectable_cat = root.Q("SelectableCategoriesSpace");
        VisualElement selectable_it = root.Q("SelectableItemsSpace");
        for(int j = 0; j < 6; ++j) { (_player_stats.ElementAt(j) as SliderInt).value = 0; }
        for (int i = 0; i < 3; ++i)
        {
            /*
            var stats = (_selected_item as Item).getStats();
            //if (!_last_click_changed_cat){
            for (int i = 0; i < 6; ++i)
            {
                (_player_stats.ElementAt(i) as SliderInt).value -= stats[i];
            }
            */

            if (loadout_array[i] >= 0)
                (_selected_item as Item).AssignItem((selectable_cat.ElementAt(i) as Item).AssignItem(selectable_it.ElementAt(i).ElementAt(loadout_array[i])));
            else
                (_selected_item as Item).AssignItem((selectable_cat.ElementAt(i) as Item).AssignVoidItem());

            var stats = (_selected_item as Item).getStats();
            for (int j = 0; j < 6; ++j)
            {
                //(_selected_items_stats.ElementAt(i) as SliderInt).value = stats[j];
                (_player_stats.ElementAt(j) as SliderInt).value += stats[j];
            }
        }
    }
}
