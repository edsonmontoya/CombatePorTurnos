using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum CombatStatus
{
    ESPERANDO_JUGADOR,
    JUGADOR_ACCION,
    VERIFICANDO_VICTORIA,
    SIGUIENTE_TURNO

}

public class CombateManager : MonoBehaviour
{

    public Guerrero[] guerreros;
    public int guerreroIndex;
    public bool isCombatActive;
    private CombatStatus combatStatus;
    private Skill currentFighterAction;
    public GestionPaneles gestionPaneles;
    public ControlJugador player;
    public LogPanel informacionCombate;
    

    void Start()
    {
        informacionCombate.write("Inicio Combate.");
        foreach (var fgtr in this.guerreros)
        {
            fgtr.combateManager = this;
        }
        this.combatStatus = CombatStatus.SIGUIENTE_TURNO;
        this.guerreroIndex = -1;
        this.isCombatActive = true;
        StartCoroutine(this.CombatLoop());

    }
    IEnumerator CombatLoop()
    {
        while (this.isCombatActive)
        {

           
            switch (this.combatStatus)
            {
                case CombatStatus.ESPERANDO_JUGADOR:
                    yield return null;
                    break;
                case CombatStatus.JUGADOR_ACCION:
                    informacionCombate.write($"{this.guerreros[this.guerreroIndex].idName} usa {currentFighterAction.nombreHabilidad}.");
                    yield return new WaitForSeconds(currentFighterAction.duracionAnimacion);
                    this.combatStatus = CombatStatus.VERIFICANDO_VICTORIA;
                    currentFighterAction.Run();
                    break;
                case CombatStatus.VERIFICANDO_VICTORIA:
                    foreach (var fgtr in this.guerreros)
                    {
                        if (fgtr.isAlive == false)
                        {
                            this.isCombatActive = false;
                            informacionCombate.write("Has ganado!");
                        }
                        else
                        {
                            this.combatStatus = CombatStatus.SIGUIENTE_TURNO;
                        }

                    }
                    yield return null;
                    break;
                case CombatStatus.SIGUIENTE_TURNO:
                    yield return new WaitForSeconds(1f);
                    this.guerreroIndex = (this.guerreroIndex + 1) % this.guerreros.Length;
                    var currerntTurn = this.guerreros[this.guerreroIndex];
                    informacionCombate.write($"{currerntTurn.idName} es su turno.");
                    currerntTurn.IniciarTurno();

                    this.combatStatus = CombatStatus.ESPERANDO_JUGADOR;
                    break;

            }
            

        }
    }
    public Guerrero GetOpposingGuerrero()
    {
        if (this.guerreroIndex == 0)
        {
            return this.guerreros[1];
        }
        else
        {
            return this.guerreros[0];
        }
    }
    /*
    public void OnFighterSkill(Skill skill)
    {
        this.currentFighterAction = skill;
        this.combatStatus = CombatStatus.JUGADOR_ACCION;
    }*/
}