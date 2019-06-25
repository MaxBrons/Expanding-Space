using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject _Bullet, Rocket;
    public Transform[] barrelAndRocket;
    public Transform player;
    float speed = 10;

    public bool MayShoot_Normal = true, MayShoot_Burst = true, MayShoot_Rocket = true;

    void FixedUpdate()
    {
        //The enemy will rotate towards the player properly if in range of the trigger
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+90;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        if (MayShoot_Normal == true)
            StartCoroutine(Shoot());

    }

    public IEnumerator Shoot()
    {
        MayShoot_Normal = false;
        if (!MayShoot_Normal)
        {
            GameObject BULLET = Instantiate(_Bullet, barrelAndRocket[0].position, Quaternion.identity);
            Vector2 direction = new Vector2(Input.GetAxis("Mouse X"), 0);
            BULLET.GetComponent<Rigidbody2D>().velocity = direction * speed;
            BULLET.transform.Rotate(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
        yield return new WaitForSeconds(1f);
        MayShoot_Normal = true;
    }

    public IEnumerator Shoot_Burst()
    {
        yield return new WaitForSeconds(1.3f);
    }

    public IEnumerator Shoot_Rockets()
    {
        yield return new WaitForSeconds(2f);
    }
}
