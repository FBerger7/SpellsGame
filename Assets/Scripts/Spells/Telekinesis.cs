using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;

    //Vector3 previousGrabPosition;

    // ---------------------------------

    //float chargeTime = 0;

    // ---------------------------------

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        //if (grabbedObject == null || !CanGrab(grabObject))
        if (grabbedObject == null)
            return;
        grabbedObject = grabObject;
        //grabbedObjectSize = grabbedObject.GetComponent<MeshRenderer>().bounds.size.magnitude;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
        //grabbedObject.GetComponent<Rigidbody>().useGravity = false;        
    }

    //void DropObject(/* float pushForce*/)
    //{
    //    if (grabbedObject == null)
    //        return;
    //    Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
    //        float speed = throwVector.magnitude / Time.deltaTime;
    //        Vector3 throwVelocity = speed * throwVector.normalized;

    //        // ---------------------------------

    //        //throwVelocity += Camera.main.transform.forward * pushForce;

    //        // ---------------------------------

    //        rb.velocity = throwVelocity;
    //        rb.useGravity = true;
    //    }
    //    grabbedObject = null;
    //}

    void DropObject()
    {
        if (grabbedObject == null)
            return;
        grabbedObject = null;
    }

    //bool CanGrab(GameObject candidate)
    //{
    //    return candidate.GetComponent<Rigidbody>() != null;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(100));
            else
                DropObject();
        }

        // ---------------------------------

        //if (Input.GetMouseButton(0))
        //    chargeTime += Time.deltaTime;

        //if (Input.GetMouseButtonUp(0))
        //{
        //    float pushForce = chargeTime * 20;
        //    pushForce = Mathf.Clamp(pushForce, 1, 100);
        //    DropObject(pushForce);
        //    chargeTime = 0;
        //}

        // ---------------------------------

        if (grabbedObject != null)
        {
            //previousGrabPosition = grabbedObject.transform.position;
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
        }
    }
}
