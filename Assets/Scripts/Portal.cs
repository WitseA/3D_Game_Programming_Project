using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.tag == "Player" && player != null)
        {
            player.transform.position = new Vector3(-155f, 98f, 58f);
            player.transform.rotation = new Quaternion(0,0,0,0);
        }
    }
}
