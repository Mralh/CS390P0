using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWRotPlayer : MonoBehaviour {

    float crosshairAlpha = 0.0f;
	void FixedUpdate ()
    {
        RaycastHit[] ray = Physics.RaycastAll(transform.position, transform.forward, 50, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (RaycastHit r in ray)
        {
            if (r.collider.transform.parent.gameObject.GetComponent<Spookman>() != null)
            {
                r.collider.transform.parent.gameObject.GetComponent<Spookman>().gaze();
                transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color = new Color(1, 1, 1, 0.3f);
                break;
            }
            Debug.Log("Hit");
        }
        transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color = new Color(1, 1, 1, 
            transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color.a - 0.05f);
    }
}
