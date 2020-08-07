using System.Collections;
using UnityEngine;

public class CoroutineForUnlocked : MonoBehaviour
{
    public GameObject unlockScene;
    public GameObject panel1Scene;
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
        yield return new WaitForSeconds(1);
        panel1Scene.SetActive(false);
        unlockScene.SetActive(true);
    }
}
