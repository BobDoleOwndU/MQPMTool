using FoxTool.Fox;
using FoxTool.Fox.Containers;
using FoxTool.Fox.Types;
using FoxTool.Fox.Types.Structs;
using FoxTool.Fox.Types.Values;
using MQPMTool2.Classes;
using System;
using System.Collections.Generic;

namespace MQPMTool2.Static
{
    public static class PartsConverter
    {
        private const uint BASE_ADDRESS = 0x067B4FB0;
        private const uint ENTITY_SIZE = 0x70;
        private const short DATA_SET_UNKNOWN = 232;
        private const short MODEL_DESCRIPTION_UNKNOWN = 288;
        private const short FOX_TARGET_DESCRIPTION_UNKNOWN = 112;
        private const short PHYSICS_DESCRIPTION_UNKNOWN = 112;
        private const short SOUND_DESCRIPTION_UNKNOWN = 112;
        private const short EFFECT_DESCRIPTION_UNKNOWN = 232;
        private const short SIM_DESCRIPTION_UNKNOWN = 120;

        private static List<FoxClass> classes = new List<FoxClass>();
        private static FoxClass classEntity;
        private static FoxClass classData;
        private static FoxClass classDataSet;
        private static FoxClass classModelDescription;
        private static FoxClass classFoxTargetDescription;
        private static FoxClass classEffectDescription;
        private static FoxClass classSimDescription;
        private static FoxClass classPhysicsDescription;
        private static FoxClass classSoundDescription;

        private static FoxEntity baseDataSet;
        private static FoxEntity baseModelDescription;
        private static FoxEntity baseTargetDescription;
        private static FoxEntity basePhysicsDescription;
        private static FoxEntity baseEffectDescription;
        private static FoxEntity baseSimDescription;

        static PartsConverter()
        {
            InitializeBaseValues();
        } //constructor

        public static FoxFile GetFoxFile(Parts parts, Outfit outfit)
        {
            uint address = BASE_ADDRESS;
            int unknown = 37243;
            uint modelAddress;
            uint physicsAddress;
            FoxStringMap<FoxEntityPtr> dataList;

            int targetDescriptionCount = 0;
            int effectDescriptionCount = 0;
            int simDescriptionCount = 0;

            FoxFile foxFile = new FoxFile();
            foxFile.classes = classes;
            foxFile.entities = new List<FoxEntity>();

            //DATA SET
            FoxEntity dataSet = baseDataSet.Copy();
            dataSet.Address = address;
            dataSet.Unknown2 = unknown;
            dataList = dataSet.staticProperties[2].Container as FoxStringMap<FoxEntityPtr>;
            foxFile.entities.Add(dataSet);
            address += ENTITY_SIZE;
            unknown++;

            //MODEL DESCRIPTION
            FoxEntity modelDescription = baseModelDescription.Copy();
            modelDescription.Address = address;
            modelDescription.Unknown2 = unknown;
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = outfit.mdlPath;
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[6].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = outfit.cnpPath;
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[8].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = outfit.rdvPath;
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                stringLiteral.Literal = "ModelDescription0000";
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(modelDescription);
            modelAddress = address;
            address += ENTITY_SIZE;
            unknown++;

            //TARGET DESCRIPTION 0
            FoxEntity targetDescription0 = baseTargetDescription.Copy();
            targetDescription0.Address = address;
            targetDescription0.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription0.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription0.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription0.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Target";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription0.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetdefense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription0.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription0);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;

            //TARGET DESCRIPTION 1
            FoxEntity targetDescription1 = baseTargetDescription.Copy();
            targetDescription1.Address = address;
            targetDescription1.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription1.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription1.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription1.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "TargetCqcDefense";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription1.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetcqcdefense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription1.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription1);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;

            //TARGET DESCRIPTION 2
            FoxEntity targetDescription2 = baseTargetDescription.Copy();
            targetDescription2.Address = address;
            targetDescription2.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription2.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription2.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription2.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "TargetPushOffense";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription2.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetpushoffense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription2.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription2);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;

