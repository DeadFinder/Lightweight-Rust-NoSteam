using CompanionServer;
using HarmonyLib;
using System.Threading.Tasks;
using Listener = CompanionServer.Listener;
using Pair = CompanionServer.Util;
using Fleck;
using static SkinnedMultiMesh;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System;
namespace Oxide.Ext.NoSteam.Patches
{
    internal static class OtherPatch
    {
        [HarmonyPatch(typeof(Pair), nameof(Pair.SendPairNotification))]
        internal static class CompanionSendPairNotification
        {
            [HarmonyPrefix]
            public static bool HarmonyPrefix(BasePlayer player, ref Task<NotificationSendResult> __result)
            {
                if (!Core.CheckIsSteamConnection(player.userID))
                {
                    __result = Task.FromResult(NotificationSendResult.Disabled);
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Pair), nameof(Pair.SendSignedInNotification))]
        internal static class CompanionSendSignedInNotification
        {
            [HarmonyPrefix]
            public static bool HarmonyPrefix(BasePlayer player)
            {
                if (!Core.CheckIsSteamConnection(player.userID))
                    return false;
                return true;
            }
        }
    }
}
