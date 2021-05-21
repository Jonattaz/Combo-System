using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Valor do dano de ataque
    private int damage;
    // Se o ataque terá ou não slow down
    private bool slowDown;
    // Som que o ataque faz quando atingi alguma coisa
    private AudioClip hitSound;

    // Método que defini os valores de cada ataque
    public void SetAttack(Hit hit)
    {
        damage = hit.damage;
        slowDown = hit.slowDown;
        hitSound = hit.hitSound;
    }
    
}
