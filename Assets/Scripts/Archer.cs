using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;


    [Header("Use Bullet")]
    public GameObject bulletPrelab;
    public float fireRate = 1f; //Tốc độ bắn
    private float fireCountdown = 0f;

    [Header("User Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    
    public Transform firePoint; 

    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            
            return;
        }
            
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

        
    }
    void Laser()
    {
        //Laser gây dame và làm chậm mục tiêu
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);


        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void Shoot()
    {
        GameObject arrowGO = (GameObject)Instantiate(bulletPrelab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();

        if (arrow != null)
        {
            arrow.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

}
