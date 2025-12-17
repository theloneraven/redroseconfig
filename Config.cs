using RedRose.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;
using CriFs.V2.Hook;
using CriFs.V2.Hook.Interfaces;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace RedRose.Configuration
{
    public class Config : Configurable<Config>
    {
        public enum Bustupenum
        {
            Default,
            Legacy,
            L7M3,
        }

        public enum FuukaDressenum
        {
            Off,
            FuukaWhiteRibbon,
            FuukaBlueRibbon,
            Mitsuru,
            Eiko,
        }

        public enum Tracksuitenum
        {
            Default,
            BlackTracksuit,
            ConceptArtTracksuit,
            Tamayo,
        }

        public enum PTenum
        {
            Off,
            PureWhite,
            RedandWhite,
        }

        public enum AOAenum
        {
            Off,
            Default,
            Smug,
        }

        public enum Menuenum
        {
            L7M3,
            Neptune,
        }

         public enum WinterCasualenum
        {
            Default,
            Yukari,
            Yukiko,
            BlueDress,
        }

        public enum MidwinterUniformenum
        {
            Default,
            Rise,
            NoGlovesNoScarf,
            FurCoat,
        }

        public enum MidwinterCasualenum
        {
            Default,
            Rise,
            FurCoat,
        }

        public enum SummerUniformenum
        {
            Default,
            WhiteShirt,
            Kotomo,
        }

        public enum WinterUniformenum
        {
            Default,
            Turtleneck,
        }


        [Category("Bustups")]
        [DisplayName("Bustups")]
        [Description("Check mod page for differences.")]
        [DefaultValue(Bustupenum.Default)]
        [Display(Order = 1)]
        public Bustupenum Bustup { get; set; }

        [Category("Outfits")]
        [DisplayName("Winter Casual")]
        [Description("Choose the Midwinter Casual outfit. Blue dress is not recommended for story reasons.")]
        [DefaultValue(WinterCasualenum.Default)]
        [Display(Order = 2)]
        public WinterCasualenum WinterCasual { get; set; }

        [Category("Outfits")]
        [DisplayName("Summer Causal")]
        [Description("Choose a Summer Casual.")]
        [DefaultValue(FuukaDressenum.Off)]
        [Display(Order = 3)]
        public FuukaDressenum FuukaDress { get; set; }

        [Category("Outfits")]
        [DisplayName("Midwinter Uniform")]
        [Description("Select a Midwinter Uniform.")]
        [DefaultValue(MidwinterUniformenum.Default)]
        [Display(Order = 4)]
        public MidwinterUniformenum MidwinterUniform { get; set; }

        [Category("Outfits")]
        [DisplayName("Midwinter Casual")]
        [Description("Select a Midwinter Casual outfit.")]
        [DefaultValue(MidwinterCasualenum.Default)]
        [Display(Order = 5)]
        public MidwinterCasualenum MidwinterCasual { get; set; }

        [Category("Outfits")]
        [DisplayName("Summer Uniform")]
        [Description("Select a Summer Uniform outfit.")]
        [DefaultValue(SummerUniformenum.Default)]
        [Display(Order = 6)]
        public SummerUniformenum SummerUniform { get; set; }

        [Category("Outfits")]
        [DisplayName("Winter Uniform")]
        [Description("Select a Winter Uniform outfit.")]
        [DefaultValue(WinterUniformenum.Default)]
        [Display(Order = 7)]
        public WinterUniformenum WinterUniform { get; set; }

        [Category("Outfits")]
        [DisplayName("Workout Outfit")]
        [Description("Choose the workout outfit.")]
        [DefaultValue(Tracksuitenum.Default)]
        [Display(Order = 8)]
        public Tracksuitenum Tracksuit { get; set; }

        [Category("Outfits")]
        [DisplayName("Lawson Outfit over 777 uniform")]
        [Description("Yeah")]
        [DefaultValue(false)]
        [Display(Order = 9)]
        public bool Lawson { get; set; } = false;

        [Category("Outfits")]
        [DisplayName("Phantom Thief Outfit Overhaul")]
        [Description("Overhauls Kasumi's PT outfit with a a gold and whtie version or red, gold, and white version.")]
        [DefaultValue(PTenum.Off)]
        [Display(Order = 10)]
        public PTenum PTOutfit { get; set; }

        [Category("Misc")]
        [DisplayName("No AOA Art")]
        [Description("No AOA art. Just shows the model.")]
        [DefaultValue(AOAenum.Off)]
        [Display(Order = 11)]
        public AOAenum NoAOA { get; set; }

        [Category("Misc")]
        [DisplayName("Menu Art")]
        [Description("Choose the style of art you see in the menus")]
        [DefaultValue(Menuenum.L7M3)]
        [Display(Order = 12)]
        public Menuenum Menu { get; set; }
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}