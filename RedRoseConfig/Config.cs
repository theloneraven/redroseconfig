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
        }

        public enum FuukaDressenum
        {
            Off,
            WhiteRibbon,
            BlueRibbon,
        }

        public enum Tracksuitenum
        {
            Off,
            BlackTracksuit,
            ConceptArt,
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
        }

        public enum MidwinterCasualenum
        {
            Default,
            Rise,
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
        [DisplayName("Fuuka Dress over Summer Casual")]
        [Description("Fuuka's blue dress over summer casual. Select the blue or white ribbon.")]
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
        [DisplayName("Recolored tracksuit over red tracksuit")]
        [Description("Kasumi's black tracksuit or concept art tracksuit over her school uniform tracksuit.")]
        [DefaultValue(Tracksuitenum.Off)]
        [Display(Order = 4)]
        public Tracksuitenum Tracksuit { get; set; }

        [Category("Outfits")]
        [DisplayName("Lawson Outfit over 777 uniform")]
        [Description("Yeah")]
        [DefaultValue(false)]
        [Display(Order = 5)]
        public bool Lawson { get; set; } = false;

        [Category("Misc")]
        [DisplayName("No AOA Art")]
        [Description("No AOA art. Just shows the model.")]
        [DefaultValue(AOAenum.Off)]
        [Display(Order = 7)]
        public AOAenum NoAOA { get; set; }

        [Category("Outfits")]
        [DisplayName("Phantom Thief Outfit Overhaul")]
        [Description("Overhauls Kasumi's PT outfit with a a gold and whtie version or red, gold, and white version.")]
        [DefaultValue(PTenum.Off)]
        [Display(Order = 6)]
        public PTenum PTOutfit { get; set; }

        [Category("Misc")]
        [DisplayName("Menu Art")]
        [Description("Choose the style of art you see in the menus")]
        [DefaultValue(Menuenum.L7M3)]
        [Display(Order = 8)]
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