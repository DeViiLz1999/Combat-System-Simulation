using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBloodSplatter : MonoBehaviour
{
    public float time = 2f;

    private void Awake()
    {
        Destroy(gameObject, time);
    }
}
