using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _lifetime;
    private bool _isCollision;

    public void Start(int lifetime)
    {
        _lifetime = lifetime;
    }

    //public void Initialize(int lifetime)
    //{
    //    _lifetime = lifetime;
    //}

    private IEnumerator TimerToDeath()
    {
        Debug.Log(_lifetime);

        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            yield return null; //прерывает корутину до следующего Updat-a
        }

        //yield return new WaitForSecondsRealtime(_lifetime);

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
