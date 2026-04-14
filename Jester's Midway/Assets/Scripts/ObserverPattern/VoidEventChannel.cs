using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Events/VoidEvent")]
public class VoidEventChannel : ScriptableObject
{
    public event UnityAction OnEventRaised; 
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
    private void OnEnable()
    {
        OnEventRaised = null;
    }
}