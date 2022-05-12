using FoxTool.Fox;
using FoxTool.Fox.Containers;
using FoxTool.Fox.Types;
using FoxTool.Fox.Types.Structs;
using FoxTool.Fox.Types.Values;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        static PartsConverter()
        {
            InitializeBaseValues();
        } //constructor

        public static FoxFile GetFoxFile(string modelPath, string partsPath)
        {
            uint address = BASE_ADDRESS;
            int unknown = 37243;
            uint modelAddress;
            uint physicsAddress;
            FoxStringMap<FoxEntityPtr> dataList;

            int targetDescriptionCount = 0;

            FoxFile foxFile = new FoxFile();
            foxFile.classes = classes;
            foxFile.entities = new List<FoxEntity>();

            //DATA SET
            FoxEntity dataSet = baseDataSet;
            dataSet.Address = address;
            dataSet.Unknown2 = unknown;
            dataList = dataSet.staticProperties[2].Container as FoxStringMap<FoxEntityPtr>;
            foxFile.entities.Add(dataSet);
            address += ENTITY_SIZE;
            unknown++;

            //MODEL DESCRIPTION
            FoxEntity modelDescription = baseModelDescription;
            modelDescription.Address = address;
            modelDescription.Unknown2 = unknown;
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[5].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = $"{modelPath}.fmdl";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[6].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = $"{modelPath}.fcnp";
            } //block
            {
                FoxStaticArray<FoxFilePtr> staticArray = modelDescription.staticProperties[8].Container as FoxStaticArray<FoxFilePtr>;
                staticArray.values[0].StringLiteral.Literal = $"{modelPath}.frdv";
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
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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

            //TARGET DESCRIPTION 4
            FoxEntity targetDescription4 = baseTargetDescription.Copy();
            targetDescription4.Address = address;
            targetDescription4.Unknown2 = unknown;
            {
                FoxStaticArray<FoxString> staticArray = targetDescription4.staticProperties[0].Container as FoxStaticArray<FoxString>;
                staticArray.values[0].StringLiteral.Literal += targetDescriptionCount.ToString("0000");
            } //block
            {
                FoxDynamicArray<FoxEntityLink> staticArray = targetDescription4.staticProperties[2].Container as FoxDynamicArray<FoxEntityLink>;
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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
            targetDescriptionCount++;

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
                staticArray.values[0].ArchivePathLiteral.Literal = $"{partsPath}.parts";
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
                filePtr.StringLiteral.Literal = "";
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
        } //InitializeBaseEntities
    } //class
} //namespace
