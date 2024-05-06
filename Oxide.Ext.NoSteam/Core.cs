using HarmonyLib;
using Network;
using Oxide.Ext.NoSteam.Patches;
using Oxide.Ext.NoSteam.Utils;
using Oxide.Ext.NoSteam.Utils.Steam;
using Steamworks;
using System.Collections.Generic;
using System.Reflection;
using static ServerUsers;


namespace Oxide.Ext.NoSteam
{
    public static class Core
    {
        static Core()
        {
            StatusPlayers = new Dictionary<ulong, BeginAuthResult>();
        }

        internal static Harmony HarmonyInstance;

        internal static readonly Dictionary<ulong, BeginAuthResult> StatusPlayers;

        internal static void Start()
        {
            DoPatch();
            SteamPatch.PatchSteamBeginPlayer();
            SteamPatch.PatchSteamServerTags();
        }

        private static void DoPatch()
        {
            HarmonyInstance = new Harmony("com.github.rust.exp");
            Harmony.DEBUG = false;
            HarmonyInstance.PatchAll();
        }

        internal static int CountSteamPlayer()
        {
            int count = 0;

            foreach (var player in BasePlayer.activePlayerList)
            {
                if (CheckIsSteamConnection(player.userID) == true)
                {
                    count++;
                }
            }
            return count;
        }

        internal static bool CheckIsSteamConnection(Connection connection)
        {
            if (connection == null)
                return false;

            var steamTicket = new SteamTicket(connection);

            if (steamTicket.clientVersion == SteamTicket.ClientVersion.Steam)
            {
                return true;
            }

            return false;
        }

        internal static void CheckServerParameters()
        {
            if (ConVar.Server.encryption > 0)
            {
                Logger.Print("'server.encryption' should was been '0'");
            }

            if (ConVar.Server.secure == false)
            {
                Logger.Print("'server.secure' should was been '1'");
            }
        }

        internal static bool CheckIsSteamConnection(ulong userid)
        {
            if (StatusPlayers.ContainsKey(userid) == false)
                return false;

            return StatusPlayers[userid] == 0;
        }

        internal static bool CheckIsValidConnection(ulong userid, SteamTicket steamTicket)
        {
            if (StatusPlayers.ContainsKey(userid) == false)
            {
                if (NoSteamExtension.DEBUG)
                    Logger.Print("CheckIsValidConnection[1] | StatusPlayers not contains: " + userid);
                return false;
            }

            bool authResult = false;
            switch (StatusPlayers[userid])
            {
                case BeginAuthResult.OK:
                case BeginAuthResult.GameMismatch:
                    authResult = true;
                    break;
            }

            if (authResult == false)
            {
                if (NoSteamExtension.DEBUG)
                    Logger.Print("CheckIsValidConnection[2] | AuthResult false: " + userid + " Status: " + StatusPlayers[userid].ToString());
                return false;
            }

            if (steamTicket.Ticket.SteamID != userid)
            {
                if (NoSteamExtension.DEBUG)
                    Logger.Print("CheckIsValidConnection[3] | steamTicket.SteamID != userid: " + userid);
                return false;
            }

            return true;
        }
    }
}