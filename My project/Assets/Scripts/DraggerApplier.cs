using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DraggerApplier : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        //VisualElement draggableIt = root.Q("DraggableIt1");
        root.Q("DraggableIt1").AddManipulator(new Dragger());
        root.Q("DraggableIt2").AddManipulator(new Dragger());
    }
}
