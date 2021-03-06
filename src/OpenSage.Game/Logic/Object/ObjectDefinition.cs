﻿using System.Collections.Generic;
using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    public class ObjectDefinition : BaseInheritableAsset
    {
        internal static ObjectDefinition Parse(IniParser parser)
        {
            return parser.ParseTopLevelNamedBlock(
                (x, name) => x.Name = name,
                FieldParseTable);
        }

        internal static ObjectDefinition ParseReskin(IniParser parser)
        {
            var name = parser.ParseIdentifier();

            var reskinOf = parser.ParseAssetReference();

            var result = parser.ParseBlock(FieldParseTable);

            result.Name = name;
            result.InheritFrom = reskinOf;

            return result;
        }

        internal static readonly IniParseTable<ObjectDefinition> FieldParseTable = new IniParseTable<ObjectDefinition>
        {
            { "PlacementViewAngle", (parser, x) => x.PlacementViewAngle = parser.ParseInteger() },
            { "SelectPortrait", (parser, x) => x.SelectPortrait = parser.ParseAssetReference() },
            { "ButtonImage", (parser, x) => x.ButtonImage = parser.ParseAssetReference() },
            { "UpgradeCameo1", (parser, x) => x.UpgradeCameo1 = parser.ParseAssetReference() },
            { "UpgradeCameo2", (parser, x) => x.UpgradeCameo2 = parser.ParseAssetReference() },
            { "UpgradeCameo3", (parser, x) => x.UpgradeCameo3 = parser.ParseAssetReference() },
            { "UpgradeCameo4", (parser, x) => x.UpgradeCameo4 = parser.ParseAssetReference() },
            { "UpgradeCameo5", (parser, x) => x.UpgradeCameo5 = parser.ParseAssetReference() },

            { "Buildable", (parser, x) => x.Buildable = parser.ParseEnum<ObjectBuildableType>() },
            { "Side", (parser, x) => x.Side = parser.ParseAssetReference() },
            { "DisplayName", (parser, x) => x.DisplayName = parser.ParseLocalizedStringKey() },
            { "EditorSorting", (parser, x) => x.EditorSorting = parser.ParseEnumFlags<ObjectEditorSortingFlags>() },
            { "TransportSlotCount", (parser, x) => x.TransportSlotCount = parser.ParseInteger() },
            { "VisionRange", (parser, x) => x.VisionRange = parser.ParseFloat() },
            { "ShroudRevealToAllRange", (parser, x) => x.ShroudRevealToAllRange = parser.ParseFloat() },
            { "ShroudClearingRange", (parser, x) => x.ShroudClearingRange = parser.ParseFloat() },
            { "CrusherLevel", (parser, x) => x.CrusherLevel = parser.ParseInteger() },
            { "CrushableLevel", (parser, x) => x.CrushableLevel = parser.ParseInteger() },
            { "BuildCost", (parser, x) => x.BuildCost = parser.ParseInteger() },
            { "BuildTime", (parser, x) => x.BuildTime = parser.ParseFloat() },
            { "RefundValue", (parser, x) => x.RefundValue = parser.ParseInteger() },
            { "EnergyProduction", (parser, x) => x.EnergyProduction = parser.ParseInteger() },
            { "EnergyBonus", (parser, x) => x.EnergyBonus = parser.ParseInteger() },
            { "IsForbidden", (parser, x) => x.IsForbidden = parser.ParseBoolean() },
            { "IsBridge", (parser, x) => x.IsBridge = parser.ParseBoolean() },
            { "IsPrerequisite", (parser, x) => x.IsPrerequisite = parser.ParseBoolean() },
            { "WeaponSet", (parser, x) => x.WeaponSets.Add(WeaponSet.Parse(parser)) },
            { "ArmorSet", (parser, x) => x.ArmorSets.Add(ArmorSet.Parse(parser)) },
            { "CommandSet", (parser, x) => x.CommandSet = parser.ParseLocalizedStringKey() },
            { "Prerequisites", (parser, x) => x.Prerequisites = ObjectPrerequisites.Parse(parser) },
            { "IsTrainable", (parser, x) => x.IsTrainable = parser.ParseBoolean() },
            { "FenceWidth", (parser, x) => x.FenceWidth = parser.ParseFloat() },
            { "FenceXOffset", (parser, x) => x.FenceXOffset = parser.ParseFloat() },
            { "ExperienceValue", (parser, x) => x.ExperienceValue = VeterancyValues.Parse(parser) },
            { "ExperienceRequired", (parser, x) => x.ExperienceRequired = VeterancyValues.Parse(parser) },
            { "MaxSimultaneousOfType", (parser, x) => x.MaxSimultaneousOfType = MaxSimultaneousObjectCount.Parse(parser) },
            { "MaxSimultaneousLinkKey", (parser, x) => x.MaxSimultaneousLinkKey = parser.ParseIdentifier() },

            { "VoiceSelect", (parser, x) => x.VoiceSelect = parser.ParseAssetReference() },
            { "VoiceSelectGroup", (parser, x) => x.VoiceSelectGroup = parser.ParseAssetReference() },
            { "VoiceSelectBattle", (parser, x) => x.VoiceSelectBattle = parser.ParseAssetReference() },
            { "VoiceSelectBattleGroup", (parser, x) => x.VoiceSelectBattleGroup = parser.ParseAssetReference() },
            { "VoiceMove", (parser, x) => x.VoiceMove = parser.ParseAssetReference() },
            { "VoiceMoveGroup", (parser, x) => x.VoiceMoveGroup = parser.ParseAssetReference() },
            { "VoiceGuard", (parser, x) => x.VoiceGuard = parser.ParseAssetReference() },
            { "VoiceGuardGroup", (parser, x) => x.VoiceGuardGroup = parser.ParseAssetReference() },
            { "VoiceAttack", (parser, x) => x.VoiceAttack = parser.ParseAssetReference() },
            { "VoiceAttackGroup", (parser, x) => x.VoiceAttackGroup = parser.ParseAssetReference() },
            { "VoiceAttackCharge", (parser, x) => x.VoiceAttackCharge = parser.ParseAssetReference() },
            { "VoiceAttackChargeGroup", (parser, x) => x.VoiceAttackChargeGroup = parser.ParseAssetReference() },
            { "VoiceAttackAir", (parser, x) => x.VoiceAttackAir = parser.ParseAssetReference() },
            { "VoiceAttackAirGroup", (parser, x) => x.VoiceAttackAirGroup = parser.ParseAssetReference() },
            { "VoiceGroupSelect", (parser, x) => x.VoiceGroupSelect = parser.ParseAssetReference() },
            { "VoiceEnter", (parser, x) => x.VoiceEnter = parser.ParseAssetReference() },
            { "VoiceGarrison", (parser, x) => x.VoiceGarrison = parser.ParseAssetReference() },
            { "VoiceFear", (parser, x) => x.VoiceFear = parser.ParseAssetReference() },
            { "VoiceSelectElite", (parser, x) => x.VoiceSelectElite = parser.ParseAssetReference() },
            { "VoiceCreated", (parser, x) => x.VoiceCreated = parser.ParseAssetReference() },
            { "VoiceTaskUnable", (parser, x) => x.VoiceTaskUnable = parser.ParseAssetReference() },
            { "VoiceTaskComplete", (parser, x) => x.VoiceTaskComplete = parser.ParseAssetReference() },
            { "VoiceDefect", (parser, x) => x.VoiceDefect = parser.ParseAssetReference() },
            { "VoiceMeetEnemy", (parser, x) => x.VoiceMeetEnemy = parser.ParseAssetReference() },
            { "VoiceAlert", (parser, x) => x.VoiceAlert = parser.ParseAssetReference() },
            { "VoiceFullyCreated", (parser, x) => x.VoiceFullyCreated = parser.ParseAssetReference() },
            { "VoiceRetreatToCastle", (parser, x) => x.VoiceRetreatToCastle = parser.ParseAssetReference() },
            { "VoiceRetreatToCastleGroup", (parser, x) => x.VoiceRetreatToCastleGroup = parser.ParseAssetReference() },
            { "VoiceMoveToCamp", (parser, x) => x.VoiceMoveToCamp = parser.ParseAssetReference() },
            { "VoiceMoveToCampGroup", (parser, x) => x.VoiceMoveToCampGroup = parser.ParseAssetReference() },
            { "VoiceAttackStructure", (parser, x) => x.VoiceAttackStructure = parser.ParseAssetReference() },
            { "VoiceAttackStructureGroup", (parser, x) => x.VoiceAttackStructureGroup = parser.ParseAssetReference() },
            { "VoiceAttackMachine", (parser, x) => x.VoiceAttackMachine = parser.ParseAssetReference() },
            { "VoiceAttackMachineGroup", (parser, x) => x.VoiceAttackMachineGroup = parser.ParseAssetReference() },
            { "VoiceMoveWhileAttacking", (parser, x) => x.VoiceMoveWhileAttacking = parser.ParseAssetReference() },
            { "VoiceMoveWhileAttackingGroup", (parser, x) => x.VoiceMoveWhileAttackingGroup = parser.ParseAssetReference() },
            { "VoiceAmbushed", (parser, x) => x.VoiceAmbushed = parser.ParseAssetReference() },
            { "VoiceCombineWithHorde", (parser, x) => x.VoiceCombineWithHorde = parser.ParseAssetReference() },
            { "VoiceEnterStateAttack", (parser, x) => x.VoiceEnterStateAttack = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackCharge", (parser, x) => x.VoiceEnterStateAttackCharge = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackAir", (parser, x) => x.VoiceEnterStateAttackAir = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackStructure", (parser, x) => x.VoiceEnterStateAttackStructure = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackMachine", (parser, x) => x.VoiceEnterStateAttackMachine = parser.ParseAssetReference() },
            { "VoiceEnterStateMove", (parser, x) => x.VoiceEnterStateMove = parser.ParseAssetReference() },
            { "VoiceEnterStateRetreatToCastle", (parser, x) => x.VoiceEnterStateRetreatToCastle = parser.ParseAssetReference() },
            { "VoiceEnterStateMoveToCamp", (parser, x) => x.VoiceEnterStateMoveToCamp = parser.ParseAssetReference() },
            { "VoiceEnterStateMoveWhileAttacking", (parser, x) => x.VoiceEnterStateMoveWhileAttacking = parser.ParseAssetReference() },

            { "VoiceSelect2", (parser, x) => x.VoiceSelect2 = parser.ParseAssetReference() },
            { "VoiceSelectGroup2", (parser, x) => x.VoiceSelectGroup2 = parser.ParseAssetReference() },
            { "VoiceSelectBattle2", (parser, x) => x.VoiceSelectBattle2 = parser.ParseAssetReference() },
            { "VoiceSelectBattleGroup2", (parser, x) => x.VoiceSelectBattleGroup2 = parser.ParseAssetReference() },
            { "VoiceMove2", (parser, x) => x.VoiceMove2 = parser.ParseAssetReference() },
            { "VoiceMoveGroup2", (parser, x) => x.VoiceMoveGroup2 = parser.ParseAssetReference() },
            { "VoiceGuard2", (parser, x) => x.VoiceGuard2 = parser.ParseAssetReference() },
            { "VoiceGuardGroup2", (parser, x) => x.VoiceGuardGroup2 = parser.ParseAssetReference() },
            { "VoiceAttack2", (parser, x) => x.VoiceAttack2 = parser.ParseAssetReference() },
            { "VoiceAttackGroup2", (parser, x) => x.VoiceAttackGroup2 = parser.ParseAssetReference() },
            { "VoiceAttackCharge2", (parser, x) => x.VoiceAttackCharge2 = parser.ParseAssetReference() },
            { "VoiceAttackChargeGroup2", (parser, x) => x.VoiceAttackChargeGroup2 = parser.ParseAssetReference() },
            { "VoiceAttackAir2", (parser, x) => x.VoiceAttackAir2 = parser.ParseAssetReference() },
            { "VoiceAttackAirGroup2", (parser, x) => x.VoiceAttackAirGroup2 = parser.ParseAssetReference() },
            { "VoiceFear2", (parser, x) => x.VoiceFear2 = parser.ParseAssetReference() },
            { "VoiceCreated2", (parser, x) => x.VoiceCreated2 = parser.ParseAssetReference() },
            { "VoiceTaskComplete2", (parser, x) => x.VoiceTaskComplete2 = parser.ParseAssetReference() },
            { "VoiceDefect2", (parser, x) => x.VoiceDefect2 = parser.ParseAssetReference() },
            { "VoiceAlert2", (parser, x) => x.VoiceAlert2 = parser.ParseAssetReference() },
            { "VoiceFullyCreated2", (parser, x) => x.VoiceFullyCreated2 = parser.ParseAssetReference() },
            { "VoiceRetreatToCastle2", (parser, x) => x.VoiceRetreatToCastle2 = parser.ParseAssetReference() },
            { "VoiceRetreatToCastleGroup2", (parser, x) => x.VoiceRetreatToCastleGroup2 = parser.ParseAssetReference() },
            { "VoiceMoveToCamp2", (parser, x) => x.VoiceMoveToCamp2 = parser.ParseAssetReference() },
            { "VoiceMoveToCampGroup2", (parser, x) => x.VoiceMoveToCampGroup2 = parser.ParseAssetReference() },
            { "VoiceAttackStructure2", (parser, x) => x.VoiceAttackStructure2 = parser.ParseAssetReference() },
            { "VoiceAttackStructureGroup2", (parser, x) => x.VoiceAttackStructureGroup2 = parser.ParseAssetReference() },
            { "VoiceAttackMachine2", (parser, x) => x.VoiceAttackMachine2 = parser.ParseAssetReference() },
            { "VoiceAttackMachineGroup2", (parser, x) => x.VoiceAttackMachineGroup2 = parser.ParseAssetReference() },
            { "VoiceMoveWhileAttacking2", (parser, x) => x.VoiceMoveWhileAttacking2 = parser.ParseAssetReference() },
            { "VoiceMoveWhileAttackingGroup2", (parser, x) => x.VoiceMoveWhileAttackingGroup2 = parser.ParseAssetReference() },
            { "VoiceAmbushed2", (parser, x) => x.VoiceAmbushed2 = parser.ParseAssetReference() },
            { "VoiceCombineWithHorde2", (parser, x) => x.VoiceCombineWithHorde2 = parser.ParseAssetReference() },
            { "VoiceEnterStateAttack2", (parser, x) => x.VoiceEnterStateAttack2 = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackCharge2", (parser, x) => x.VoiceEnterStateAttackCharge2 = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackAir2", (parser, x) => x.VoiceEnterStateAttackAir2 = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackStructure2", (parser, x) => x.VoiceEnterStateAttackStructure2 = parser.ParseAssetReference() },
            { "VoiceEnterStateAttackMachine2", (parser, x) => x.VoiceEnterStateAttackMachine2 = parser.ParseAssetReference() },
            { "VoiceEnterStateMove2", (parser, x) => x.VoiceEnterStateMove2 = parser.ParseAssetReference() },
            { "VoiceEnterStateRetreatToCastle2", (parser, x) => x.VoiceEnterStateRetreatToCastle2 = parser.ParseAssetReference() },
            { "VoiceEnterStateMoveToCamp2", (parser, x) => x.VoiceEnterStateMoveToCamp2 = parser.ParseAssetReference() },
            { "VoiceEnterStateMoveWhileAttacking2", (parser, x) => x.VoiceEnterStateMoveWhileAttacking2 = parser.ParseAssetReference() },

            { "SoundMoveStart", (parser, x) => x.SoundMoveStart = parser.ParseAssetReference() },
            { "SoundMoveStartDamaged", (parser, x) => x.SoundMoveStart = parser.ParseAssetReference() },
            { "SoundMoveLoop", (parser, x) => x.SoundMoveLoop = parser.ParseAssetReference() },
            { "SoundMoveLoopDamaged", (parser, x) => x.SoundMoveLoopDamaged = parser.ParseAssetReference() },
            { "SoundOnDamaged", (parser, x) => x.SoundOnDamaged = parser.ParseAssetReference() },
            { "SoundOnReallyDamaged", (parser, x) => x.SoundOnReallyDamaged = parser.ParseAssetReference() },
            { "SoundDie", (parser, x) => x.SoundDie = parser.ParseAssetReference() },
            { "SoundDieFire", (parser, x) => x.SoundDieFire = parser.ParseAssetReference() },
            { "SoundDieToxin", (parser, x) => x.SoundDieToxin = parser.ParseAssetReference() },
            { "SoundStealthOn", (parser, x) => x.SoundStealthOn = parser.ParseAssetReference() },
            { "SoundStealthOff", (parser, x) => x.SoundStealthOff = parser.ParseAssetReference() },
            { "SoundCrush", (parser, x) => x.SoundCrush = parser.ParseAssetReference() },
            { "SoundAmbient", (parser, x) => x.SoundAmbient = parser.ParseAssetReference() },
            { "SoundAmbientDamaged", (parser, x) => x.SoundAmbientDamaged = parser.ParseAssetReference() },
            { "SoundAmbientReallyDamaged", (parser, x) => x.SoundAmbientReallyDamaged = parser.ParseAssetReference() },
            { "SoundAmbientRubble", (parser, x) => x.SoundAmbientRubble = parser.ParseAssetReference() },
            { "SoundAmbient2", (parser, x) => x.SoundAmbient2 = parser.ParseAssetReference() },
            { "SoundAmbientDamaged2", (parser, x) => x.SoundAmbientDamaged2 = parser.ParseAssetReference() },
            { "SoundAmbientReallyDamaged2", (parser, x) => x.SoundAmbientReallyDamaged2 = parser.ParseAssetReference() },
            { "SoundAmbientRubble2", (parser, x) => x.SoundAmbientRubble2 = parser.ParseAssetReference() },
            { "SoundAmbientBattle", (parser, x) => x.SoundAmbientBattle = parser.ParseAssetReference() },
            { "SoundCreated", (parser, x) => x.SoundCreated = parser.ParseAssetReference() },
            { "SoundEnter", (parser, x) => x.SoundEnter = parser.ParseAssetReference() },
            { "SoundExit", (parser, x) => x.SoundExit = parser.ParseAssetReference() },
            { "SoundPromotedVeteran", (parser, x) => x.SoundPromotedVeteran = parser.ParseAssetReference() },
            { "SoundPromotedElite", (parser, x) => x.SoundPromotedElite = parser.ParseAssetReference() },
            { "SoundPromotedHero", (parser, x) => x.SoundPromotedHero = parser.ParseAssetReference() },
            { "SoundFallingFromPlane", (parser, x) => x.SoundFallingFromPlane = parser.ParseAssetReference() },
            { "SoundImpact", (parser, x) => x.SoundImpact = parser.ParseAssetReference() },
            { "SoundCrushing", (parser, x) => x.SoundCrushing = parser.ParseAssetReference() },

            { "UnitSpecificSounds", (parser, x) => x.UnitSpecificSounds = UnitSpecificAssets.Parse(parser) },
            { "UnitSpecificFX", (parser, x) => x.UnitSpecificFX = UnitSpecificAssets.Parse(parser) },

            { "VoicePriority", (parser, x) => x.VoicePriority = parser.ParseInteger() },
            { "GroupVoiceThreshold", (parser, x) => x.GroupVoiceThreshold = parser.ParseInteger() },
            { "VoiceAmbushBlockingRadius", (parser, x) => x.VoiceAmbushBlockingRadius = parser.ParseInteger() },
            { "VoiceAmbushTimeout", (parser, x) => x.VoiceAmbushTimeout = parser.ParseInteger() },

            { "EvaEnemyUnitSightedEvent", (parser, x) => x.EvaEnemyUnitSightedEvent = parser.ParseAssetReference() },

            { "Behavior", (parser, x) => x.Behaviors.Add(BehaviorModuleData.ParseBehavior(parser)) },
            { "Draw", (parser, x) => x.Draws.Add(DrawModuleData.ParseDrawModule(parser)) },
            { "Body", (parser, x) => x.Body = BodyModuleData.ParseBody(parser) },
            { "ClientUpdate", (parser, x) => x.ClientUpdates.Add(ClientUpdateModuleData.ParseClientUpdate(parser)) },

            { "Locomotor", (parser, x) => x.Locomotors[parser.ParseEnum<LocomotorSet>()] = parser.ParseAssetReferenceArray() },
            { "KindOf", (parser, x) => x.KindOf = parser.ParseEnumBitArray<ObjectKinds>() },
            { "RadarPriority", (parser, x) => x.RadarPriority = parser.ParseEnum<RadarPriority>() },
            { "EnterGuard", (parser, x) => x.EnterGuard = parser.ParseBoolean() },
            { "HijackGuard", (parser, x) => x.HijackGuard = parser.ParseBoolean() },
            { "DisplayColor", (parser, x) => x.DisplayColor = IniColorRgb.Parse(parser) },
            { "Scale", (parser, x) => x.Scale = parser.ParseFloat() },
            { "Geometry", (parser, x) => x.Geometry = parser.ParseEnum<ObjectGeometry>() },
            { "GeometryMajorRadius", (parser, x) => x.GeometryMajorRadius = parser.ParseFloat() },
            { "GeometryMinorRadius", (parser, x) => x.GeometryMinorRadius = parser.ParseFloat() },
            { "GeometryHeight", (parser, x) => x.GeometryHeight = parser.ParseFloat() },
            { "GeometryIsSmall", (parser, x) => x.GeometryIsSmall = parser.ParseBoolean() },
            { "FactoryExitWidth", (parser, x) => x.FactoryExitWidth = parser.ParseInteger() },
            { "FactoryExtraBibWidth", (parser, x) => x.FactoryExtraBibWidth = parser.ParseFloat() },
            { "Shadow", (parser, x) => x.Shadow = parser.ParseEnum<ObjectShadowType>() },
            { "ShadowTexture", (parser, x) => x.ShadowTexture = parser.ParseAssetReference() },
            { "ShadowSizeX", (parser, x) => x.ShadowSizeX = parser.ParseInteger() },
            { "ShadowSizeY", (parser, x) => x.ShadowSizeY = parser.ParseInteger() },
            { "InstanceScaleFuzziness", (parser, x) => x.InstanceScaleFuzziness = parser.ParseFloat() },
            { "BuildCompletion", (parser, x) => x.BuildCompletion = parser.ParseAssetReference() },
            { "BuildVariations", (parser, x) => x.BuildVariations = parser.ParseAssetReferenceArray() },

            { "ExperienceScalarTable", (parser, x) => x.ExperienceScalarTable = parser.ParseAssetReference() },

            { "InheritableModule", (parser, x) => x.InheritableModules.Add(InheritableModule.Parse(parser)) },
            { "OverrideableByLikeKind", (parser, x) => x.OverrideableByLikeKinds.Add(OverrideableByLikeKind.Parse(parser)) },

            { "RemoveModule", (parser, x) => x.RemoveModules.Add(parser.ParseIdentifier()) },
            { "AddModule", (parser, x) => x.AddModules.Add(AddModule.Parse(parser)) },
            { "ReplaceModule", (parser, x) => x.ReplaceModules.Add(ReplaceModule.Parse(parser)) },
        };

        public string Name { get; protected set; }

        // Art
        public int PlacementViewAngle { get; private set; }
        public string SelectPortrait { get; private set; }
        public string ButtonImage { get; private set; }
        public string UpgradeCameo1 { get; private set; }
        public string UpgradeCameo2 { get; private set; }
        public string UpgradeCameo3 { get; private set; }
        public string UpgradeCameo4 { get; private set; }
        public string UpgradeCameo5 { get; private set; }

        // Design
        public ObjectBuildableType Buildable { get; private set; }
        public string Side { get; private set; }
        public string DisplayName { get; private set; }
        public ObjectEditorSortingFlags EditorSorting { get; private set; }
        public int TransportSlotCount { get; private set; }
        public float VisionRange { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public float ShroudRevealToAllRange { get; private set; }

        public float ShroudClearingRange { get; private set; }
        public int CrusherLevel { get; private set; }
        public int CrushableLevel { get; private set; }
        public int BuildCost { get; private set; }

        /// <summary>
        /// Build time in seconds.
        /// </summary>
        public float BuildTime { get; private set; }
        public int RefundValue { get; private set; }
        public int EnergyProduction { get; private set; }
        public int EnergyBonus { get; private set; }
        public bool IsForbidden { get; private set; }
        public bool IsBridge { get; private set; }
        public bool IsPrerequisite { get; private set; }
        public List<WeaponSet> WeaponSets { get; } = new List<WeaponSet>();
        public List<ArmorSet> ArmorSets { get; } = new List<ArmorSet>();
        public string CommandSet { get; private set; }
        public ObjectPrerequisites Prerequisites { get; private set; }
        public bool IsTrainable { get; private set; }

        /// <summary>
        /// Spacing used by fence tool in WorldBuilder.
        /// </summary>
        public float FenceWidth { get; private set; }

        /// <summary>
        /// Offset used by fence tool in WorldBuilder, to ensure that corners line up.
        /// </summary>
        public float FenceXOffset { get; private set; }

        /// <summary>
        /// Experience points given off when this object is destroyed.
        /// </summary>
        public VeterancyValues ExperienceValue { get; private set; }

        /// <summary>
        /// Experience points required to be promoted to next level.
        /// </summary>
        public VeterancyValues ExperienceRequired { get; private set; }

        public MaxSimultaneousObjectCount MaxSimultaneousOfType { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public string MaxSimultaneousLinkKey { get; private set; }

        // Audio
        public string VoiceSelect { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectBattle { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectBattleGroup { get; private set; }

        public string VoiceMove { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveGroup { get; private set; }

        public string VoiceGuard { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceGuardGroup { get; private set; }

        public string VoiceAttack { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackCharge { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackChargeGroup { get; private set; }

        public string VoiceAttackAir { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackAirGroup { get; private set; }

        public string VoiceGroupSelect { get; private set; }
        public string VoiceEnter { get; private set; }
        public string VoiceGarrison { get; private set; }
        public string VoiceFear { get; private set; }
        public string VoiceSelectElite { get; private set; }
        public string VoiceCreated { get; private set; }
        public string VoiceTaskUnable { get; private set; }
        public string VoiceTaskComplete { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceDefect { get; private set; }

        public string VoiceMeetEnemy { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAlert { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceFullyCreated { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceRetreatToCastle { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceRetreatToCastleGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveToCamp { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveToCampGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackStructure { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackStructureGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackMachine { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackMachineGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveWhileAttacking { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveWhileAttackingGroup { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAmbushed { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceCombineWithHorde { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttack { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackCharge { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackAir { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackStructure { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackMachine { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMove { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateRetreatToCastle { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMoveToCamp { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMoveWhileAttacking { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelect2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectBattle2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceSelectBattleGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMove2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceGuard2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceGuardGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttack2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackCharge2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackChargeGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackAir2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackAirGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceFear2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceCreated2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceTaskComplete2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceDefect2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAlert2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceFullyCreated2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceRetreatToCastle2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceRetreatToCastleGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveToCamp2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveToCampGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackStructure2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackStructureGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackMachine2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAttackMachineGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveWhileAttacking2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceMoveWhileAttackingGroup2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceAmbushed2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceCombineWithHorde2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttack2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackCharge2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackAir2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackStructure2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateAttackMachine2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMove2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateRetreatToCastle2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMoveToCamp2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string VoiceEnterStateMoveWhileAttacking2 { get; private set; }

        public string SoundMoveStart { get; private set; }
        public string SoundMoveStartDamaged { get; private set; }
        public string SoundMoveLoop { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundMoveLoopDamaged { get; private set; }

        public string SoundOnDamaged { get; private set; }
        public string SoundOnReallyDamaged { get; private set; }
        public string SoundDie { get; private set; }
        public string SoundDieFire { get; private set; }
        public string SoundDieToxin { get; private set; }
        public string SoundStealthOn { get; private set; }
        public string SoundStealthOff { get; private set; }
        public string SoundCrush { get; private set; }
        public string SoundAmbient { get; private set; }
        public string SoundAmbientDamaged { get; private set; }
        public string SoundAmbientReallyDamaged { get; private set; }
        public string SoundAmbientRubble { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundAmbient2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundAmbientDamaged2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundAmbientReallyDamaged2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundAmbientRubble2 { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundAmbientBattle { get; private set; }

        public string SoundCreated { get; private set; }
        public string SoundEnter { get; private set; }
        public string SoundExit { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundPromotedVeteran { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundPromotedElite { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundPromotedHero { get; private set; }

        public string SoundFallingFromPlane { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundImpact { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string SoundCrushing { get; private set; }

        public UnitSpecificAssets UnitSpecificSounds { get; private set; }
        public UnitSpecificAssets UnitSpecificFX { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public int VoicePriority { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public int GroupVoiceThreshold { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public int VoiceAmbushBlockingRadius { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public int VoiceAmbushTimeout { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string EvaEnemyUnitSightedEvent { get; private set; }

        // Engineering
        public List<BehaviorModuleData> Behaviors { get; } = new List<BehaviorModuleData>();
        public List<DrawModuleData> Draws { get; } = new List<DrawModuleData>();
        public BodyModuleData Body { get; private set; }
        public List<ClientUpdateModuleData> ClientUpdates { get; } = new List<ClientUpdateModuleData>();
        public Dictionary<LocomotorSet, string[]> Locomotors { get; } = new Dictionary<LocomotorSet, string[]>();
        public BitArray<ObjectKinds> KindOf { get; private set; }
        public RadarPriority RadarPriority { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public bool EnterGuard { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public bool HijackGuard { get; private set; }

        public IniColorRgb DisplayColor { get; private set; }
        public float Scale { get; private set; }
        public ObjectGeometry Geometry { get; private set; }
        public float GeometryMajorRadius { get; private set; }
        public float GeometryMinorRadius { get; private set; }
        public float GeometryHeight { get; private set; }
        public bool GeometryIsSmall { get; private set; }

        /// <summary>
        /// Amount of space to leave for exiting units.
        /// </summary>
        public int FactoryExitWidth { get; private set; }

        [AddedIn(SageGame.CncGeneralsZeroHour)]
        public float FactoryExtraBibWidth { get; private set; }

        public ObjectShadowType Shadow { get; private set; }
        public string ShadowTexture { get; private set; }
        public int ShadowSizeX { get; private set; }
        public int ShadowSizeY { get; private set; }
        public float InstanceScaleFuzziness { get; private set; }
        public string BuildCompletion { get; private set; }
        public string[] BuildVariations { get; private set; }

        [AddedIn(SageGame.Bfme)]
        public string ExperienceScalarTable { get; private set; }

        public List<InheritableModule> InheritableModules { get; } = new List<InheritableModule>();
        public List<OverrideableByLikeKind> OverrideableByLikeKinds { get; } = new List<OverrideableByLikeKind>();

        // Map.ini module modifications
        public List<string> RemoveModules { get; } = new List<string>();
        public List<AddModule> AddModules { get; } = new List<AddModule>();
        public List<ReplaceModule> ReplaceModules { get; } = new List<ReplaceModule>();
    }

    [AddedIn(SageGame.CncGeneralsZeroHour)]
    public struct MaxSimultaneousObjectCount
    {
        internal static MaxSimultaneousObjectCount Parse(IniParser parser)
        {
            var token = parser.GetNextToken();
            if (parser.IsInteger(token))
            {
                return new MaxSimultaneousObjectCount
                {
                    CountType = MaxSimultaneousObjectCountType.Explicit,
                    ExplicitCount = parser.ScanInteger(token)
                };
            }

            if (token.Text != "DeterminedBySuperweaponRestriction")
            {
                throw new IniParseException("Unknown MaxSimultaneousOfType value: " + token.Text, token.Position);
            }

            return new MaxSimultaneousObjectCount
            {
                CountType = MaxSimultaneousObjectCountType.DeterminedBySuperweaponRestriction
            };
        }

        public MaxSimultaneousObjectCountType CountType;
        public int ExplicitCount;
    }

    public enum MaxSimultaneousObjectCountType
    {
        Explicit,
        DeterminedBySuperweaponRestriction
    }

    public enum ObjectBuildableType
    {
        [IniEnum("No")]
        No,

        [IniEnum("Yes")]
        Yes,

        [IniEnum("Only_By_AI")]
        OnlyByAI
    }

    public sealed class AddModule : ObjectDefinition
    {
        internal static new AddModule Parse(IniParser parser)
        {
            var name = parser.GetNextTokenOptional();

            var result = parser.ParseBlock(FieldParseTable);

            result.Name = name?.Text;

            return result;
        }

        private static new readonly IniParseTable<AddModule> FieldParseTable = ObjectDefinition.FieldParseTable
            .Concat(new IniParseTable<AddModule>());
    }

    public sealed class ChildObject : ObjectDefinition
    {
        internal static new ChildObject Parse(IniParser parser)
        {
            var childName = parser.GetNextToken();
            var parentName = parser.GetNextToken();

            var result = parser.ParseBlock(FieldParseTable);

            result.Name = childName.Text;
            result.ChildOf = parentName.Text;

            return result;
        }

        private static new readonly IniParseTable<ChildObject> FieldParseTable = ObjectDefinition.FieldParseTable
            .Concat(new IniParseTable<ChildObject>());

        public string ChildOf { get; private set; }
    }

    public sealed class ReplaceModule
    {
        internal static ReplaceModule Parse(IniParser parser)
        {
            return parser.ParseNamedBlock(
                (x, name) => x.Name = name,
                FieldParseTable);
        }

        private static readonly IniParseTable<ReplaceModule> FieldParseTable = new IniParseTable<ReplaceModule>
        {
            { "Behavior", (parser, x) => x.Module = BehaviorModuleData.ParseBehavior(parser) },
            { "Draw", (parser, x) => x.Module = DrawModuleData.ParseDrawModule(parser) },
            { "Body", (parser, x) => x.Module = BodyModuleData.ParseBody(parser) },
        };

        public string Name { get; private set; }

        public ModuleData Module { get; private set; }
    }
}
