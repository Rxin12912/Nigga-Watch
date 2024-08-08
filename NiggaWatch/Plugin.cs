using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using BepInEx;
using HarmonyLib;

namespace Watch
{
    public struct Metadata
    {
        public const string GUID = "com.rxin.niggawatch";
        public const string Name = "NiggaWatch";
        public const string Version = "1.0.0";
    }

    [BepInPlugin(Metadata.GUID, Metadata.Name, Metadata.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        Plugin()
        {
            base.Logger.LogInfo("Loading Plugin...");
            Instance = this;
            var harmony = new Harmony(Metadata.GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnGameInitialized()
        {
            Debug.Log(" [NiggaWatch] Scene Created, Loading Assets...");
            GameObject Object = new GameObject("NiggaWatch");
            Object.AddComponent<PocketWatch>();
        }
    }
}
