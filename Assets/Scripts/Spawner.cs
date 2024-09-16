
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _creationTime = 0.2f;

    [SerializeField] private int _minimumLifetime = 2;
    [SerializeField] private int _maximumLifetime = 5;

    private ObjectPool<Cube> _pool;

    private void Start()
    {
        _pool = new ObjectPool<Cube>(
            () => { return Instantiate(_cubePrefab); },
            OnGetCube,
            cube => { cube.gameObject.SetActive(false); },
            cube => { Destroy(cube.gameObject); }
            );

        InvokeRepeating(nameof(SpawnCube), _creationTime, _creationTime);
    }

    private void OnGetCube(Cube cube)
    {
        cube.gameObject.SetActive(true);
        cube.Initialize(Random.Range(_minimumLifetime, _maximumLifetime + 1), ReleaseCube);
        cube.transform.position = GetRandomPositionInSphere();
    }

    private Vector3 GetRandomPositionInSphere()
    {
        int diameterToRadius = 2;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * transform.localScale.x / diameterToRadius;
        return randomPoint;
    }

    private void SpawnCube() =>
        _pool.Get();

    private void ReleaseCube(Cube cube) =>
        _pool.Release(cube);   
}
