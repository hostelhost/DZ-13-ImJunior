using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeBuilder _cubeBilder;

    private List<Vector3> _SpawnPositions = new();

    private void Awake()
    {
        List<SpawnPosition> positions = new(positions = GetComponentsInChildren<SpawnPosition>().ToList());

        foreach (SpawnPosition position in positions)
            _SpawnPositions.Add(position.transform.position);
    }

    private float timer;

    private void Update() //
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            CreateCube();
        }
    }

    private Vector3 RandomPosition()
    {
        return _SpawnPositions[Random.Range(0, _SpawnPositions.Count)];
    }

    private void CreateCube()
    {
        _cubeBilder.Create(RandomPosition());
    }
}
