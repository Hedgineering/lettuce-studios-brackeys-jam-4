using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    //[System.Serializable]
    //public class obstacles
    //{
    //    public int ObjectType;
    //
    //    public GameObject prefab;
    //
    //    public int size;
    //}

    [SerializeField] Transform disc;

    [SerializeField] int ObstacletTypeMax;

    //public List<obstacles> pools;

    public float spawnRate;
    public LayerMask disconly;
    float t;

    //public Dictionary<int, Queue<GameObject>> pooldictionary;

    void Start()
    {

        //pooldictionary = new Dictionary<int, Queue<GameObject>>();
        //
        //foreach (obstacles o in pools)
        //{
        //    Queue<GameObject> objectpool = new Queue<GameObject>();
        //
        //    for (int i = 0; i < o.size; i++)
        //    {
        //        GameObject obj = Instantiate(o.prefab);
        //        obj.SetActive(false);
        //        objectpool.Enqueue(obj);
        //
        //    }
        //    pooldictionary.Add(o.ObjectType, objectpool);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;

        if(t>= spawnRate)
        {
            t = 0;
            spawnrandombox();
        }

    }


    void spawnrandombox()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 7,disconly))
        {
            int randomNum = Random.Range(0,ObstacletTypeMax);

            disc.GetComponent<DiscSpinner>().spawnObject(randomNum, hit.point + Vector3.up * 0.03f);

            //spawnObject(randomNum).transform.SetParent(disc);
           
        }

    }


    //GameObject spawnObject(int objtype)
    //{
    //    if (!pooldictionary.ContainsKey(objtype))
    //    {
    //        Debug.LogWarning("Pool object doesn't exist");
    //        return null; 
    //    }
    //
    //    GameObject spawn = pooldictionary[objtype].Dequeue();
    //
    //    spawn.SetActive(true);
    //
    //    pooldictionary[objtype].Enqueue(spawn);
    //    return spawn;
    //}
}
