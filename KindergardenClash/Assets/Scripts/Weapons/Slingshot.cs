using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject rockPrefab;

    bool isCharging;
    int ammo = 10;
    float nextAttack;
    float fireRate = 0.5f;
    float chargeTime;
    float maxChargeTime = 2f;
    Vector3 target;

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && ammo > 0 && Time.time >= nextAttack)
        {
            isCharging = true;
            chargeTime = Mathf.Min(chargeTime + Time.deltaTime, maxChargeTime);

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            { 
                target = hit.point;
            }
            else
            {
                target = ray.GetPoint(100); // Arbitrary far point
            }

        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && isCharging)
        {
            Shoot(target);
            isCharging = false;
            nextAttack = Time.time + fireRate;
        }
    }

    void Shoot(Vector3 target)
    {
        float power = Mathf.Clamp(chargeTime / maxChargeTime, 0.1f, 1f);
        //Instantiate projectile with power
        ammo--;
        chargeTime = 0;
    }
}
