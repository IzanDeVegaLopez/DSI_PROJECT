using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dragger : PointerManipulator
{
    private Vector3 m_start;
    protected bool m_active;
    private int m_pointer_id;
    private Vector2 m_start_size;

    public Dragger()
    {
        m_pointer_id = -1;
        activators.Add(new ManipulatorActivationFilter { button = UnityEngine.UIElements.MouseButton.LeftMouse});
        m_active = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        //target.RegisterCallback<WheelEvent>(MouseWheelEvent);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        //target.UnregisterCallback<WheelEvent>(MouseWheelEvent);
    }

    protected void OnPointerDown(PointerDownEvent e)
    {
        if (m_active)
        {
            e.StopImmediatePropagation();
            return;
        }
        if (CanStartManipulation(e))
        {
            m_start = e.localPosition;
            //m_start_size = target.layout.size;
            m_pointer_id = e.pointerId;
            m_active = true;
            target.CapturePointer(m_pointer_id);
            e.StopPropagation();
        }
    }

    protected void OnPointerMove(PointerMoveEvent e)
    {
        if (!m_active || !target.HasPointerCapture(m_pointer_id))
            return;

        Vector2 diff = e.localPosition - m_start;

        target.style.marginLeft = new StyleLength(Mathf.Max(0,Mathf.Min(target.style.marginLeft.value.value + diff.x, 600)));
        target.style.marginTop = new StyleLength(Mathf.Max(0,Mathf.Min(target.style.marginTop.value.value + diff.y,300)));
        e.StopPropagation();
    }

    protected void OnPointerUp(PointerUpEvent e)
    {
        if (!m_active || !target.HasPointerCapture(m_pointer_id) || !CanStopManipulation(e))
            return;
        m_active = false;
        target.ReleasePointer(m_pointer_id);
        m_pointer_id = -1;
        e.StopPropagation();
    }

    protected void MouseWheelEvent(WheelEvent e)
    {

        float _my_delta_mod = e.delta.y;
        Vector2 v = target.layout.size;
        Debug.Log(v.x + " " + v.y + " ++ " + _my_delta_mod);
        Debug.Log("(x: " + (v.x + _my_delta_mod) + ", y: " + (v.y + _my_delta_mod) + ")");
        target.style.height = v.y + _my_delta_mod;
        target.style.width = v.x + _my_delta_mod;

        e.StopImmediatePropagation();
    }
}
