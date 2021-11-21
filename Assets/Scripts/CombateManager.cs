using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum CombatStatus
{
    ESPERANDO_JUGADOR,
    JUGADOR_ACCION,
    ENEMIGO_ACCION,
    VERIFICANDO_VICTORIA,
    VERIFICANDO_DERROTA,
    SIGUIENTE_TURNO

}

public class CombateManager : MonoBehaviour
{
    public Enemigos enemigos;
    public Guerrero guerreros;
    public int guerreroIndex;
    public int enemigoIndex;
    public bool isCombatActive;
    public CombatStatus combatStatus;
    private Skill currentFighterAction;
    public GestionPaneles gestionPaneles;
    public ControlJugador player;
    public LogPanel informacionCombate;
    public GestionPaneles paneles;
    public RecompensaCombate recompensa;



    public PlayerEnemigo enemigo;
    public Characters characters;
    

    public void InicializandoCombate()
    {  
        this.informacionCombate.write("Inicio Combate.");
        this.combatStatus = CombatStatus.SIGUIENTE_TURNO;
        this.guerreroIndex = 0;
        this.enemigoIndex = 1;
        this.isCombatActive = true;

        StartCoroutine(CombatLoop());
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
                    informacionCombate.write($"{this.guerreros.idName} usa {currentFighterAction.nombreHabilidad.text}.");
                    yield return new WaitForSeconds(currentFighterAction.duracionAnimacion);
                    this.combatStatus = CombatStatus.VERIFICANDO_VICTORIA;
                    currentFighterAction.Run();
                    break;
                case CombatStatus.VERIFICANDO_VICTORIA:
                        if (enemigos.isAlive == false)
                        {
                            this.isCombatActive = false;
                             paneles.victoriaEncendido = true;
                             characters.SubiendoExperiencia();
                             characters.SubiendoMonedas();
                        Destroy(enemigo.prefab);
                            recompensa.GenerandoRecompensas();

                        informacionCombate.write("Has ganado!");
                        }
                        else
                        {
                        this.enemigoIndex = this.enemigoIndex - 1;
                        this.guerreroIndex = this.guerreroIndex + 1;
                        this.combatStatus = CombatStatus.ENEMIGO_ACCION;
                           
                        }
                    yield return null;
                    break;
                case CombatStatus.ENEMIGO_ACCION:
                    yield return new WaitForSeconds(3f);
                    informacionCombate.write($"{enemigos.IDEnemy} usa {currentFighterAction.nombreHabilidad.text}.");
                    yield return new WaitForSeconds(currentFighterAction.duracionAnimacion);
                    this.combatStatus = CombatStatus.VERIFICANDO_DERROTA;
                    currentFighterAction.RunEnemy();
                    break;
                case CombatStatus.VERIFICANDO_DERROTA:
                        if (guerreros.isAlive == false)
                        {
                            this.isCombatActive = false;
                            informacionCombate.write("Has Perdido!");
                        }
                        else
                        {
                            this.guerreroIndex = this.guerreroIndex - 1;
                            this.enemigoIndex = this.enemigoIndex + 1;
                            this.combatStatus = CombatStatus.SIGUIENTE_TURNO;
                        }
                    yield return null;
                    break;
                case CombatStatus.SIGUIENTE_TURNO:
                    yield return new WaitForSeconds(2f);
                    if (this.guerreroIndex == 0)
                    {
                        informacionCombate.write($"{guerreros.idName} es su turno.");
                        this.combatStatus = CombatStatus.ESPERANDO_JUGADOR;
                        guerreros.IniciarTurno();
                        
                    }
                    else if(this.enemigoIndex == 0)
                    {
                        informacionCombate.write($"{enemigos.IDEnemy} es su turno.");
                        this.combatStatus = CombatStatus.ENEMIGO_ACCION;
                        enemigos.IniciarTurno();
                        
                    }
                    break;

            }
            

        }
    }
    public Guerrero GetOpposingGuerrero()
    {
        if (this.guerreroIndex == 0)
        {
            return this.guerreros;
        }
        else
        {
            return this.guerreros;
        }
    }
  
    public Enemigos GetOpposingEnemy()
    {
        if(this.enemigoIndex == 0)
        {
            return this.enemigos;
        }
        else
        {
            return this.enemigos;
        }
    }
    public void OnFighterSkill(Skill skill)
    {
        this.currentFighterAction = skill;
        this.combatStatus = CombatStatus.JUGADOR_ACCION;
    }
}


