using UnityEngine;

public interface IDanable  //es una interfaz no hereda nada de la clase padre y no se implementa (es para ahorrar codigo si quiero que caja se destruya llamo esta interfaz e implemento la funcion)
{
    void RecibirDAnio(int cantidad);
}
