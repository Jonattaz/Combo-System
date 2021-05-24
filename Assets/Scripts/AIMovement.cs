using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Velocidade de movimento
    public float speed = -5;

    // Intervalo de tempo do qual o método Flip é chamado
    private float flipTime = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Método, intervalo inicial com quando a função será chamada e tempo do intervalo de repetição 
        InvokeRepeating("Flip", flipTime, flipTime); 
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    // Responsável pela mudança de lado do personagem na tela
    void Flip()
    {
        speed *= -1;
        // Armazena o vetor
        Vector3 scale = transform.localScale;
        // Usando a escala armazenada, o valor de X deve ser alterado
        scale.x *= -1;
        transform.localScale = scale;
    }

}
