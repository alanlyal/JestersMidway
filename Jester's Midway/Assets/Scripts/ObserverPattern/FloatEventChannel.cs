using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/FloatEvent")]
public class FloatEventChannel : ScriptableObject
{
    public UnityAction<float> OnEventRaised;

    public void RaiseEvent(float value)
    {
        if (OnEventRaised == null) return;
        OnEventRaised.Invoke(value);
    }
}
