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
        Debug.Log(_lifetime + "Initialize");
    }

    private IEnumerator TimerToDeath()
    {
        Debug.Log(_lifetime+ "TimerToDeath");

        //for (float t = 0; t < _lifetime; t += Time.deltaTime)
        //{
        //    yield return null; //прерывает корутину до следующего Updat-a
        //}

        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<TriggerPlatform>())
        {
            _isCollision = true;
            SetRandomColor();
            StartCoroutine(TimerToDeath());
        }
    }

    private void SetRandomColor() =>
          GetComponent<Renderer>().material.color = Random.ColorHSV();
}
