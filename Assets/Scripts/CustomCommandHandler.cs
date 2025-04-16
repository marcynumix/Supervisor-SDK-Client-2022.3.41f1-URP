using System;
using UnityEngine;

namespace Numix.Supervisor
{
    public class CustomCommandHandler : MonoBehaviour
    {

        public void HandleDebugCommand(string debugCommand)
        {
            if (debugCommand.StartsWith("COMMAND"))
            {
                //Example: COMMAND_1_2_3
                //Arguments: 1, 2, 3
                string[] args = debugCommand.Split('_');
                //remove the first element
                Array.Resize(ref args, args.Length - 1);

                //Check size
                if (args.Length < 3)
                {
                    Debug.LogError("Not enough arguments");
                    return;
                }
            }
        }
    }
}