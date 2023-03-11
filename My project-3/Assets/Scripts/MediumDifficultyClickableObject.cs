using UnityEngine;
using UnityEngine.SceneManagement;

public class MediumDifficultyClickableObject : MonoBehaviour
{
    public Vector3 spawnRange = new Vector3(2, 4, 5);
    void OnMouseDown()
    {
        Vector3 size = transform.lossyScale;
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
        newPosition.y = Random.Range(size.y, spawnRange.y);
        newPosition.z = Random.Range(spawnRange.z, (float)1.5 * spawnRange.z);
        transform.position = newPosition;
    }
}