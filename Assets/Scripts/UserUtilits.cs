using UnityEngine;

public class UserUtilits : MonoBehaviour
{
    public static int RandomNumber(int mimimym, int maximum)
    {
        return Random.Range(mimimym, ++maximum);
    }
}
