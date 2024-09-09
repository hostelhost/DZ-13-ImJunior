using UnityEngine;

public class CubeBuilder : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minimumLifetime = 2;
    [SerializeField] private int _maximumLifetime = 5;

    public void Create(Vector3 position)
    {
        Cube newCube = _cube;
        Instantiate(newCube, position, Quaternion.identity);
        newCube.Start(Random.Range(_minimumLifetime, _maximumLifetime+1));
    }
}
