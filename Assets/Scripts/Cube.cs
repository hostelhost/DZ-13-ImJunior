using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _lifetime;

    public void Initialize(int lifetime)
    {
        _lifetime = lifetime;
    }
}
