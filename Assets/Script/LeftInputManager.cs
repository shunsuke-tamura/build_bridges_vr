using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject leftController;
    [SerializeField]
    LineRenderer rayObject;
    [SerializeField]
    GameObject minusPrefab;
    private GameObject minusObject;
    private Vector3 endPos;
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
        endPos = leftController.transform.position + leftController.transform.forward * 100.0f;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(leftController.transform.position, leftController.transform.forward, 100.0f);
        foreach (var hit in hits)
        {
            endPos = hit.point;
            if (hit.collider.tag == "bridge")
            {
                if (minusObject == null)
                {
                    Quaternion vertical_qua = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    minusObject = Instantiate(minusPrefab, hit.point, vertical_qua);
                }
                else
                {
                    minusObject.transform.position = hit.point;
                }
                break;
            }
        }

        rayObject.SetPosition(0, leftController.transform.position); // 0番目の頂点を左手コントローラの位置に設定
        rayObject.SetPosition(1, endPos); // 1番目の頂点を左手コントローラの位置から100m先に設定
    }
}
