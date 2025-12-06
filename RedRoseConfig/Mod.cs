using RedRose.Configuration;
using RedRose.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using CriFs.V2.Hook.Interfaces;
using P5R.CostumeFramework.Interfaces;
using P5R.CostumeFramework;

namespace RedRose
{
    public class Mod : ModBase
    {
        private readonly IModLoader _modLoader;
        private readonly IReloadedHooks? _hooks;
        private readonly ILogger _logger;
        private readonly IMod _owner;
        private Config _configuration;
        private readonly IModConfig _modConfig;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            // grab modDir and modId
            string modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);
            string modId = _modConfig.ModId;

            var criFsCtl = _modLoader.GetController<ICriFsRedirectorApi>();
            var costumeCtl = _modLoader.GetController<ICostumeApi>();

            if (criFsCtl == null || !criFsCtl.TryGetTarget(out var criFsApi)) { _logger.WriteLine("CRI FS Emu missing → config binds broken.", System.Drawing.Color.Red); return; }
            if (costumeCtl == null || !costumeCtl.TryGetTarget(out var costumeApi)) { _logger.WriteLine("Costume API missing → Costumes broken.", System.Drawing.Color.Red); return; }

            // Bustups
            {
                switch (_configuration.Bustup)
                {
                    case Config.Bustupenum.Legacy:
                        BindAllFilesIn(
                            Path.Combine("OptionalModFiles", "Bustup", "Legacy"),
                            modDir, criFsApi, modId
                        );
                    break;

                    case Config.Bustupenum.L7M3:
                        BindAllFilesIn(
                            Path.Combine("OptionalModFiles", "Bustup", "L7M3", "Universal"),
                            modDir, criFsApi, modId
                        );

                        var outfit = _configuration.PTOutfit;

                    if (outfit == Config.PTenum.RedandWhite ||
                        outfit == Config.PTenum.PureWhite ||
                        outfit == Config.PTenum.Off)
                    {
                        string selected = outfit switch
                        {
                            Config.PTenum.RedandWhite => "RedWhitePT",
                            Config.PTenum.PureWhite => "WhitePT",
                            _ => "DefaultPT"
                        };

                        BindAllFilesIn(
                            Path.Combine("OptionalModFiles", "Bustup", "L7M3", selected),
                            modDir, criFsApi, modId
                        );
                    }
                    break;
                }
            }

