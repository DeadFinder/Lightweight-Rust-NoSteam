﻿using Harmony;
using System;
using AppServer = CompanionServer.Server;

namespace Oxide.Ext.NoSteam.Patches
{
    internal static class OtherPatch
    {
        [HarmonyPatch(typeof(DeveloperList), nameof(DeveloperList.Contains), new Type[] { typeof(string) })]
        private class ConnectionAuthPatch
        {
            [HarmonyPrefix]
            public static bool Prefix(string steamid, ref bool __result)
            {
                __result = false;

                return false;
            }
        }

        //Totally not understand why i'm should disable Rust+ on server, maybe i will get banned without that xd.
        /*[HarmonyPatch(typeof(AppServer), nameof(AppServer.Initialize))]
        private static class CompanionServerPatch
        {
            [HarmonyPrefix]
            public static bool Prefix()
            {
                ConVar.App.port = -1;
                return false;
            }
        }*/
    }
}
