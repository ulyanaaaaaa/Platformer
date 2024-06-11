using System;
using UnityEngine;

public class GroundCheker : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ground>())
        {
            OnEnter?.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Ground>())
        {
            OnExit?.Invoke();
        }
    }
}
