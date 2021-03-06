using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LAZERVertical : MonoBehaviour
{
    [SerializeField] Pool pool;
    [SerializeField] Transform spawnOrigin;
    Vector3 spawnPoint;

    [SerializeField] int length;
    [SerializeField] Vector3 addPos;
    public bool attackOver;

    [SerializeField] float despawn;
    float spawnRate;

    GameObject LAZERBoss;

    [SerializeField] List<GameObject> listLazer = new List<GameObject>();

    private void Start()
    {
        spawnPoint = spawnOrigin.position;
        attackOver = false;
        //spawnRate = maxRate;
    }

    void SpawnBullet()
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.position = spawnPoint;
        LAZERBoss.GetComponent<LAZERVert>().Spawn(pool);
        listLazer.Add(LAZERBoss);
    }

    [Button]
    IEnumerator Shoot()
    {
        for (int i = 0; i < length; i++)
        {
            SpawnBullet();
            spawnPoint += addPos;

            yield return new WaitForSeconds(0.2f);
            Invoke("ReturnLazer",despawn);
        }
        yield return null;
    }

    void ReturnLazer()
    {
        if (listLazer != null)
        {
            listLazer[0].GetComponent<LAZERVert>().Return(pool);
            listLazer.RemoveAt(0);

            if (listLazer.Count == 0)
            {
                spawnPoint = spawnOrigin.position;
                attackOver = true;
                StopAllCoroutines();
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(Shoot());
    }
}
