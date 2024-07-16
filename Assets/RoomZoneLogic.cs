using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomZoneLogic : MonoBehaviour
{
    MeshCollider meshCollider;
    Vector3 maxBound;
    Vector3 minBound;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        minBound = meshCollider.bounds.min;
        maxBound = meshCollider.bounds.max;
        Debug.Log($"random point is {GetRandomPoint()}");
    }

    public Vector3 GetRandomPoint()
    {
        Vector3 randomPoint;
        randomPoint = new Vector3(
                Random.Range(minBound.x, maxBound.x),
                Random.Range(minBound.y, maxBound.y),
                Random.Range(minBound.z, maxBound.z)
            );
        return randomPoint;
    }
}
