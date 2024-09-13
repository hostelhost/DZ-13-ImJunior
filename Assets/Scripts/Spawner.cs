using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeBuilder _cubeBilder;
    [SerializeField] private float _creationTime = 0.2f;
    private ObjectPool<GameObject> _pool;

    private void Start()
    {     
        InvokeRepeating(nameof(CreateCube), _creationTime, _creationTime);
    }

    private Vector3 GetRandomPositionInSphere()
    {
        int diameterToRadius = 2;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * transform.localScale.x / diameterToRadius;
        return randomPoint;
    }

    private void CreateCube()
    {
        _cubeBilder.Create(GetRandomPositionInSphere());
    }
}
