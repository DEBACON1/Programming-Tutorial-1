using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static Controles controles;
    

    public static void Init(Player myPlayer)
    {
        controles = new Controles();

        

        controles.Game.Movement.performed += ctx =>
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };

        controles.Game.Jump.performed += cty =>
        {
            myPlayer.Jump();
        };

        controles.Game.Spawn.performed += ctz =>
        {
            myPlayer.SpawnObject();
        };

        controles.Game.Destroy.performed += cta =>
        {
            myPlayer.EndObject();
        };


        controles.Permanent.Enable();
    }

    public static void Gamemode()
    {
        controles.Game.Enable();
        controles.UI.Disable();
    }

    public static void UImode()
    {
        controles.Game.Disable();
        controles.UI.Enable();
    }
}
