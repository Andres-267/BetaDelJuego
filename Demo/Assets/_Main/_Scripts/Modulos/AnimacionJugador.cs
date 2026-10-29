using UnityEngine;

public class AnimacionJugador

{
    private readonly Animator animator;
    private static readonly int Caminando = Animator.StringToHash("Caminando");
    private static readonly int EnSuelo = Animator.StringToHash("EnSuelo");

    public AnimacionJugador(Animator _animator)
    {
        animator = _animator;
    }

    public void Actualizar(bool caminando, bool enSuelo)
    {
        if (animator == null) return;
        animator.SetBool(Caminando, caminando);
        animator.SetBool(EnSuelo, enSuelo);
    }
}
