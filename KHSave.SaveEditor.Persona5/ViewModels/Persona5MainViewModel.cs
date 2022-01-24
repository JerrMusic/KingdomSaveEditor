using KHSave.LibPersona5;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Persona5.Interfaces;
using KHSave.SaveEditor.Persona5.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class Persona5MainViewModel : BaseNotifyPropertyChanged,
        IRefreshUi, IOpenStream, IWriteToStream,
        IPersonaList, ISkillList, IEquipmentList,
        IConsumableList, ITraitList
    {
        private static readonly string[] MeleeType = new string[]
        {
            "Dagger",
            "Dagger",
            "Pole",
            "MorganaMelee",
            "AnnMelee",
            "YusukeMelee",
            "MakotoMelee",
            "HaruMelee",
            "FutabaMelee",
            "GoroMelee",
            "VioletMelee",
            "VioletMelee",
            "VioletMelee",
            "VioletMelee",
            "VioletMelee",
            "VioletMelee",
        };
        private static readonly string[] RangeType = new string[]
        {
            "RangeJoker",
            "RangeJoker",
            "RyujiRange",
            "MorganaRange",
            "AnnRange",
            "YusukeRange",
            "MakotoRange",
            "HaruRange",
            "FutabaRange",
            "RangeCrow",
            "VioletRange",
            "VioletRange",
            "VioletRange",
            "VioletRange",
            "VioletRange",
            "VioletRange",
        };

        private const string DefaultTab = "Characters";
        private static List<Presets.Persona> Demons;
        private static List<Presets.Persona> DemonsRoyal;
        private Presets.Items _itemsVanilla;
        private Presets.Items _itemsRoyal;

        public ISavePersona5 Save { get; private set; }

        public CharactersViewModel Characters { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public CompendiumViewModel Compendium { get; set; }
        public SystemViewModel System { get; set; }

        public Visibility SimpleVisibility => Common.Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Common.Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public string CurrentTabId
        {
            get => Common.Global.LastPersona5Tab ?? DefaultTab;
            set => Common.Global.LastPersona5Tab = value;
        }

        public IEnumerable<PersonaEntryViewModel> PersonaList { get; private set; }
        public IEnumerable<SkillViewModel> SkillList { get; private set; }
        public KhEnumListModel<EnumIconTypeModel<Skill>, Skill> SkillVanillaList { get; } = new KhEnumListModel<EnumIconTypeModel<Skill>, Skill>();
        public KhEnumListModel<EnumIconTypeModel<SkillRoyal>, SkillRoyal> SkillRoyalList { get; } =
            new KhEnumListModel<EnumIconTypeModel<SkillRoyal>, SkillRoyal>();

        public KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment> EquipmentList { get; } = new KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment>();
        public IEnumerable<EquipmentModel> Accessories { get; private set; }
        public IEnumerable<EquipmentModel> Armors { get; private set; }
        public IEnumerable<EquipmentModel> Outfits { get; private set; }
        public IEnumerable<EquipmentModel> MeleeWeapons { get; private set; }
        public IEnumerable<EquipmentModel> RangeWeapons { get; private set; }
        public IEnumerable<Presets.Consumable> ConsumableItems { get; private set; }
        public KhEnumListModel<Trait> TraitList { get; } = new KhEnumListModel<Trait>();

        public void RefreshUi()
        {
            Characters = new CharactersViewModel(Save, this, this, this, this);
            Inventory = new InventoryViewModel(Save, this);
            Compendium = new CompendiumViewModel(Save, this, this, this);
            System = new SystemViewModel(Save);

            OnPropertyChanged(nameof(SimpleVisibility));
            OnPropertyChanged(nameof(AdvancedVisibility));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(Inventory));
        }

        public void OpenStream(Stream stream)
        {
            Save = SavePersona5.Read(stream);
            SkillList = Save.IsRoyal
                ? SkillRoyalList
                    .Select(x => new SkillViewModel()
                    {
                        Name = x.Name,
                        Value = (Skill)x.Value,
                        Icon = x.Icon,
                    })
                    .ToList()
                : SkillVanillaList
                    .Select(x => new SkillViewModel()
                    {
                        Name = x.Name,
                        Value = x.Value,
                        Icon = x.Icon,
                    })
                    .ToList();

            if (Save.IsRoyal)
            {
                if (DemonsRoyal == null)
                    DemonsRoyal = Presets.GetPersona(true);
                if (_itemsRoyal == null)
                    _itemsRoyal = Presets.GetItems(true);

                PersonaList = GetPersona(DemonsRoyal);
                ProcessItems(_itemsRoyal);
            }
            else
            {
                if (Demons == null)
                    Demons = Presets.GetPersona(false);
                if (_itemsVanilla == null)
                    _itemsVanilla = Presets.GetItems(false);

                PersonaList = GetPersona(Demons);
                ProcessItems(_itemsVanilla);
            }

            RefreshUi();
        }

        private List<PersonaEntryViewModel> GetPersona(List<Presets.Persona> persona) =>
            persona.Select(x => new PersonaEntryViewModel(x))
            .ToList();

        private void ProcessItems(Presets.Items items)
        {
            Accessories = items.Accessories
                .Select(x => new EquipmentModel(x, 0x2000, "Accessory"))
                .ToList();
            Armors = items.Armors
                .Select(x =>
                {
                    var armorType = "Protector";
                    if ((x.EquippableFlags & Presets.ArmorEquipAllMask) == Presets.ArmorEquipAllMask)
                        armorType = "Protector";
                    else if ((x.EquippableFlags & Presets.ArmorEquipUnisexMask) == Presets.ArmorEquipUnisexMask)
                        armorType = "ProtectorUnisex";
                    else if ((x.EquippableFlags & Presets.ArmorEquipMaleMask) != 0)
                        armorType = "ProtectorMale";
                    else if ((x.EquippableFlags & Presets.ArmorEquipFemaleMask) != 0)
                        armorType = "ProtectorMale";
                    else if ((x.EquippableFlags & Presets.ArmorEquipCatMask) != 0)
                        armorType = "ProtectorCat";

                    return new EquipmentModel(x, 0x1000, armorType);
                }).ToList();
            Outfits = items.Outfits
                .Select(x => new EquipmentModel(x, 0x7000, "Accessory"))
                .ToList();
            MeleeWeapons = items.MeleeWeapons
                .Select(x => new EquipmentModel(x, 0x0000, MeleeType[GetFlagIndex(x.EquippableFlags)]))
                .ToList();
            RangeWeapons = items.RangeWeapons
                .Select(x => new EquipmentModel(x, 0x8000, RangeType[GetFlagIndex(x.EquippableFlags)]))
                .ToList();
            ConsumableItems = items.Consumables;
        }

        private int GetFlagIndex(int mask)
        {
            for (var i = 0; i < 16; i++)
                if ((mask & (1 << i)) != 0)
                    return i;
            return default;
        }

        public void WriteToStream(Stream stream) =>
            SavePersona5.Write(stream, Save);
    }
}
