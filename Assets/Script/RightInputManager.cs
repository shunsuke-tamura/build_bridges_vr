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
        rayObject.SetPosition(0, rightController.transform.position); // 0番目の頂点を左手コントローラの位置に設定
        rayObject.SetPosition(1, rightController.transform.position + rightController.transform.forward * 100.0f); // 1番目の頂点を左手コントローラの位置から100m先に設定

        RaycastHit[] hits;
        hits = Physics.RaycastAll(rightController.transform.position, rightController.transform.forward, 100.0f);
        foreach (var hit in hits)
        {
            if (hit.collider.tag == "bridge")
            {
                if (plusObject == null)
                {
                    Quaternion vertical_qua = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    plusObject = Instantiate(plusPrefab, hit.point, vertical_qua);
                }
                else
                {
                    plusObject.transform.position = hit.point;
                }
                break;
            }
        }
    }
}
