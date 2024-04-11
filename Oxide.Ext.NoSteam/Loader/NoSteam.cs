//using ConVar;
using Oxide.Core;
using Oxide.Core.Logging;
using Oxide.Core.Plugins;
using System;

namespace Oxide.Ext.NoSteam.Loader
{
    internal class NoSteam : CSPlugin
    {
        internal NoSteam(NoSteamExtension extension)
        {
            Name = extension.Name;
            Title = extension.Name;
            Author = extension.Author;
            Version = extension.Version;
            HasConfig = false;
        }

        internal static void InitPlugin()
        {
            Output("[NoSteam Fork] Author: Kaidoz&DeadFinder" +
                "\n Specially for charaling-plugins.ru" +
                "\n Github: ");

            try
            {
                Core.Start();
            }
            catch (Exception ex)
            {
                Output("Error patching: " + ex);
            }
        }

        internal static void Output(string text)
        {
            Interface.Oxide.RootLogger.Write(LogType.Info, text);
        }
    }
}