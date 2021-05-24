using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    // Cria uma instancia única dessa classe para ser usada em outros scripts(Singleton), usada normalmente em Managers
    public static SlowDown instance;

    // Tempo em que se fica no slowDown 
    public float slowDownTime = 1f;

    // Cronometro
    private float timer;
    
    // Controla que o slowDown pode ou não ser ativado
    private bool canSlowDown;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSlowDown)
        {
            timer += Time.unscaledDeltaTime;
            Time.timeScale += Time.unscaledDeltaTime / slowDownTime;
            if (timer >= slowDownTime)
            {
                canSlowDown = false;
                Time.timeScale = 1;
            }
        }

    }

    // Controla o SlowDown
    public void SetSlowDown() 
    {
        Time.timeScale = 0;
        canSlowDown = true;
        timer = 0; 
    }
}















