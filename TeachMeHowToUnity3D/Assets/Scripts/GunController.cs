using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    public float force = 1f;
    public int poolSize = 10;
    List<GameObject> objectPool;
    GameObject bullet;
    Vector3 outOfView = new Vector3(100f, 100f, 100f);
    int index;

    void Awake()
    {
        CreatePool();
    }

    public void MoveIntoPosition(Vector3 newPosition)
    {
        objectPool[index].transform.position = newPosition;
        objectPool[index].SetActive(true);
        objectPool[index].rigidbody.AddForce(0f, 0f, force);
        index++;
        if (index >= objectPool.Count) index = 0;
    }

    public void Reset(int index)
    {
        objectPool[index].SetActive(false);
        objectPool[index].transform.position = outOfView;
    }

    void CreatePool()
    {
        bullet = Resources.Load("Prefabs/Bullet", typeof(GameObject)) as GameObject;

        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(bullet, outOfView, Quaternion.identity) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = "Bullet" + i;
            objectPool[i].SetActive(false);
        }
    }
}