            // Winter Casual
            if (_configuration.WinterCasual == Config.WinterCasualenum.Yukari ||
                _configuration.WinterCasual == Config.WinterCasualenum.Yukiko ||
                _configuration.WinterCasual == Config.WinterCasualenum.BlueDress)
            {
                string selected = _configuration.WinterCasual switch
                {
                    Config.WinterCasualenum.Yukari => "Yukari",
                    Config.WinterCasualenum.Yukiko => "Yukiko",
                    Config.WinterCasualenum.BlueDress => "BlueDress"
                };

                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "WinterCasual", selected),
                    modDir, criFsApi, modId
                );
            }

            // Summer Casual
            if (_configuration.FuukaDress == Config.FuukaDressenum.FuukaWhiteRibbon ||
                _configuration.FuukaDress == Config.FuukaDressenum.FuukaBlueRibbon ||
                _configuration.FuukaDress == Config.FuukaDressenum.Mitsuru ||
                _configuration.FuukaDress == Config.FuukaDressenum.Eiko)
            {
                string selected = _configuration.FuukaDress switch
                {
                    Config.FuukaDressenum.FuukaWhiteRibbon => "FuukaWhiteRibbon",
                    Config.FuukaDressenum.FuukaBlueRibbon => "FuukaBlueRibbon",
                    Config.FuukaDressenum.Mitsuru => "Mitsuru",
                    Config.FuukaDressenum.Eiko => "Eiko"
                };

                BindAllFilesIn(
                        Path.Combine("OptionalModFiles", "SummerCasual", selected),
                        modDir, criFsApi, modId
                     );
            }

             // Midwinter Uniform
            if (_configuration.MidwinterUniform == Config.MidwinterUniformenum.Rise ||
                _configuration.MidwinterUniform == Config.MidwinterUniformenum.NoGlovesNoScarf ||
                _configuration.MidwinterUniform == Config.MidwinterUniformenum.FurCoat)
            {
                string selected = _configuration.MidwinterUniform switch
                {
                    Config.MidwinterUniformenum.NoGlovesNoScarf => "NoGlovesNoScarf",
                    Config.MidwinterUniformenum.Rise => "Rise",
                    Config.MidwinterUniformenum.FurCoat => "FurCoat"
                };

                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "MidwinterUniform", selected),
                    modDir, criFsApi, modId
                );
            }

            // Midwinter Casual
            if (_configuration.MidwinterCasual == Config.MidwinterCasualenum.Rise ||
                _configuration.MidwinterCasual == Config.MidwinterCasualenum.FurCoat)
            {
                string selected =
                _configuration.MidwinterCasual == Config.MidwinterCasualenum.Rise ? "Rise" : "FurCoat";

                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "MidwinterCasual", selected),
                    modDir, criFsApi, modId
                );
            }

            // Summer Uniform
            if (_configuration.SummerUniform == Config.SummerUniformenum.WhiteShirt ||
                _configuration.SummerUniform == Config.SummerUniformenum.Kotomo)
            {
                string selected =
                _configuration.SummerUniform == Config.SummerUniformenum.WhiteShirt ? "WhiteShirt" : "Kortomo";

                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "SummerUniform", selected),
                    modDir, criFsApi, modId
                );
            }

            // Tracksuit 
            if (_configuration.Tracksuit == Config.Tracksuitenum.BlackTracksuit ||
                _configuration.Tracksuit == Config.Tracksuitenum.ConceptArtTracksuit ||
                _configuration.Tracksuit == Config.Tracksuitenum.Tamayo)
            {
                string selected = _configuration.Tracksuit switch
                {
                    Config.Tracksuitenum.BlackTracksuit => "Black",
                    Config.Tracksuitenum.ConceptArtTracksuit => "ConceptArt",
                    Config.Tracksuitenum.Tamayo => "Tamayo"
                };

                BindAllFilesIn(
                        Path.Combine("OptionalModFiles", "Workout", selected),
                        modDir, criFsApi, modId
                     );
            }

            // Winter Uniform
            if (_configuration.WinterUniform == Config.WinterUniformenum.Turtleneck)
            {
                BindAllFilesIn(
                        Path.Combine("OptionalModFiles", "WinterUniform", "Turtleneck"),
                        modDir, criFsApi, modId
                     );
            }

            // Lawson
            if (_configuration.Lawson)
            {
                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "Lawson"),
                    modDir, criFsApi, modId
                );
            }

            // Menu Art
            if (_configuration.Menu == Config.Menuenum.Neptune)
            {
                BindAllFilesIn(
                    Path.Combine("OptionalModFiles", "Menu", "Neptune"),
                    modDir, criFsApi, modId
                );
            }

            // NoAoAArt
            if (_configuration.NoAOA == Config.AOAenum.Default ||
                _configuration.NoAOA == Config.AOAenum.Smug)
            {
                string selected = (_configuration.NoAOA == Config.AOAenum.Default) ? "Default" : "Smug";

                BindAllFilesIn(
                        Path.Combine("OptionalModFiles", "NoAOA", selected),
                        modDir, criFsApi, modId
                    );
                
            }

            // PT Outfit
            if (_configuration.PTOutfit == Config.PTenum.PureWhite ||
                _configuration.PTOutfit == Config.PTenum.RedandWhite)
            {
                string selected = (_configuration.PTOutfit == Config.PTenum.PureWhite) ? "PureWhite" : "RedWhite";

                BindAllFilesIn(
                       Path.Combine("OptionalModFiles", "PTOutfit", selected, "Bind"),
                       modDir, criFsApi, modId
                   );

                var costumesFolder = Path.Combine(modDir, "OptionalModFiles", "PTOutfit", selected, "CF");
                costumeApi.AddCostumesFolder(modDir, costumesFolder);
            }
            
        }

        /// <summary>
        /// recursively enumerates all files under the given “subPath” (relative to the mod folder),
        /// and issues a single AddBind(...) per file. If the directory doesn’t exist, it silently does nothing.
        /// </summary>
        private static void BindAllFilesIn(
            string subPathRelativeToModDir,
            string modDir,
            ICriFsRedirectorApi criFsApi,
            string modId
        )
        {
            string absoluteFolder = Path.Combine(modDir, subPathRelativeToModDir);

            if (!Directory.Exists(absoluteFolder))
            {
                // _logger.WriteLine($"Folder not found: {absoluteFolder}", System.Drawing.Color.Yellow);
                return;
            }

            foreach (var filePath in Directory.EnumerateFiles(absoluteFolder, "*", SearchOption.AllDirectories))
            {
                string relativeCpkKey = Path.GetRelativePath(absoluteFolder, filePath).Replace(Path.DirectorySeparatorChar, '/');

                criFsApi.AddBind(
                    filePath,
                    relativeCpkKey,
                    modId
                );
            }
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}
