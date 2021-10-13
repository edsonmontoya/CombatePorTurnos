using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [Header("Habilidades")]
    public string nombreHabilidad;
    public float duracionAnimacion;
    public bool selfInflicted;

    public GameObject effectPrfb;

    protected Guerrero emitter;
    protected Guerrero receiver;

    private void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
        Destroy(go, this.duracionAnimacion);
    }
    public void Run()
    {
        if (this.selfInflicted)
        {
            this.receiver = this.emitter;
        }
        this.Animate();
        this.OnRun();
    }
    public void SetEmitterAndReceiver(Guerrero _emitter, Guerrero _receiver)
    {
        this.emitter = _emitter;
        this.receiver = _receiver;
    }
    protected abstract void OnRun();
}