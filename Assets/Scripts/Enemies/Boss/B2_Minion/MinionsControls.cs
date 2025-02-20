using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsControls : MonoBehaviour
{
    
    [SerializeField] GameObject[] differentMinions;
    [SerializeField] GameObject laser;

    [Header("Minion 1 ")]
    private float nextShot = 0.15f;
    [SerializeField] float fireDelay = 18f;

    [Header("Minion 2 ")]
    private float nextHeal = 0.15f;
    [SerializeField] float healDelay = 25f;

    [Header("Minion 3 ")]
    private float nextSpit = 0.15f;
    [SerializeField] float spitDelay = 10f;

    int totalNumber;

    private void Awake()
    {
        totalNumber = differentMinions.Length;
    }

    void Update()
    {
        if (!differentMinions[0].GetComponent<B2Minion1Behaviour>().isDead && Time.time > nextShot)
        {
            UpdateMinion1();
        }

        if (!differentMinions[1].GetComponent<B2Minion2Behaviour>().isDead && Time.time > nextHeal)
        {
            UpdateMinion2();
        }

        if (!differentMinions[2].GetComponent<B2Minion3Behaviour>().isDead && Time.time > nextSpit)
        {
            UpdateMinion3();
        }

        
        foreach(var differentMinion in differentMinions)
        {
            if(differentMinion.activeInHierarchy == false)
            {
                totalNumber--;
            }
        }

        if(totalNumber <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void UpdateMinion1()
    {
        differentMinions[0].GetComponent<B2Minion1Behaviour>().SetFire(false);
        laser.GetComponentInChildren<B2MinionLaser>().SetFire(false);
        nextShot = Time.time + fireDelay;
    }

    void UpdateMinion2()
    {
        differentMinions[1].GetComponent<B2Minion2Behaviour>().healBoss();
        nextHeal = Time.time + healDelay;
    }

    void UpdateMinion3()
    {
        differentMinions[2].GetComponent<B2Minion3Behaviour>().FireToxicSpit();
        nextSpit = Time.time + spitDelay;
    }
}
