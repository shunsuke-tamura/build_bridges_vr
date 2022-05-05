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
        rayObject.positionCount = 2; //���_����2�ɐݒ�i�n�_�ƏI�_�j
        rayObject.startWidth = 0.01f; //���̑�����0.01m�ɐݒ�
        rayObject.endWidth = 0.01f; //���̑�����0.01m�ɐݒ�
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

        rayObject.SetPosition(0, leftController.transform.position); // 0�Ԗڂ̒��_������R���g���[���̈ʒu�ɐݒ�
        rayObject.SetPosition(1, endPos); // 1�Ԗڂ̒��_������R���g���[���̈ʒu����100m��ɐݒ�
    }
}
