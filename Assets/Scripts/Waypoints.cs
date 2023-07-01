using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake ()
    {
        points = new Transform[transform.childCount]; // T?o 13 kho?ng cách trong m?ng
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
