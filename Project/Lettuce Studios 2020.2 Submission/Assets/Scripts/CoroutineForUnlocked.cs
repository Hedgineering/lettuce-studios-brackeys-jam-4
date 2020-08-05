using System.Collections;
using UnityEngine;

public class CoroutineForUnlocked : MonoBehaviour
{
    public GameObject unlockScene;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void UnlockedScenOpen()
    {
        StartCoroutine(UnlockPause());
    }
    
    public IEnumerator UnlockPause()
    {
        yield return new WaitForSeconds(2);
        unlockScene.SetActive(true);
    }
}
