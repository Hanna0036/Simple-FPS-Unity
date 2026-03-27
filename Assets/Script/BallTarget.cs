using UnityEngine;
using System.Collections;

public class BallTarget : MonoBehaviour
{
    public float minX = -8f;
    public float maxX = 8f;
    public float minZ = 5f;
    public float maxZ = 20f;
    public float fixedY = 1.5f;

    public void GetHit()
    {
        Respawn();
    }

    void Respawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        transform.position = new Vector3(randomX, fixedY, randomZ);
        StartCoroutine(PopEffect());
    }

    IEnumerator PopEffect()
    {
        transform.localScale = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 5f;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}