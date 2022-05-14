using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldValueRmult : MonoBehaviour
{
    public bool isHoldingRight;
    public int intVal = 1;
    public float floatVal = 1;
    public string stringVal;
    public GameObject objectInHandRight;
    public Vector3 holdT;
    public Quaternion holdR;

    private void Start()
    {
        isHoldingRight = false;
        holdT = this.gameObject.transform.localPosition;
        holdR = this.gameObject.transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Value") && isHoldingRight == false)
        {
            intVal = other.gameObject.GetComponent<ValueLogicInt>().value;
            floatVal = other.gameObject.GetComponent<ValueLogicFloat>().value;
            stringVal = other.gameObject.GetComponent<ValueLogicString>().value;
            isHoldingRight = true;
            objectInHandRight = other.gameObject;
            other.gameObject.transform.localPosition = holdT;
            other.gameObject.transform.rotation = holdR;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Value"))
        {
            isHoldingRight = false;
            intVal = 1;
            floatVal = 1;
            stringVal = "";
            objectInHandRight = null;
        }
    }
}
