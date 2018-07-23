using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DispatcherDestroyed : MonoBehaviour
{
    public UnityEvent destroyed;

    private void OnDestroy()
    {
        destroyed.Invoke();
    }
}
