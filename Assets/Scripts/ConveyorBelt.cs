using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] List<GameObject> objOnBelt;
    [SerializeField] bool isEnabled = false;

    void Update()
    {
        if (!isEnabled) return;
        if (objOnBelt.Count > 0)
        {
            for (int i = 0; i < objOnBelt.Count; i++)
            {
                objOnBelt[i].GetComponent<Rigidbody>().AddForce(movementSpeed * direction.x,
                    movementSpeed * direction.y,
                    movementSpeed * direction.z
                , ForceMode.Acceleration);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            objOnBelt.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            objOnBelt.Remove(collision.gameObject);
        }
    }

    public void TurnOn()
    {
        if (!isEnabled) isEnabled = true;
    }
}
