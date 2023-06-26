using UnityEngine;
using UnityEngine.Events;
public class RocketGun : WeaponBase
{
    [SerializeField] private GameObject homingMissilePrefab;
    [SerializeField] private DecorRocket decorRocket;

    private int scrolInt;
    private int previousScrolInt;
    [SerializeField] private int MaxWeapon;

    [SerializeField] private bool canShoot = true;

    [SerializeField] private Animator animator;

    [SerializeField] private float offset;

    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource prepateSound;

    [SerializeField] private UnityEvent OnShot;
    [SerializeField] private UnityEvent OnSwitchToRocket;
    [SerializeField] private UnityEvent OnSwitchToHomingMissile;
    private Transform target;

    private void Start()
    {
        if (decorRocket.CurrentRocket == RocketType.Rocket)
        {
            animator.enabled = false;
            damage = 30;
            bulletPrefab.GetComponent<Rocket>().Damage = damage;
        }
        if (decorRocket.CurrentRocket == RocketType.HomingMissile)
        {
            damage = 15;
            homingMissilePrefab.GetComponent<HomingMissile>().Damage = damage;
        }
    }

    private void Update()
    {

        if (canShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }       

        if (decorRocket.CurrentRocket == RocketType.HomingMissile)
        {
            animator.enabled = true;
        }

        if (decorRocket.CurrentRocket == RocketType.Rocket)
        {

        }

        if (scrolInt != previousScrolInt)
        {
            if (decorRocket.CurrentRocket == RocketType.Rocket)
            {
                animator.enabled = true;
                canShoot = false;
                animator.SetTrigger("SwitchToHomingMissile");
            }

            else if (decorRocket.CurrentRocket == RocketType.HomingMissile)
            {
                animator.enabled = true;
                canShoot = false;
                animator.SetTrigger("SwitchToRocket");
            }
            previousScrolInt = scrolInt;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            scrolInt += 1;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            scrolInt -= 1;
        }
    }
    public override void Shoot()
    {
        shootSound.Play();
        animator.enabled = true;
        animator.SetTrigger("Hide");
        OnShot.Invoke();
        canShoot = false;
        Debug.Log(scrolInt);
        if (decorRocket.CurrentRocket == RocketType.Rocket)
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (decorRocket.CurrentRocket == RocketType.HomingMissile)
        {
           GameObject homingMissile = Instantiate(homingMissilePrefab, firePoint.position, firePoint.rotation);
           homingMissile.GetComponent<HomingMissile>().SetTarget(target);
        }
    }

    public void ActiveShoot() => canShoot = true;

    //public void Switch()
    //{
    //    OnSwitch.Invoke();
    //    Debug.Log("switch");
    //}

    public void SwitchToRocket() => OnSwitchToRocket.Invoke();
    public void SwitchToHomingMissile() => OnSwitchToHomingMissile.Invoke();

    public void ActiveAnimator() => animator.enabled = true;
    public void DeactiveAnimator() => animator.enabled = false;

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    public void PlayPrepareSound() => prepateSound.Play();
}
