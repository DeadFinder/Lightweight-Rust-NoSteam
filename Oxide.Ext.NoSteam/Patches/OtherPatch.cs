using CompanionServer;
using HarmonyLib;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppServer = CompanionServer.Server;
using Pair = CompanionServer.Util;
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

        //Server can get deranked because of enabled Rust+, but not with code below!
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

        [HarmonyPatch(typeof(Pair), nameof(Pair.SendPairNotification))]
        internal static class CompanionPairToServerPatch
        {
            [HarmonyPrefix]
            public static void HarmonyPrefix(string type, BasePlayer player, string title, string message, Dictionary<string, string> data, ref Task<NotificationSendResult> __result)
            {
                //check is steam player xdddd
                if (!Core.CheckIsSteamConnection(player.userID))
                {
                    __result = Task.FromResult(NotificationSendResult.Disabled);
                }
            }
        }
    }
}
