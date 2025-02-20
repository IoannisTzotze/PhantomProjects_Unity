using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnergyPotionBehaviour : MonoBehaviour
{

    [SerializeField] int recoverAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().IncreaseEnergy(recoverAmount);

            Destroy(this.gameObject);
        }
    }
}
