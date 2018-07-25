using UnityEngine;
using UnityEngine.Events;

public class Vitality : MonoBehaviour
{
    public UnityEvent destroyed;

    public void Kill()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Die");
        destroyed.Invoke();
    }
}
