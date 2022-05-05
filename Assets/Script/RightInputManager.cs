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
        rayObject.positionCount = 2; //���_����2�ɐݒ�i�n�_�ƏI�_�j
        rayObject.startWidth = 0.01f; //���̑�����0.01m�ɐݒ�
        rayObject.endWidth = 0.01f; //���̑�����0.01m�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        rayObject.SetPosition(0, rightController.transform.position); // 0�Ԗڂ̒��_������R���g���[���̈ʒu�ɐݒ�
        rayObject.SetPosition(1, rightController.transform.position + rightController.transform.forward * 100.0f); // 1�Ԗڂ̒��_������R���g���[���̈ʒu����100m��ɐݒ�

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
