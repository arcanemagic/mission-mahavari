using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Period1;
    public GameObject Period2;
    public GameObject Period3;
    public GameObject Period4;
    public GameObject Period5;
    public GameObject Cramp1;
    public GameObject Cramp2;

    public void EnemySpawnControlPeriod()
    {
        Period1.SetActive(true);
        Period2.SetActive(true);
        Period3.SetActive(true);
        Period4.SetActive(true);
        Period5.SetActive(true);
    }

    public void EnemySpawnControlCramp()
    {
        Cramp1.SetActive(true);
        Cramp2.SetActive(true);
    }
}
