using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    private PlayerInput _playerInput;

    public ammoBar AmmoBar;
   
    // init Ammo variables 
    public int maxAmmo = 10;
    public int currentAmmo;
    //public float reloadTimer = 1f;
    public Text ammoText; 

    public Transform rayOrigin;

    
    [SerializeField]private bool firePressed;
    [SerializeField]private bool fireReleased;
    [Header("Gun Stats")]
    [SerializeField] private int pistolDamage;
    private float _nextFire = 0f;
    public float fireRate = 0.2f;
    
    [Header("Gun Sounds/VFX ")] 
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource emptyGun;
    [SerializeField] private AudioSource reloadShotgun;
    [SerializeField] private GameObject hitDecal;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private float muzzleDecayTime;

    private void Awake()
    {

        _playerInput = new PlayerInput();

        pistolDamage = 20;
        
        
        _playerInput.PlayerMain.Shoot.performed += _ => Shooting();

        Debug.Log(_playerInput.PlayerMain.Shoot.phase);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        AmmoBar.setMaxAmmo(maxAmmo);
        

    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = currentAmmo.ToString();

 
    }
    
    private void Shooting()
    {
        if (Time.time > _nextFire && currentAmmo >= 1)
        {
            _nextFire = Time.time + fireRate;

           
            currentAmmo--;
            AmmoBar.setAmmo(currentAmmo);
  
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, Mathf.Infinity))
            {
                
                StartCoroutine(MuzzleFlash());
                shootSound.Play();
                GameObject impactGO = Instantiate(hitDecal, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO,2f);
                Debug.DrawRay(rayOrigin.position, rayOrigin.forward * 1000, Color.red);

                AiBehaviour target = hit.collider.GetComponent<AiBehaviour>();
                if (target != null)
                {
                    target.TakeDamage(pistolDamage);
                }
            }
            
        }
        
    }

    private IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(muzzleDecayTime);
        muzzleFlash.SetActive(false);
    }
}
