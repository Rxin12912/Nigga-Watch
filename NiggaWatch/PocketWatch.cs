using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net;
using System.Collections;
using UnityEngine;
using BepInEx;
using HarmonyLib;

namespace Watch
{
    public class PocketWatch : MonoBehaviour
    {
        public static bool Rendering;

        public static int Tab;

        public static float PageCooldown;


        public void OnGUI()
        {
            GUI.Label(new Rect(10f, 10f, 500f, 500f), "Nigga Watch");
        }

        public void Update()
        {
            if (!Rendering)
            {
                VRRig LocalPlayer = GorillaTagger.Instance.offlineVRRig;
                GorillaHuntComputer Computer = LocalPlayer.huntComputer.GetComponent<GorillaHuntComputer>();
                LocalPlayer.EnableHuntWatch(true);
                GameObject.Destroy(Computer.material);
                GameObject.Destroy(Computer.leftHand);
                GameObject.Destroy(Computer.rightHand);
                GameObject.Destroy(Computer.face);
                GameObject.Destroy(Computer.hat);
                GameObject.Destroy(Computer.badge);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x >= .5f && Time.time >= PageCooldown + .2f)
            {
                PageCooldown = Time.time;
                Tab++;
            }
            else if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x <= .5f && Time.time >= PageCooldown + .2f)
            {
                PageCooldown = Time.time;
                Tab--;
            }
        }
    }
}
