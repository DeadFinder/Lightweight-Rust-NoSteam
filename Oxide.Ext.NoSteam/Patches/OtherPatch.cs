using HarmonyLib;
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

        //Now i'm understand why i should disable rust+, my server get deranked xd
        //Also maybe i will add on connections check if player is pirate i will deny this connection
        [HarmonyPatch(typeof(AppServer), nameof(AppServer.Initialize))]
        private static class CompanionServerPatch
        {
            [HarmonyPrefix]
            public static bool Prefix()
            {
                ConVar.App.port = -1;
                return false;
            }
        }
    }
}
