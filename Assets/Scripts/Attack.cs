using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Referência o audioPlayer
    public AudioPlayer audioPlayer;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage enemy = collision.GetComponent<Damage>();
        
        // Caso o objeto não seja nulo a função TakeDamage será chamada
        if (enemy!= null) 
        {
            enemy.TakeDamage(damage);
            audioPlayer.PlaySound(hitSound);

            if (slowDown)
            {
                SlowDown.instance.SetSlowDown(); 
            }

            ComboManager.instance.SetCombo();
        }
        
    }




}





















