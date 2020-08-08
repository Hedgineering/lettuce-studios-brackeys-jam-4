using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpinner : MonoBehaviour
{
    [System.Serializable]
    public class obstacles
    {
        public int ObjectType;

        public GameObject prefab;

        public int size;
    }

    public float speed;

    public bool Reverse;


    public List<obstacles> pools;

    public Dictionary<int, Queue<GameObject>> pooldictionary;
    // Start is called before the first frame update
    void Start()
    {
        pooldictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (obstacles o in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < o.size; i++)
            {
                GameObject obj = Instantiate(o.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);

            }
            pooldictionary.Add(o.ObjectType, objectpool);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Reverse)
        {

            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                Time.deltaTime * -speed);
        }
        else
        {

            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                Time.deltaTime * speed);
        }

    }

    public GameObject spawnObject(int objtype,Vector3 pos)
    {
        if (!pooldictionary.ContainsKey(objtype))
        {
            Debug.LogWarning("Pool object doesn't exist");
            return null;
        }

        GameObject spawn = pooldictionary[objtype].Dequeue();
        
        spawn.SetActive(true);

        spawn.transform.position = pos;
        spawn.transform.localScale = new Vector3(1,1,1);
        spawn.transform.parent = this.transform;

        pooldictionary[objtype].Enqueue(spawn);
        return spawn;
    }
}
