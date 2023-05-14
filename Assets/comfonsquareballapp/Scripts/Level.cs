using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(nameof(Spawning));
    }

    private void OnDestroy()
    {
        StopCoroutine(nameof(Spawning));
    }

    private IEnumerator Spawning()
    {
        var prefabs = Resources.LoadAll<GameObject>("obstacles");
        
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1.65f, 2.45f));

            var obstacle = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform);
            obstacle.transform.position = new Vector2(0, 15);
            Destroy(obstacle, 15.5f);
        }
    }
}
