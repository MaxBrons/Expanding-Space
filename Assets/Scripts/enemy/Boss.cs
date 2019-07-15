using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public AudioManager FXAudioManager;
    private GameObject player;
    public GameObject Material;
    public GameObject LaserCharge;
    public GameObject WinFadeOut;

    Vector3 pos;
    int i = 0;

    [Header("Health")]
    public Slider slider;
    private int Health;
    private bool Dead = false;

    [Header("Weapons")]
    public float offset;
    Vector3 LaserOffset;
    public GameObject _Bullet, Rocket;
    public Transform[] barrelAndRocket;
    public LineRenderer lineRenderer;

    [Header("Attack")]
    public bool MayShoot_Normal = false;
    public bool MayShoot_Burst = false;
    public bool MayShoot_Rocket = false;
    public bool UseLaser = false;
    float timer = 3;
    int randAttack;

    private void Start()
    {
        //Sets health of Boss and sets the healthbar of the Boss
        Health = Random.Range(90, 126);
        slider.maxValue = Health;
        slider.value = Health;

        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer.enabled = false;
    }

    void FixedUpdate()
    {
        if (!Dead)
        {
            // Handles the rotation
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            //Gets a new attack for the boss when the time runs out
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                randAttack = Random.Range(0, 3);
                RandomAttack();
                timer = 2;
            }

            //Points the laser in the set position
            if (lineRenderer.enabled)
            {
                lineRenderer.SetPosition(0, barrelAndRocket[4].position);
                lineRenderer.SetPosition(1, player.transform.position - LaserOffset);
            }
        }
        else if (GameObject.FindGameObjectsWithTag("Material").Length == 0)
        {
            Menu.cameraPosBool = true;
            Instantiate(WinFadeOut);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && Health > 0)
        {
            //Health and healthbar of the Boss
            Health -= Random.Range(1, 4);
            slider.value = Health;
        }

        if(Health < 1)
        {
            Dead = true;
            StartCoroutine(Die());
        }
            
    }

    void RandomAttack()
    {
        //Sets the attack off the boss
        Debug.Log(randAttack);
        if (!MayShoot_Normal && randAttack == 0)
            StartCoroutine(Shoot());
        else if (!MayShoot_Burst && randAttack == 1)
        {
            Instantiate(LaserCharge, gameObject.transform.GetChild(4).transform.position, Quaternion.identity);
            StartCoroutine(Shoot_Laser());
        }
        else if (!MayShoot_Rocket && randAttack == 2)
            StartCoroutine(Shoot_Rockets());
        else
            StartCoroutine(Shoot());
    }
    
    //Shoots a normal bullet from the two bullet fireing holes
    public IEnumerator Shoot()
    {
        FXAudioManager.FXAudio(6);

        MayShoot_Normal = true;
        if (MayShoot_Normal)
        {
            for(int i = 0; i < barrelAndRocket.Length - 3; i++)
                Instantiate(_Bullet, barrelAndRocket[i].transform.position, barrelAndRocket[i].transform.rotation);
        }
        yield return new WaitForSeconds(1f);
        MayShoot_Normal = false;
        StopCoroutine(Shoot());
    }

    //Fires a laser in the player's direction
    public IEnumerator Shoot_Laser()
    {
        MayShoot_Burst = true;
        if (lineRenderer && MayShoot_Burst)
        {
            yield return new WaitForSeconds(1.02f);

            var pickRandomOffset = Random.Range(-4, 4);
            LaserOffset = new Vector3(pickRandomOffset, 0, 0);

            lineRenderer.SetPosition(0, barrelAndRocket[4].position);
            lineRenderer.SetPosition(1, player.transform.position - LaserOffset);
            lineRenderer.enabled = true;

            if (pickRandomOffset == 0)
                player.GetComponent<playerController>().PlayerHit();
        }
        yield return new WaitForSeconds(1.3f);

        MayShoot_Burst = false;
        lineRenderer.enabled = false;
        StopCoroutine(Shoot_Laser());
    }

    //Fires 2 rockets in the player's direction
    public IEnumerator Shoot_Rockets()
    {
        MayShoot_Rocket = true;
        if (MayShoot_Rocket)
        {
            Instantiate(Rocket, barrelAndRocket[2].transform.position, transform.rotation);
            Instantiate(Rocket, barrelAndRocket[3].transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(1.7f);
        MayShoot_Rocket = false;
        StopCoroutine(Shoot_Rockets());
    }

    public IEnumerator Die()
    {
        if (i < 7 && Dead)
        {
            var Explosion = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().ExplosionAnim;
            Explosion.transform.localScale = new Vector3(3, 3, 1);
            Instantiate(Explosion, new Vector3(transform.position.x + Random.Range(-4, 5), transform.position.y + Random.Range(-7, 3), transform.position.z), Quaternion.identity);
        }
        else
            GetComponent<SpriteRenderer>().enabled = false;

        if (i <= 15 && Dead)
        {
            pos.x = Random.Range(-15, 15);
            pos.y = Random.Range(-10, 4);
            Instantiate(Material, pos, Quaternion.identity);
            i++;
            yield return new WaitForSeconds(.2f);
            StartCoroutine(Die());
        }
    }
}
