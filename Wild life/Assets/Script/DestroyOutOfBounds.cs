using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35.0f;
    private float minBound = -10.0f;
    // Update is called once per frame
    void Update()
    {
        /* && = And es que es que x o y se tienen que cumplir a la vez
         * Ej: Si se cumple la variable 1 y la variable 2 sucede esto esto
         */
        /* || (Alt + 124 del teclado numerico) es que se tiene que cumplir x o y o los 2
         * Ej: Si se cumple la variable 1 o la variable 2 sucede esto
         */
        /*El || y el && funcionan estableciendo los variables antes y comprandolas como se puede ver en la siguiente linea
         * de codigo y asi nos ahorramos 2 "if"
         * ejemplo:       
        bool var1 = (this.transform.position.z > topBound);
        bool var2 = (this.transform.position.z < minBound);

        if ( var1 || var2)
        {
            Destroy(this.gameObject);
        }
         */
        bool var1 = (this.transform.position.z > topBound);
        bool var2 = (this.transform.position.z < minBound);

        if (var1)
        {
            Destroy(this.gameObject);
        }

        if (var2)
        {
            Destroy(this.gameObject);
            Debug.Log("Perdiste");
            Time.timeScale = 0;
          
        }
    }
}
