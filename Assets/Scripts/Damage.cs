using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    // Dar feedback de que está tomando dano
    
    // Referência ao sprite renderer
    private SpriteRenderer spriteRenderer;

    // Cor ao levar dano
    public Color damageColor;

    // Referência ao DamageCanvas
    public GameObject damageCanvas;

    // Referência a posição da qual o DamageCanvas deve aparecer
    public Transform DamageTextPos;


    // Cor normal
    private Color defaultColor;

    // Controla o tempo de dano
    public float damageTime = 0.1f;


    private void Awake()

    {   // Referência ao sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Default color é igual a cor original do sprite
        defaultColor = spriteRenderer.color;

    }


    // Esse método é chamado quando o Gameobject(Enemy) sofre dano
    public void TakeDamage(int damage)
   {
        // Muda a cor do sprite quando leva dano
        spriteRenderer.color = damageColor;

        Invoke("ReleaseDamage", damageTime);
        GameObject newDamageText = Instantiate(damageCanvas, DamageTextPos.position, Quaternion.identity);
        newDamageText.GetComponentInChildren<Text>().text = damage.ToString();
        Destroy(newDamageText, 1);
    }

    // Quando terminar de causar o dano esse método é chamado
    void ReleaseDamage() 
    {
        spriteRenderer.color = defaultColor;
    
    
    }










}















