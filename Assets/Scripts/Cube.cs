using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _lifetime;
    private bool _isCollision;
    private Action<Cube> _onDead;

    public void Initialize(int lifetime, Action<Cube> onDead)
    {
        _lifetime = lifetime;
        _isCollision = false;
        _onDead = onDead;
        GetComponent<Renderer>().material.color = Color.white;
    }

    private IEnumerator TimerToDeath()
    {
        yield return new WaitForSeconds(_lifetime);

        _onDead?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isCollision == false)
        {
            if (collision.collider.GetComponent<TriggerPlatform>())
            {
                _isCollision = true;
                SetRandomColor();
                StartCoroutine(TimerToDeath());
            }
        }
    }

    private void SetRandomColor() =>
          GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
}
