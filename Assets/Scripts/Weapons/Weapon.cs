using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Items/ Weapons")]
public class Weapon : Item
{
    public GameObject model;
    public bool isunarmed;

    [Header("One Handed Attack")]
    public string Light_Attack1;
    public string Light_Attack2;
    public string Light_Attack3;
    public string Light_Attack4;

    public string Heavy_Attack1;
    public string Heavy_Attack2; 
    public string Heavy_Attack3;
    public string Heavy_Attack4;

}
