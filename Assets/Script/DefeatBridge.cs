using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefeatBridge : MonoBehaviour
{
    private GameObject bridge;
    private Transform button_tr;
    private Vector3 force, force_position;
    // Start is called before the first frame update
    void Start()
    {
        bridge = transform.Find("bridge").gameObject;
        button_tr = transform.Find("DefeatButton/Pedestal/Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushDefeatButton()
    {
        Debug.Log("push");
        Vector3 button_pos = button_tr.position; 
        button_tr.position = new Vector3(button_pos.x, button_pos.y - 0.03f, button_pos.z);
        Rigidbody buridge_rb = bridge.GetComponent<Rigidbody>();
        force = bridge.transform.forward * 6.0f * bridge.transform.localScale.y;
        force_position = new Vector3(bridge.transform.position.x, bridge.transform.position.y + bridge.transform.localScale.y, bridge.transform.position.z);
        buridge_rb.AddForceAtPosition(force, force_position, ForceMode.Impulse);
        StartCoroutine(DelayCoroutine(0.5f, () =>
        {
            button_tr.position = button_pos;
        }));
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
