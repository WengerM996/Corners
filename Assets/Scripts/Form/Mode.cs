using UnityEngine;
using UnityEngine.Events;

public class Mode : MonoBehaviour
{
    public event UnityAction PVPSelected;
    public event UnityAction AISelected;

    public void OnPVPModeCLick()
    {
        PVPSelected?.Invoke();
    }

    public void OnAIModeClick()
    {
        AISelected?.Invoke();
    }
}
