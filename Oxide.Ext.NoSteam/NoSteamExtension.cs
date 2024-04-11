// Author:  Kaidoz
// Filename: NoSteamExtension.cs
// Last update: 2019.10.06 20:41

using Oxide.Core;
using Oxide.Core.Extensions;
using Oxide.Ext.NoSteam.Utils;
using Oxide.Plugins;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using VLB;
using static ConsoleSystem;

namespace Oxide.Ext.NoSteam
{
    public class NoSteamExtension : Extension
    {
        private bool _loaded;

        public static bool DEBUG = false;

        public NoSteamExtension(ExtensionManager manager) : base(manager)
        {
            Instance = this;
        }

        public override string Name => "NoSteam";

        public override VersionNumber Version => new VersionNumber(0, 0, 1);

        public override string Author => "Kaidoz&DeadFinder";

        public static NoSteamExtension Instance { get; private set; }

        public override void Load()
        {
            if (_loaded)
                return;

            _loaded = true;
            Loader.NoSteam.InitPlugin();
        }

        public override void OnModLoad()
        {
            Load();
        }
    }
}