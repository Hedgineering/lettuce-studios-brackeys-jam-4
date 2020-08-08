using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    GameObject Point, Player, Disc, Knob;

    public bool rewind, invertControls, allowControlInversion;
    [SerializeField] float rewindDelay;
    [SerializeField] bool randomRewind;
    [SerializeField] [Tooltip("smaller = faster; ex: 0.5 = once every half second")] float _spawnRate;
    [SerializeField] [Tooltip("x = Catnip, y = thumbtac, z = yarnball")] Vector3 spawnRatio;
    [SerializeField] float _discSpeed = 200;
    [SerializeField] float survivalDuration;

    private float nextRewindTime, nextLevelTime;

    private void Start()
    {
        Point = GameObject.FindGameObjectWithTag("Spawnpoint");
        Player = GameObject.FindGameObjectWithTag("Player");
        Disc = GameObject.FindGameObjectWithTag("Disc");
        Knob = GameObject.FindGameObjectWithTag("Knob");

        nextRewindTime = Time.time + rewindDelay;
        nextLevelTime = Time.time + survivalDuration;
        invertControls = false;

        Point.GetComponent<BoxSpawner>().spawnRate = _spawnRate;
        

        Disc.GetComponent<DiscSpinner>().SetRatio(spawnRatio); //x = Catnip, y = thumbtac, z = yarnball
        Disc.GetComponent<DiscSpinner>().speed = _discSpeed;
    }

    private void Update()
    {
        //Rewind Mechanic
        if (!randomRewind)
        {
            //Time based rewind
            if (Time.time >= nextRewindTime) //if time to rewind, then rewind
            {
                rewind = !rewind;
                if (allowControlInversion) invertControls = !invertControls;
                nextRewindTime += rewindDelay;
            }
        }
        else
        {
            //Randomized Delay based rewind
            rewindDelay = UnityEngine.Random.Range(3, 10);
            if (Time.time >= nextRewindTime) //if time to rewind, then rewind
            {
                rewind = !rewind;
                if (allowControlInversion) invertControls = !invertControls;
                nextRewindTime += rewindDelay;
            }
        }

        if (rewind)
        {
            DiscSpinner.Reverse = true;
        }

        if (invertControls)
        {
            PlayerMovement.invertedControls = true;
        }

        //Scene Transition
        if (Time.time >= nextLevelTime)
        {
            SwitchToNextScene();
        }
    }

    private void SwitchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
