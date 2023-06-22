using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bottles;
    [SerializeField] private List<Transform> points;

    private IEnumerator bottleSpawner()
    {
        while (true)
        {
            var pointsIndex = Random.Range(0, points.Count);
            var bottleIndex = Random.Range(0, bottles.Length);

            Instantiate(bottles[bottleIndex], points[pointsIndex].transform.position, transform.rotation);

            yield return new WaitForSeconds(3f);
        }
    }
    private void Start()
    {
        StartCoroutine(bottleSpawner());
    }
}
 