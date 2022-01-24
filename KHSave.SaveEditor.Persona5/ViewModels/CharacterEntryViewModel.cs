using KHSave.Attributes;
using KHSave.LibPersona5;
using KHSave.LibPersona5.Models;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Persona5.Interfaces;
using KHSave.SaveEditor.Persona5.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class CharacterEntryViewModel : GenericListModel<PersonaViewModel>
    {
        private readonly ISavePersona5 _save;
        private readonly Characters _id;
        private readonly Character _character;
        private readonly IEquipmentList _equipmentList;

        public CharacterEntryViewModel(
            ISavePersona5 save,
            Character character,
            int index,
            IPersonaList personaList,
            ISkillList skillList,
            IEquipmentList equipmentList,
            ITraitList traitList) :
            base(character.Persona.Select((x, i) => new PersonaViewModel(-1, x, personaList, skillList, traitList)))
        {
            _save = save;
            _id = (Characters)index;
            _character = character;
            _equipmentList = equipmentList;
        }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public string Name => InfoAttribute.GetInfo(_id);

        public KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment> EquipmentList =>
            _equipmentList.EquipmentList;

        public IEnumerable<EquipmentModel> Accessories => _equipmentList.Accessories;
        public IEnumerable<EquipmentModel> Armors => _equipmentList.Armors;
        public IEnumerable<EquipmentModel> Outfits => _equipmentList.Outfits;
        public IEnumerable<EquipmentModel> MeleeWeapons => _equipmentList.MeleeWeapons;
        public IEnumerable<EquipmentModel> RangeWeapons => _equipmentList.RangeWeapons;

        public bool IsUnlocked
        {
            get
            {
                switch (_id)
                {
                    case Characters.Joker:
                        return true;
                    case Characters.Skull:
                        return _save.PartyModifierRyuji;
                    case Characters.Mona:
                        return _save.PartyModifierMorgana;
                    case Characters.Panther:
                        return _save.PartyModifierAnn;
                    case Characters.Fox:
                        return _save.PartyModifierYusuke;
                    case Characters.Queen:
                        return _save.PartyModifierMakoto;
                    case Characters.Noir:
                        return _save.PartyModifierHaru;
                    case Characters.Oracle:
                        return _save.PartyModifierFutaba;
                    case Characters.Crow:
                        return _save.PartyModifierAkechi;
                    case Characters.Violet:
                        return _save.PartyModifierKasumi;
                    default:
                        return false;
                }
            }
            set
            {
                switch (_id)
                {
                    case Characters.Skull:
                        _save.PartyModifierRyuji = value;
                        break;
                    case Characters.Mona:
                        _save.PartyModifierMorgana = value;
                        break;
                    case Characters.Panther:
                        _save.PartyModifierAnn = value;
                        break;
                    case Characters.Fox:
                        _save.PartyModifierYusuke = value;
                        break;
                    case Characters.Queen:
                        _save.PartyModifierMakoto = value;
                        break;
                    case Characters.Noir:
                        _save.PartyModifierHaru = value;
                        break;
                    case Characters.Oracle:
                        _save.PartyModifierFutaba = value;
                        break;
                    case Characters.Crow:
                        _save.PartyModifierAkechi = value;
                        break;
                }
            }
        }

        public int Experience
        {
            get => _character.Experience;
            set => _character.Experience = value;
        }

        public int CurrentHp
        {
            get => _character.CurrentHp;
            set => _character.CurrentHp = value;
        }

        public int CurrentMp
        {
            get => _character.CurrentMp;
            set => _character.CurrentMp = value;
        }

        public ushort MeleeWeaponId
        {
            get => (ushort)_character.MeleeWeapon;
            set
            {
                _character.MeleeWeapon = (Equipment)value;
                OnPropertyChanged();
            }
        }

        public ushort RangeWeaponId
        {
            get => (ushort)_character.RangeWeapon;
            set
            {
                _character.RangeWeapon = (Equipment)value;
                OnPropertyChanged();
            }
        }

        public ushort ProtectorId
        {
            get => (ushort)_character.Protector;
            set
            {
                _character.Protector = (Equipment)value;
                OnPropertyChanged();
            }
        }

        public ushort AccessoryId
        {
            get => (ushort)_character.Accessory;
            set
            {
                _character.Accessory = (Equipment)value;
                OnPropertyChanged();
            }
        }

        public ushort OutfitId
        {
            get => (ushort)_character.Outfit;
            set
            {
                _character.Outfit = (Equipment)value;
                OnPropertyChanged();
            }
        }

        protected override void OnSelectedItem(PersonaViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }
    }
}
