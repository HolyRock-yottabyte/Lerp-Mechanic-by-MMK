using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            if (!LerpRush.instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                //other.gameObject.AddComponent<Rigidbody>().isKinematic = true;

                LerpRush.instance.StackObj(other.gameObject, LerpRush.instance.cubes.Count - 1);


            }
        }
    }
}
