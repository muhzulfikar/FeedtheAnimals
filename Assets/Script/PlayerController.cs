using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20f;
    private float xRange = 16f;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Untuk pergerakan Karakter
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Untuk membatasi pergerakan player di dalam layar
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Melemparkan makanan saat tekan Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
            }
        }
    }
}
