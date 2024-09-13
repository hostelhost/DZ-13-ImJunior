using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _lifetime;
    private bool _isCollision;

    public void Initialize(int lifetime)
    {
        _lifetime = lifetime;
    }

    private IEnumerator TimerToDeath()
    {
        yield return new WaitForSeconds(_lifetime);

        Destroy(gameObject);
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
          GetComponent<Renderer>().material.color = Random.ColorHSV();
}
