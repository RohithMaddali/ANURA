using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSounds : MonoBehaviour
    {
        //spawn sounds around player
        //spawn location is random
        //possibly make sound move. Lerp?

         [SerializeField]
         private float xMin;
         [SerializeField]
         private float xMax;

        [SerializeField]
        private float zMin;
       [SerializeField]
         float zMax;
        [SerializeField]
        private GameObject source01;


        private void Start()
        {
            StartCoroutine(SoundSpawner());
        }

        IEnumerator SoundSpawner()
        {
            yield return new WaitForSeconds(4);
            Instantiate(source01, new Vector3(transform.position.x + Random.Range(xMin, xMax), transform.position.y, transform.position.z + Random.Range(zMin, zMax)), Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(source01, new Vector3(transform.position.x + Random.Range(xMin, xMax), transform.position.y, transform.position.z + Random.Range(zMin, zMax)), Quaternion.identity);
        }
    }


