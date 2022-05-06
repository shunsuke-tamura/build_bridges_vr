using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet(Vector3 start_pos, Vector3 direction, float power)
    {
        GameObject bulletObject = Instantiate(bulletPrefab, start_pos, Quaternion.identity);
        bulletObject.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
    }
}
