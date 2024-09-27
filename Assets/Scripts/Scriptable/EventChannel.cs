using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event Channel")]

public class EventChannel : ScriptableObject
{
    public UnityAction OnEventRaise;

    public void RaiseEvent()
    {
        OnEventRaise?.Invoke();
    }
}
