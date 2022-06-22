using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudesLooking : MonoBehaviour
{
    private Transform target;
    public float turnSpeed = 10f;
    public GameObject Player;
    public GameObject[] AngryPeople;
    public GameObject particleHit;
    private GameObject instantiatedObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void DisableAnger()
    {
        for (int i = 0; i < AngryPeople.Length; i++)
        {
            instantiatedObject = (GameObject) Instantiate(particleHit, AngryPeople[i].transform.position, AngryPeople[i].transform.rotation);
            AngryPeople[i].SetActive(false);
            Destroy(instantiatedObject, 1.5f);
        }
    }
}
