using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponDataSO : ScriptableObject
{
    public GameObject prefab;
 
    [Header("Info")]
    public string weaponName;
    public string price;

    [Header("Shooting")]
    public int damage;
    public int maxDistance;
    public int fireRate;

    [Header("Reloading")]
    public int currentAmmo;
    public int Ammo;
    public int magazineSize;
    public int reloadTime;
    public bool isReloading;
}
