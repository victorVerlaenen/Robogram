using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    [SerializeField] float _lifeTime = 1.0f;

    private void Awake()
    {
        Invoke("Kill", _lifeTime);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
