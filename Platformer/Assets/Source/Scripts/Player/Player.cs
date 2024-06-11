using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(KeyboardInput))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public int MaxKeys { get; private set; }
    public Action OnChangeKeyCounter;
    private List<Key> _keys = new List<Key>();

    public int GetKeysCount()
    {
        return _keys.Count;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Key key))
        {
            if (_keys.Contains(key))
                return;

            _keys.Add(key);
            Destroy(key.gameObject);
            OnChangeKeyCounter?.Invoke();
        }
    }
}
