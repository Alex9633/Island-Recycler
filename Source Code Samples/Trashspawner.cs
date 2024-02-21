using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Trashspawner : MonoBehaviour
{
    public GameObject Plastic, Plastic2, Plastic3;
    public GameObject Metal;
    public GameObject Glass;
    public GameObject Paper, Paper2, Paper3;

    static int trashCountLimit = 15;
    public static int trashCountTotal = 0;

    public float amplitude, frequency;
    Vector3 pos1;

    void Start()
    {
        pos1 = transform.position;
        StartCoroutine(ContinuousSpawn());
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * frequency) * amplitude + pos1.x, pos1.y, Mathf.Cos(Time.time * frequency) * amplitude + pos1.z);
    }

    GameObject getRandomMaterial()
    {
        var random = new System.Random();        
        var materialOptions = new List<GameObject>{
            Plastic, 
            Plastic, 
            Plastic, 
            Plastic2,  // Frequency of plastic - 40%
            Plastic3,
            Paper,
            Paper,
            Paper2, // Frequency of paper - 30%
            Paper3,
            Glass, 
            Glass, // Frequency of glass - 20%
            Glass,
            Metal, // Frequency of metal - 10%
            Metal
        };
        int pickedIndex = random.Next(materialOptions.Count);
        
        return materialOptions[pickedIndex];
    }
    
    IEnumerator ContinuousSpawn()
    {
        while (true)
        {
            if (trashCountTotal < trashCountLimit)
            {
                float timer = UnityEngine.Random.Range(5, 6);
                Instantiate(getRandomMaterial(), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                trashCountTotal++;
                yield return new WaitForSeconds(timer);
            }
            yield return null;
        }
    }
}
