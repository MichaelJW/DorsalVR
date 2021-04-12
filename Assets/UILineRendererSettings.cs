using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILineRendererSettings : MonoBehaviour {
    LineRenderer lr;

    Vector3[] points;

    // Start is called before the first frame update
    void Start() {
        lr = gameObject.GetComponent<LineRenderer>();
        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + (transform.forward.normalized * 20);

        lr.SetPositions(points);
        lr.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        //CheckHit();
    }

    public void ClickedStart() {
        Debug.Log("You clicked Start! Well done");
    }

    public void CheckHit() {
        Ray ray = new Ray(transform.position, transform.forward.normalized);
        RaycastHit hit;
        int layerMask = 1 << 5;
        //Debug.Log(~(1 << 5));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            Debug.Log(hit.collider.gameObject.name);
            //Debug.Log(hit.collider.gameObject.GetComponent<Button>().name);
        }
    }
}
