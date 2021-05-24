using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Responsável pela velocidade de movimentação do jogador
    public float speed = 5;

    // Controla se o personagem está virado para esquerda ou direita
    private bool facingRight = true;

    // Animator do personagem
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Captura o valor do Input no eixo da horizontal
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * 5 * Time.deltaTime);        // Vector2.right é um atalho para Vector2(1,0)
       
        if (facingRight && h < 0)
        {
            Flip();
        }else if (!facingRight && h > 0)
        {
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(h));

    }


    // Responsável pela mudança de lado do personagem na tela
    void Flip()
    {
        facingRight = !facingRight;
        // Armazena o vetor
        Vector3 scale = transform.localScale;

        // Usando a escala armazenada, o valor de X deve ser alterado
        scale.x *= -1;
        transform.localScale = scale;
    }

}





