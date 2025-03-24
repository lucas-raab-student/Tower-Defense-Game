
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject prefab;
    public float SpawnRate = 1f;
    void Start()
    {
        StartCoroutine(Spawn());
    }
IEnumerator Spawn()
    {
        while (spawn)
        {
            Instantiate(prefab,transform.position,transform.rotation);
            yield return new WaitForSeconds(SpawnRate);

        }
    }
}