            //TARGET DESCRIPTION 3
            FoxEntity targetDescription3 = baseTargetDescription.Copy();
            targetDescription3.Address = address;
            targetDescription3.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription3.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription3.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription3.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "TargetBushOffense";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription3.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetbushoffense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription3.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription3);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;

            /*//TARGET DESCRIPTION 4
            FoxEntity targetDescription4 = baseTargetDescription.Copy();
            targetDescription4.Address = address;
            targetDescription4.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription4.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription4.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription4.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "TargetDownWashDefense";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription4.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetdownwashdefense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription4.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription4);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;*/

            //TARGET DESCRIPTION 5
            FoxEntity targetDescription5 = baseTargetDescription.Copy();
            targetDescription5.Address = address;
            targetDescription5.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription5.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription5.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = targetDescription5.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "TargetSetPlayDefense";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = targetDescription5.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_targetcqcdefense.tgt";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = targetDescription5.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(targetDescription5);
            address += ENTITY_SIZE;
            unknown++;
            targetDescriptionCount++;

            //PHYSICS DESCRIPTION
            FoxEntity physicsDescription = basePhysicsDescription.Copy();
            physicsDescription.Address = address;
            physicsDescription.Unknown2 = unknown;
            {
                FoxDynamicArray<FoxEntityLink> staticArray = physicsDescription.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = physicsDescription.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(physicsDescription);
            physicsAddress = address;
            address += ENTITY_SIZE;
            unknown++;

            //EFFECT DESCRIPTION 0
            FoxEntity effectDescription0 = baseEffectDescription.Copy();
            effectDescription0.Address = address;
            effectDescription0.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription0.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription0.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription0.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "breath";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription0.staticProperties[6].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "CNP_MOUTH";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription0.staticProperties[8].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription0.staticProperties[10].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription0.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/smoke/fx_tpp_smkchrbrt01_s0GM.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription0.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription0);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 1
            FoxEntity effectDescription1 = baseEffectDescription.Copy();
            effectDescription1.Address = address;
            effectDescription1.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription1.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription1.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription1.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "DiveSmoke";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription1.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_000_WAIST";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription1.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription1.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription1.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrdivsmk01_s1.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription1.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription1);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 2
            FoxEntity effectDescription2 = baseEffectDescription.Copy();
            effectDescription2.Address = address;
            effectDescription2.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription2.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription2.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription2.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Hang";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription2.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrdsthnd01_s0LG.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription2.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription2);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 3
            FoxEntity effectDescription3 = baseEffectDescription.Copy();
            effectDescription3.Address = address;
            effectDescription3.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription3.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription3.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription3.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Climb";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription3.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrdstwst01_s1LG.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription3.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription3);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 4
            FoxEntity effectDescription4 = baseEffectDescription.Copy();
            effectDescription4.Address = address;
            effectDescription4.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription4.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription4.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription4.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Sandstorm";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription4.staticProperties[6].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "CNP_CHEST";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription4.staticProperties[8].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription4.staticProperties[10].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription4.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_chrsndstm02_s1LG";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription4.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription4);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 5
            FoxEntity effectDescription5 = baseEffectDescription.Copy();
            effectDescription5.Address = address;
            effectDescription5.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription5.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription5.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription5.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "EludeSplashM";
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription5.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_chrdsthndspl01_s0";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription5.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription5);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 6
            FoxEntity effectDescription6 = baseEffectDescription.Copy();
            effectDescription6.Address = address;
            effectDescription6.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription6.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription6.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription6.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "EludeSplashS";
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription6.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_chrdsthndspl02_s0";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription6.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription6);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 7
            FoxEntity effectDescription7 = baseEffectDescription.Copy();
            effectDescription7.Address = address;
            effectDescription7.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription7.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription7.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription7.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "EludeSplashM2";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription7.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription7);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 8
            FoxEntity effectDescription8 = baseEffectDescription.Copy();
            effectDescription8.Address = address;
            effectDescription8.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription8.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription8.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription8.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "EludeSplashS2";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription8.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription8);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 9
            FoxEntity effectDescription9 = baseEffectDescription.Copy();
            effectDescription9.Address = address;
            effectDescription9.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription9.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription9.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription9.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "EmblemFlare";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription9.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_011_LUARM";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription9.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0.1038f;
                vector3.Y = 0.0729f;
                vector3.Z = -0.0256f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription9.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription9.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrdia02_s1.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription9.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription9);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 10
            FoxEntity effectDescription10 = baseEffectDescription.Copy();
            effectDescription10.Address = address;
            effectDescription10.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription10.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription10.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription10.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Knock";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription10.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_012_LFARM";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription10.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0.255f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription10.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription10.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrspkhnd01_s0.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription10.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription10);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 11
            FoxEntity effectDescription11 = baseEffectDescription.Copy();
            effectDescription11.Address = address;
            effectDescription11.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription11.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription11.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription11.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "RainSplash";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription11.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_400_HEADROOT";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_010_LSHLD";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_020_RSHLD";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_011_LUARM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_021_RUARM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_002_CHEST";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_002_CHEST";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_030_LTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_040_RTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_031_LLEG";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_041_RLEG";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_620_ITEM_SIM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_620_ITEM_SIM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_000_WAIST";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_000_WAIST";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_030_LTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_040_RTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_002_CHEST";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_004_HEAD";
                    dynamicArray.values.Add(foxString);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription11.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0;
                    vector3.Y = 0.1f;
                    vector3.Z = 0.03f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0.05f;
                    vector3.Y = -0.02f;
                    vector3.Z = -0.05f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = -0.05f;
                    vector3.Y = -0.02f;
                    vector3.Z = -0.05f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.01f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.01f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0.07f;
                    vector3.Y = 0.09f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = -0.07f;
                    vector3.Y = 0.09f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.07f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.07f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0.08f;
                    vector3.Y = -0.05f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = -0.08f;
                    vector3.Y = -0.05f;
                    vector3.Z = -0.05f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0.05f;
                    vector3.Y = 0.1f;
                    vector3.Z = 0.02f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = -0.05f;
                    vector3.Y = 0.1f;
                    vector3.Z = 0.02f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.25f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.25f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0.2f;
                    vector3.Z = -0.04f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0.02f;
                    vector3.Z = -0.02f;
                    dynamicArray.values.Add(vector3);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription11.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.11f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.11f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.06f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.06f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.11f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.11f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.08f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.08f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.1f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.09f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.09f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.08f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0.08f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription11.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_rinspl00_s0MG";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription11.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription11);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 12
            FoxEntity effectDescription12 = baseEffectDescription.Copy();
            effectDescription12.Address = address;
            effectDescription12.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription12.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription12.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription12.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "RainSplashSoundLeft";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription12.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_011_LUARM";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription12.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0.1f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription12.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription12.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_rinspl00sndl_s0MG";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription12.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription12);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 13
            FoxEntity effectDescription13 = baseEffectDescription.Copy();
            effectDescription13.Address = address;
            effectDescription13.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription13.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription13.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription13.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "RainSplashSoundRight";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription13.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_021_RUARM";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription13.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0.1f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription13.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription13.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_rinspl00sndr_s0MG";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription13.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription13);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 14
            FoxEntity effectDescription14 = baseEffectDescription.Copy();
            effectDescription14.Address = address;
            effectDescription14.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription14.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription14.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription14.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Flare1";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription14.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_004_HEAD";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription14.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0.1f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription14.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0.2f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxInt32> staticArray = effectDescription14.staticProperties[16].Container as FoxStaticArray<FoxInt32>;
                staticArray.values[0].Value = 1;
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription14.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgt24_m1LD.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription14.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription14);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 15
            FoxEntity effectDescription15 = baseEffectDescription.Copy();
            effectDescription15.Address = address;
            effectDescription15.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription15.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription15.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription15.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "DiveSplash";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription15.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_000_WAIST";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription15.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription15.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription15.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrdivspl01_s1.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription15.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription15);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 16
            FoxEntity effectDescription16 = baseEffectDescription.Copy();
            effectDescription16.Address = address;
            effectDescription16.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription16.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription16.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription16.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "DiveRiver";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription16.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_000_WAIST";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription16.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription16.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription16.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrdivspl02_s1.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription16.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription16);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 17
            FoxEntity effectDescription17 = baseEffectDescription.Copy();
            effectDescription17.Address = address;
            effectDescription17.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription17.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription17.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription17.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "Burn";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription17.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_041_RLEG";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_031_LLEG";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_040_RTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_030_LTHIGH";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_021_RUARM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_011_LUARM";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "SKL_000_WAIST";
                    dynamicArray.values.Add(foxString);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription17.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.3f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.3f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.2f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = -0.2f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription17.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                }
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription17.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/fire/fx_tpp_firchr02_s2.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription17.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription17);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 19 (Didn't skip 18. It doesn't exist in ref file.)
            FoxEntity effectDescription19 = baseEffectDescription.Copy();
            effectDescription19.Address = address;
            effectDescription19.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription19.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription19.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription19.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "ChickenHeadFeather";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription19.staticProperties[5].Container as FoxDynamicArray<FoxString>;
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SKL_004_HEAD";
                dynamicArray.values.Add(foxString);
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription19.staticProperties[7].Container as FoxDynamicArray<FoxVector3>;
                FoxVector3 vector3 = new FoxVector3();
                vector3.X = 0f;
                vector3.Y = 0f;
                vector3.Z = 0f;
                dynamicArray.values.Add(vector3);
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription19.staticProperties[9].Container as FoxDynamicArray<FoxVector4>;
                FoxVector4 vector4 = new FoxVector4();
                vector4.X = 0f;
                vector4.Y = 0f;
                vector4.Z = 0f;
                vector4.W = 0f;
                dynamicArray.values.Add(vector4);
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = effectDescription19.staticProperties[19].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = "/Assets/tpp/effect/vfx_data/item/fx_tpp_itmmskwng01_s1.vfx";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription19.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription19);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //EFFECT DESCRIPTION 20
            FoxEntity effectDescription20 = baseEffectDescription.Copy();
            effectDescription20.Address = address;
            effectDescription20.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = effectDescription20.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += effectDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = effectDescription20.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                staticArray.values[0].EntityHandle = modelAddress;
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription20.staticProperties[3].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_chrfotlpb01_s0";
            } //block
            {
                FoxDynamicArray<FoxString> dynamicArray = effectDescription20.staticProperties[6].Container as FoxDynamicArray<FoxString>;
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "CNP_LOW_RHEEL";
                    dynamicArray.values.Add(foxString);
                } //block
                {
                    FoxString foxString = new FoxString();
                    foxString.StringLiteral = new FoxStringLiteral();
                    foxString.StringLiteral.Literal = "CNP_LOW_LHEEL";
                    dynamicArray.values.Add(foxString);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector3> dynamicArray = effectDescription20.staticProperties[8].Container as FoxDynamicArray<FoxVector3>;
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0.15f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
                {
                    FoxVector3 vector3 = new FoxVector3();
                    vector3.X = 0f;
                    vector3.Y = 0.15f;
                    vector3.Z = 0f;
                    dynamicArray.values.Add(vector3);
                } //block
            } //block
            {
                FoxDynamicArray<FoxVector4> dynamicArray = effectDescription20.staticProperties[10].Container as FoxDynamicArray<FoxVector4>;
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
                {
                    FoxVector4 vector4 = new FoxVector4();
                    vector4.X = 0f;
                    vector4.Y = 0f;
                    vector4.Z = 0f;
                    vector4.W = 0f;
                    dynamicArray.values.Add(vector4);
                } //block
            } //block
            {
                FoxStaticArray<FoxString> staticArray = effectDescription20.staticProperties[18].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal = "fx_tpp_chrfotlpb01_s0";
            } //block
            {
                FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                FoxEntityPtr entityPtr = new FoxEntityPtr();
                FoxStaticArray<FoxString> staticArray = effectDescription20.staticProperties[0].Container as FoxStaticArray<FoxString>;
                stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                entityPtr.EntityPtr = address;

                dataList.map.Add(stringLiteral, entityPtr);
            } //block
            foxFile.entities.Add(effectDescription20);
            address += ENTITY_SIZE;
            unknown++;
            effectDescriptionCount++;

            //SIM DESCRIPTIONS
            foreach (Sim sim in outfit.sims)
            {
                FoxEntity simDescription = baseSimDescription.Copy();
                simDescription.Address = address;
                simDescription.Unknown2 = unknown;
                {
                    FoxStaticArray<FoxString> staticArray = simDescription.staticProperties[0].Container as FoxStaticArray<FoxString>;
                    staticArray.values[0].StringLiteral.Literal += simDescriptionCount.ToString("0000");
                } //block
                {
                    FoxDynamicArray<FoxEntityLink> staticArray = simDescription.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                    staticArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                    staticArray.values[0].EntityHandle = modelAddress;
                } //block
                {
                    FoxStaticArray<FoxString> staticArray = simDescription.staticProperties[3].Container as FoxStaticArray<FoxString>;
                    staticArray.values[0].StringLiteral.Literal += sim.name;
                } //block
                {
                    FoxStaticArray<FoxFilePtr> staticArray = simDescription.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                    staticArray.values[0].StringLiteral.Literal = sim.path;
                } //block
                {
                    FoxStaticArray<FoxBool> staticArray = simDescription.staticProperties[6].Container as FoxStaticArray<FoxBool>;
                    staticArray.values[0].Value = sim.isActive;
                } //block
                {
                    FoxStringLookupLiteral stringLiteral = new FoxStringLookupLiteral();
                    FoxEntityPtr entityPtr = new FoxEntityPtr();
                    FoxStaticArray<FoxString> staticArray = simDescription.staticProperties[0].Container as FoxStaticArray<FoxString>;
                    stringLiteral.Literal = staticArray.values[0].StringLiteral.Literal;
                    entityPtr.EntityPtr = address;

                    dataList.map.Add(stringLiteral, entityPtr);
                } //block
                foxFile.entities.Add(simDescription);
                address += ENTITY_SIZE;
                unknown++;
                simDescriptionCount++;
            } //foreach

            return foxFile;
        } //GetFoxFile

        private static void InitializeBaseValues()
        {
            /****************************************************************
             * 
             * CLASSES
             * 
             ****************************************************************/
            classEntity = new FoxClass();
            classEntity.Name = "Entity";
            classEntity.Version = "2";
            classes.Add(classEntity);

            classData = new FoxClass();
            classEntity.Name = "Data";
            classEntity.Super = "Entity";
            classEntity.Version = "2";
            classes.Add(classData);

            classDataSet = new FoxClass();
            classDataSet.Name = "DataSet";
            classDataSet.Version = "0";
            classes.Add(classDataSet);

            classModelDescription = new FoxClass();
            classModelDescription.Name = "ModelDescription";
            classModelDescription.Version = "12";
            classes.Add(classModelDescription);

            classFoxTargetDescription = new FoxClass();
            classFoxTargetDescription.Name = "FoxTargetDescription";
            classFoxTargetDescription.Version = "1";
            classes.Add(classFoxTargetDescription);

            classEffectDescription = new FoxClass();
            classEffectDescription.Name = "EffectDescription";
            classEffectDescription.Version = "6";
            classes.Add(classEffectDescription);

            classSimDescription = new FoxClass();
            classSimDescription.Name = "SimDescription";
            classSimDescription.Version = "1";
            classes.Add(classSimDescription);

            classPhysicsDescription = new FoxClass();
            classPhysicsDescription.Name = "PhysicsDescription";
            classPhysicsDescription.Version = "0";
            classes.Add(classPhysicsDescription);

            classSoundDescription = new FoxClass();
            classSoundDescription.Name = "SoundDescription";
            classSoundDescription.Version = "0";
            classes.Add(classSoundDescription);

            /****************************************************************
             * 
             * ENTITIES
             * 
             ****************************************************************/
            //DATA SET
            baseDataSet = new FoxEntity();
            baseDataSet.ClassName = classDataSet.Name;
            baseDataSet.Version = short.Parse(classDataSet.Version);
            baseDataSet.Address = 0;
            baseDataSet.Unknown1 = DATA_SET_UNKNOWN;
            baseDataSet.Unknown2 = 0;

            baseDataSet.staticProperties = new List<FoxProperty>();

            {
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseDataSet.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = 0x00000000;
                staticArray.values.Add(entityHandle);

                baseDataSet.staticProperties.Add(property);
            } //property block

            { //2
                FoxProperty property = new FoxProperty();
                property.Name = "dataList";
                property.DataType = FoxDataType.FoxEntityPtr;
                property.ContainerType = FoxContainerType.StringMap;
                property.Container = new FoxStringMap<FoxEntityPtr>();

                baseDataSet.staticProperties.Add(property);
            } //property block

            //MODEL DESCRIPTION
            baseModelDescription = new FoxEntity();
            baseModelDescription.ClassName = classModelDescription.Name;
            baseModelDescription.Version = short.Parse(classModelDescription.Version);
            baseModelDescription.Address = 0;
            baseModelDescription.Unknown1 = MODEL_DESCRIPTION_UNKNOWN;
            baseModelDescription.Unknown2 = 0;

            baseModelDescription.staticProperties = new List<FoxProperty>();

            {
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "ModelDescription0000";
                staticArray.values.Add(foxString);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = BASE_ADDRESS;
                staticArray.values.Add(entityHandle);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "depends";
                property.DataType = FoxDataType.FoxEntityLink;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxEntityLink>();

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "partName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "Body";
                staticArray.values.Add(foxString);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "buildType";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            { //5
                FoxProperty property = new FoxProperty();
                property.Name = "modelFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            { //6
                FoxProperty property = new FoxProperty();
                property.Name = "connectPointFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "gameRigFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "/Assets/tpp/rig/frig/human_finger.frig";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            { //8
                FoxProperty property = new FoxProperty();
                property.Name = "helpBoneFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            { 
                FoxProperty property = new FoxProperty();
                property.Name = "lipAdjustBinaryFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "/Assets/tpp/motion/lip_adjust_data/sna0.ladb";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "facialSettingFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "/Assets/tpp/motion/facial_setting_data/tppPlayer.fsd";
                staticArray.values.Add(filePtr);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "invisibleMeshNames";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxString>();

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "lodFarPixelSize";
                property.DataType = FoxDataType.FoxFloat;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFloat>();

                FoxStaticArray<FoxFloat> staticArray = property.Container as FoxStaticArray<FoxFloat>;
                staticArray.values = new List<FoxFloat>();
                FoxFloat foxFloat = new FoxFloat();
                foxFloat.Value = 50f;
                staticArray.values.Add(foxFloat);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "lodNearPixelSize";
                property.DataType = FoxDataType.FoxFloat;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFloat>();

                FoxStaticArray<FoxFloat> staticArray = property.Container as FoxStaticArray<FoxFloat>;
                staticArray.values = new List<FoxFloat>();
                FoxFloat foxFloat = new FoxFloat();
                foxFloat.Value = 400f;
                staticArray.values.Add(foxFloat);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "lodPolygonSize";
                property.DataType = FoxDataType.FoxFloat;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFloat>();

                FoxStaticArray<FoxFloat> staticArray = property.Container as FoxStaticArray<FoxFloat>;
                staticArray.values = new List<FoxFloat>();
                FoxFloat foxFloat = new FoxFloat();
                foxFloat.Value = -1f;
                staticArray.values.Add(foxFloat);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "drawRejectionLevel";
                property.DataType = FoxDataType.FoxInt32;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxInt32>();

                FoxStaticArray<FoxInt32> staticArray = property.Container as FoxStaticArray<FoxInt32>;
                staticArray.values = new List<FoxInt32>();
                FoxInt32 foxInt32 = new FoxInt32();
                foxInt32.Value = 8;
                staticArray.values.Add(foxInt32);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "rejectFarRangeShadowCast";
                property.DataType = FoxDataType.FoxInt32;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxInt32>();

                FoxStaticArray<FoxInt32> staticArray = property.Container as FoxStaticArray<FoxInt32>;
                staticArray.values = new List<FoxInt32>();
                FoxInt32 foxInt32 = new FoxInt32();
                foxInt32.Value = 2;
                staticArray.values.Add(foxInt32);

                baseModelDescription.staticProperties.Add(property);
            } //property block

            //TARGET DESCRIPTION
            baseTargetDescription = new FoxEntity();
            baseTargetDescription.ClassName = classFoxTargetDescription.Name;
            baseTargetDescription.Version = short.Parse(classFoxTargetDescription.Version);
            baseTargetDescription.Address = 0;
            baseTargetDescription.Unknown1 = FOX_TARGET_DESCRIPTION_UNKNOWN;
            baseTargetDescription.Unknown2 = 0;

            baseTargetDescription.staticProperties = new List<FoxProperty>();

            { //0
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "FoxTargetDescription";
                staticArray.values.Add(foxString);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = BASE_ADDRESS;
                staticArray.values.Add(entityHandle);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            { //2
                FoxProperty property = new FoxProperty();
                property.Name = "depends";
                property.DataType = FoxDataType.FoxEntityLink;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxEntityLink>();

                FoxDynamicArray<FoxEntityLink> dynamicArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                dynamicArray.values = new List<FoxEntityLink>();
                FoxEntityLink entityLink = new FoxEntityLink();
                entityLink.PackagePathLiteral = new FoxStringLiteral();
                entityLink.ArchivePathLiteral = new FoxStringLiteral();
                entityLink.NameInArchiveLiteral = new FoxStringLiteral();
                entityLink.PackagePathLiteral.Literal = "";
                entityLink.ArchivePathLiteral.Literal = "";
                entityLink.NameInArchiveLiteral.Literal = "ModelDescription0000";
                entityLink.EntityHandle = 0;
                dynamicArray.values.Add(entityLink);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            { //3
                FoxProperty property = new FoxProperty();
                property.Name = "partName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "buildType";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            { //5
                FoxProperty property = new FoxProperty();
                property.Name = "targetFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseTargetDescription.staticProperties.Add(property);
            } //property block

            //PHYSICS DESCRIPTION
            basePhysicsDescription = new FoxEntity();
            basePhysicsDescription.ClassName = classPhysicsDescription.Name;
            basePhysicsDescription.Version = short.Parse(classPhysicsDescription.Version);
            basePhysicsDescription.Address = 0;
            basePhysicsDescription.Unknown1 = PHYSICS_DESCRIPTION_UNKNOWN;
            basePhysicsDescription.Unknown2 = 0;

            basePhysicsDescription.staticProperties = new List<FoxProperty>();

            {
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "PhysicsDescription0000";
                staticArray.values.Add(foxString);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = BASE_ADDRESS;
                staticArray.values.Add(entityHandle);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            { //2
                FoxProperty property = new FoxProperty();
                property.Name = "depends";
                property.DataType = FoxDataType.FoxEntityLink;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxEntityLink>();

                FoxDynamicArray<FoxEntityLink> dynamicArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                dynamicArray.values = new List<FoxEntityLink>();
                FoxEntityLink entityLink = new FoxEntityLink();
                entityLink.PackagePathLiteral = new FoxStringLiteral();
                entityLink.ArchivePathLiteral = new FoxStringLiteral();
                entityLink.NameInArchiveLiteral = new FoxStringLiteral();
                entityLink.PackagePathLiteral.Literal = "";
                entityLink.ArchivePathLiteral.Literal = "";
                entityLink.NameInArchiveLiteral.Literal = "ModelDescription0000";
                entityLink.EntityHandle = 0;
                dynamicArray.values.Add(entityLink);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "partName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "Ragdoll";
                staticArray.values.Add(foxString);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "buildType";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "physicsFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "/Assets/tpp/parts/chara/sna/sna0_v01.ph";
                staticArray.values.Add(filePtr);

                basePhysicsDescription.staticProperties.Add(property);
            } //property block

            //EFFECT DESCRIPTION
            baseEffectDescription = new FoxEntity();
            baseEffectDescription.ClassName = classEffectDescription.Name;
            baseEffectDescription.Version = short.Parse(classEffectDescription.Version);
            baseEffectDescription.Address = 0;
            baseEffectDescription.Unknown1 = EFFECT_DESCRIPTION_UNKNOWN;
            baseEffectDescription.Unknown2 = 0;

            baseEffectDescription.staticProperties = new List<FoxProperty>();

            { //0
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "EffectDescription";
                staticArray.values.Add(foxString);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = BASE_ADDRESS;
                staticArray.values.Add(entityHandle);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //2
                FoxProperty property = new FoxProperty();
                property.Name = "depends";
                property.DataType = FoxDataType.FoxEntityLink;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxEntityLink>();

                FoxDynamicArray<FoxEntityLink> dynamicArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                dynamicArray.values = new List<FoxEntityLink>();
                FoxEntityLink entityLink = new FoxEntityLink();
                entityLink.PackagePathLiteral = new FoxStringLiteral();
                entityLink.ArchivePathLiteral = new FoxStringLiteral();
                entityLink.NameInArchiveLiteral = new FoxStringLiteral();
                entityLink.PackagePathLiteral.Literal = "";
                entityLink.ArchivePathLiteral.Literal = "";
                entityLink.NameInArchiveLiteral.Literal = "ModelDescription0000";
                entityLink.EntityHandle = 0;
                dynamicArray.values.Add(entityLink);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //3
                FoxProperty property = new FoxProperty();
                property.Name = "partName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            {
                FoxProperty property = new FoxProperty();
                property.Name = "buildType";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //5
                FoxProperty property = new FoxProperty();
                property.Name = "connectDestinationSkelNames";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxString>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //6
                FoxProperty property = new FoxProperty();
                property.Name = "connectDestinationCnpNames";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxString>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //7
                FoxProperty property = new FoxProperty();
                property.Name = "offsetSkelPositions";
                property.DataType = FoxDataType.FoxVector3;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxVector3>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //8
                FoxProperty property = new FoxProperty();
                property.Name = "offsetCnpPositions";
                property.DataType = FoxDataType.FoxVector3;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxVector3>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //9
                FoxProperty property = new FoxProperty();
                property.Name = "generalSkelParameters";
                property.DataType = FoxDataType.FoxVector4;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxVector4>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //10
                FoxProperty property = new FoxProperty();
                property.Name = "generalCnpParameters";
                property.DataType = FoxDataType.FoxVector4;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxVector4>();

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //11
                FoxProperty property = new FoxProperty();
                property.Name = "effectConnect";
                property.DataType = FoxDataType.FoxBool;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxBool>();

                FoxStaticArray<FoxBool> staticArray = property.Container as FoxStaticArray<FoxBool>;
                staticArray.values = new List<FoxBool>();
                FoxBool foxBool = new FoxBool();
                foxBool.Value = true;
                staticArray.values.Add(foxBool);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //12
                FoxProperty property = new FoxProperty();
                property.Name = "changeEffectConnectSetting";
                property.DataType = FoxDataType.FoxBool;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxBool>();

                FoxStaticArray<FoxBool> staticArray = property.Container as FoxStaticArray<FoxBool>;
                staticArray.values = new List<FoxBool>();
                FoxBool foxBool = new FoxBool();
                foxBool.Value = false;
                staticArray.values.Add(foxBool);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //13
                FoxProperty property = new FoxProperty();
                property.Name = "visibleModelWithEffect";
                property.DataType = FoxDataType.FoxBool;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxBool>();

                FoxStaticArray<FoxBool> staticArray = property.Container as FoxStaticArray<FoxBool>;
                staticArray.values = new List<FoxBool>();
                FoxBool foxBool = new FoxBool();
                foxBool.Value = true;
                staticArray.values.Add(foxBool);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //14
                FoxProperty property = new FoxProperty();
                property.Name = "createStartEffect";
                property.DataType = FoxDataType.FoxBool;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxBool>();

                FoxStaticArray<FoxBool> staticArray = property.Container as FoxStaticArray<FoxBool>;
                staticArray.values = new List<FoxBool>();
                FoxBool foxBool = new FoxBool();
                foxBool.Value = false;
                staticArray.values.Add(foxBool);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //15
                FoxProperty property = new FoxProperty();
                property.Name = "effectRandomSeed";
                property.DataType = FoxDataType.FoxUInt32;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxUInt32>();

                FoxStaticArray<FoxUInt32> staticArray = property.Container as FoxStaticArray<FoxUInt32>;
                staticArray.values = new List<FoxUInt32>();
                FoxUInt32 foxUInt32 = new FoxUInt32();
                foxUInt32.Value = 0;
                staticArray.values.Add(foxUInt32);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //16
                FoxProperty property = new FoxProperty();
                property.Name = "effectKind";
                property.DataType = FoxDataType.FoxInt32;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxInt32>();

                FoxStaticArray<FoxInt32> staticArray = property.Container as FoxStaticArray<FoxInt32>;
                staticArray.values = new List<FoxInt32>();
                FoxInt32 foxInt32 = new FoxInt32();
                foxInt32.Value = 0;
                staticArray.values.Add(foxInt32);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //17
                FoxProperty property = new FoxProperty();
                property.Name = "effectVariationName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //18
                FoxProperty property = new FoxProperty();
                property.Name = "effectFileFromVfxFileLoader";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            { //19
                FoxProperty property = new FoxProperty();
                property.Name = "effectFileFromFilePtr";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseEffectDescription.staticProperties.Add(property);
            } //property block

            //SIM DESCRIPTION
            baseSimDescription = new FoxEntity();
            baseSimDescription.ClassName = classSimDescription.Name;
            baseSimDescription.Version = short.Parse(classSimDescription.Version);
            baseSimDescription.Address = 0;
            baseSimDescription.Unknown1 = SIM_DESCRIPTION_UNKNOWN;
            baseSimDescription.Unknown2 = 0;

            baseSimDescription.staticProperties = new List<FoxProperty>();

            { //0
                FoxProperty property = new FoxProperty();
                property.Name = "name";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "SimDescription";
                staticArray.values.Add(foxString);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //1
                FoxProperty property = new FoxProperty();
                property.Name = "dataSet";
                property.DataType = FoxDataType.FoxEntityHandle;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxEntityHandle>();

                FoxStaticArray<FoxEntityHandle> staticArray = property.Container as FoxStaticArray<FoxEntityHandle>;
                staticArray.values = new List<FoxEntityHandle>();
                FoxEntityHandle entityHandle = new FoxEntityHandle();
                entityHandle.Handle = BASE_ADDRESS;
                staticArray.values.Add(entityHandle);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //2
                FoxProperty property = new FoxProperty();
                property.Name = "depends";
                property.DataType = FoxDataType.FoxEntityLink;
                property.ContainerType = FoxContainerType.DynamicArray;
                property.Container = new FoxDynamicArray<FoxEntityLink>();

                FoxDynamicArray<FoxEntityLink> dynamicArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                dynamicArray.values = new List<FoxEntityLink>();
                FoxEntityLink entityLink = new FoxEntityLink();
                entityLink.PackagePathLiteral = new FoxStringLiteral();
                entityLink.ArchivePathLiteral = new FoxStringLiteral();
                entityLink.NameInArchiveLiteral = new FoxStringLiteral();
                entityLink.PackagePathLiteral.Literal = "";
                entityLink.ArchivePathLiteral.Literal = "";
                entityLink.NameInArchiveLiteral.Literal = "ModelDescription0000";
                entityLink.EntityHandle = 0;
                dynamicArray.values.Add(entityLink);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //3
                FoxProperty property = new FoxProperty();
                property.Name = "partName";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //4
                FoxProperty property = new FoxProperty();
                property.Name = "buildType";
                property.DataType = FoxDataType.FoxString;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxString>();

                FoxStaticArray<FoxString> staticArray = property.Container as FoxStaticArray<FoxString>;
                staticArray.values = new List<FoxString>();
                FoxString foxString = new FoxString();
                foxString.StringLiteral = new FoxStringLiteral();
                foxString.StringLiteral.Literal = "";
                staticArray.values.Add(foxString);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //5
                FoxProperty property = new FoxProperty();
                property.Name = "simFile";
                property.DataType = FoxDataType.FoxFilePtr;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxFilePtr>();

                FoxStaticArray<FoxFilePtr> staticArray = property.Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values = new List<FoxFilePtr>();
                FoxFilePtr filePtr = new FoxFilePtr();
                filePtr.StringLiteral = new FoxStringLiteral();
                filePtr.StringLiteral.Literal = "";
                staticArray.values.Add(filePtr);

                baseSimDescription.staticProperties.Add(property);
            } //property block

            { //6
                FoxProperty property = new FoxProperty();
                property.Name = "isActive";
                property.DataType = FoxDataType.FoxBool;
                property.ContainerType = FoxContainerType.StaticArray;
                property.Container = new FoxStaticArray<FoxBool>();

                FoxStaticArray<FoxBool> staticArray = property.Container as FoxStaticArray<FoxBool>;
                staticArray.values = new List<FoxBool>();
                FoxBool foxBool = new FoxBool();
                foxBool.Value = true;
                staticArray.values.Add(foxBool);

                baseSimDescription.staticProperties.Add(property);
            } //property block
        } //InitializeBaseEntities
    } //class
} //namespace
