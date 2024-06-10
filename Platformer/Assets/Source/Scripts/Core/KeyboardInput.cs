using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Action OnRightCliked;
    public Action OnLeftCliked;
    public Action OnJumpCliked;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            OnJumpCliked?.Invoke();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            OnRightCliked?.Invoke();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            OnLeftCliked?.Invoke();
    }
}
