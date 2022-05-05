using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject rightController;
    [SerializeField]
    LineRenderer rayObject;
    [SerializeField]
    GameObject plusPrefab;
    private GameObject plusObject;
    private Vector3 endPos;
    private bool hit_f;
    // Start is called before the first frame update
    void Start()
    {
        rayObject.positionCount = 2; //頂点数を2個に設定（始点と終点）
        rayObject.startWidth = 0.01f; //線の太さを0.01mに設定
        rayObject.endWidth = 0.01f; //線の太さを0.01mに設定
    }

    // Update is called once per frame
    void Update()
    {
        hit_f = false;
        endPos = rightController.transform.position + rightController.transform.forward * 100.0f;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(rightController.transform.position, rightController.transform.forward, 100.0f);
        foreach (var hit in hits)
        {
            endPos = hit.point;
            if (hit.collider.tag == "bridge")
            {
                hit_f = true;
                if (plusObject == null)
                {
                    Quaternion vertical_qua = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    plusObject = Instantiate(plusPrefab, hit.point, vertical_qua);
                }
                else
                {
                    plusObject.transform.position = hit.point;
                }

                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    hit.transform.localScale = new Vector3(hit.transform.localScale.x, hit.transform.localScale.y + 0.1f, hit.transform.localScale.z);
                }
                break;
            }
        }

        if (!hit_f)
        {
            Destroy(plusObject);
        }

        rayObject.SetPosition(0, rightController.transform.position);
        rayObject.SetPosition(1, endPos);
    }
}
