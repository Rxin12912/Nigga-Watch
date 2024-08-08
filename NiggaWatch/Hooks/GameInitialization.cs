using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Watch.Hooks
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "Awake")]
    public class GameInitialization : MonoBehaviour
    {
        private static void Prefix()
        {
            Plugin.Instance.OnGameInitialized();
        }
    }
}
