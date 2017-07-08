using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField] private float _killDelay;

    private void Start()
    {
        Destroy(gameObject, _killDelay);
    }
}
