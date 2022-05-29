using FoxTool.Fox;
using FoxTool.Fox.Containers;
using FoxTool.Fox.Types;
using FoxTool.Fox.Types.Structs;
using FoxTool.Fox.Types.Values;
using GzsTool.Core.Utility;
using MQPMTool2.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MQPMTool2.Static
{
    public static class PartsConverter
    {
        private const uint ENTITY_SIZE = 0x70;
        private const string SIM_DESCRIPTION_CLASS_NAME = "SimDescription";

        private static Dictionary<ulong, string> GlobalHashNameDictionary = new Dictionary<ulong, string>();
        private static FoxLookupTable lookupTable;

        static PartsConverter()
        {
            ReadDictionary();
            lookupTable = new FoxLookupTable(GlobalHashNameDictionary);
        } //constructor

        private static void ReadDictionary()
        {
            string dictionaryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "fox_dictionary.txt");

            foreach (string line in File.ReadAllLines(dictionaryPath))
            {
                ulong hash = Hashing.HashFileName(line);

                if (!GlobalHashNameDictionary.ContainsKey(hash))
                    GlobalHashNameDictionary.Add(hash, line);
            } //foreach
        } //ReadDictionary

        public static FoxFile GetFoxFile(Parts parts, Outfit outfit)
        {
            uint baseAddress = 0;
            uint address = 0;
            int unknown = 0;
            uint modelDescriptionAddress = 0;
            string modelDescriptionName = "";
            uint physicsDescriptionAddress = 0;
            string physicsDescriptionName = "";
            FoxStringMap<FoxEntityPtr> dataList = new FoxStringMap<FoxEntityPtr>();

            int simDescriptionCount = 0;

            FoxFile foxFile = new FoxFile();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), parts.partsPath.Substring(1));
            Console.WriteLine(path);

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    foxFile = FoxFile.ReadFoxFile(stream, lookupTable);
                } //try
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                } //catch
                finally
                {
                    stream.Close();
                } //finally
            } //using

            //Remove original sim entries.
            List<FoxEntity> removeList = new List<FoxEntity>();

            foreach(FoxEntity entity in foxFile.entities)
                if(entity.ClassName == SIM_DESCRIPTION_CLASS_NAME)
                    removeList.Add(entity);

            foreach(FoxEntity entity in removeList)
                foxFile.entities.Remove(entity);

            //Modify old entries.
            foreach(FoxEntity entity in foxFile.entities)
            {
                switch(entity.ClassName)
                {
                    case "DataSet":
                        baseAddress = entity.Address;
                        address = baseAddress;
                        unknown = entity.Unknown2;

                        foreach(FoxProperty property in entity.staticProperties)
                        {
                            if(property.Name == "dataList")
                            {
                                dataList = property.Container as FoxStringMap<FoxEntityPtr>;
                                dataList.map.Clear();
                                break;
                            } //if
                        } //foreach

                        address += ENTITY_SIZE;
                        unknown++;
                        break;
                    case "ModelDescription":
                        entity.Address = address;
                        entity.Unknown2 = unknown;
                        modelDescriptionAddress = address;

                        foreach (FoxProperty property in entity.staticProperties)
                        {
                            switch(property.Name)
                            {
                                case "name":
                                    FoxStaticArray<FoxString> nameArray = property.Container as FoxStaticArray<FoxString>;
                                    modelDescriptionName =  nameArray.values[0].StringLiteral.Literal;
                                    break;
                                case "dataSet":
                                    FoxStaticArray<FoxEntityHandle> dataSetArrary = property.Container as FoxStaticArray<FoxEntityHandle>;
                                    dataSetArrary.values[0].Handle = baseAddress;
                                    break;
                                case "modelFile":
                                    FoxStaticArray<FoxFilePtr> modelFileArray = property.Container as FoxStaticArray<FoxFilePtr>;
                                    modelFileArray.values[0].StringLiteral.Literal = outfit.mdlPath;
                                    break;
                                case "connectPointFile":
                                    FoxStaticArray<FoxFilePtr> connectPointFileArray = property.Container as FoxStaticArray<FoxFilePtr>;
                                    connectPointFileArray.values[0].StringLiteral.Literal = outfit.cnpPath;
                                    break;
                                case "helpBoneFile":
                                    FoxStaticArray<FoxFilePtr> helpBoneFileArray = property.Container as FoxStaticArray<FoxFilePtr>;
                                    helpBoneFileArray.values[0].StringLiteral.Literal = outfit.rdvPath;
                                    break;
                            } //switch
                        } //foreach

                        FoxEntityPtr modelDescriptionEntityPtr = new FoxEntityPtr();
                        modelDescriptionEntityPtr.EntityPtr = address;
                        FoxStringLookupLiteral modelDescriptionStringLookupLiteral = new FoxStringLookupLiteral();
                        modelDescriptionStringLookupLiteral.Literal = modelDescriptionName;
                        dataList.map.Add(modelDescriptionStringLookupLiteral, modelDescriptionEntityPtr);

                        address += ENTITY_SIZE;
                        unknown++;
                        break;
                    case "PhysicsDescription":
                        entity.Address = address;
                        entity.Unknown2 = unknown;
                        physicsDescriptionAddress = address;

                        foreach (FoxProperty property in entity.staticProperties)
                        {
                            switch (property.Name)
                            {
                                case "name":
                                    FoxStaticArray<FoxString> nameArray = property.Container as FoxStaticArray<FoxString>;
                                    physicsDescriptionName = nameArray.values[0].StringLiteral.Literal;
                                    break;
                                case "dataSet":
                                    FoxStaticArray<FoxEntityHandle> dataSetArrary = property.Container as FoxStaticArray<FoxEntityHandle>;
                                    dataSetArrary.values[0].Handle = baseAddress;
                                    break;
                                case "depends":
                                    FoxDynamicArray<FoxEntityLink> dependsArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                                    dependsArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                                    dependsArray.values[0].NameInArchiveLiteral.Literal = modelDescriptionName;
                                    dependsArray.values[0].EntityHandle = modelDescriptionAddress;
                                    break;
                            } //switch
                        } //foreach

                        FoxEntityPtr physicsDescriptionEntityPtr = new FoxEntityPtr();
                        physicsDescriptionEntityPtr.EntityPtr = address;
                        FoxStringLookupLiteral physicsDescriptionStringLookupLiteral = new FoxStringLookupLiteral();
                        physicsDescriptionStringLookupLiteral.Literal = physicsDescriptionName;
                        dataList.map.Add(physicsDescriptionStringLookupLiteral, physicsDescriptionEntityPtr);

                        address += ENTITY_SIZE;
                        unknown++;
                        break;
                    case "SoundDescription":
                        entity.Address = address;
                        entity.Unknown2 = unknown;

                        string soundDescriptionName = "";

                        foreach (FoxProperty property in entity.staticProperties)
                        {
                            switch (property.Name)
                            {
                                case "name":
                                    FoxStaticArray<FoxString> nameArray = property.Container as FoxStaticArray<FoxString>;
                                    soundDescriptionName = nameArray.values[0].StringLiteral.Literal;
                                    break;
                                case "dataSet":
                                    FoxStaticArray<FoxEntityHandle> dataSetArrary = property.Container as FoxStaticArray<FoxEntityHandle>;
                                    dataSetArrary.values[0].Handle = baseAddress;
                                    break;
                                case "depends":
                                    FoxDynamicArray<FoxEntityLink> dependsArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                                    dependsArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                                    dependsArray.values[0].NameInArchiveLiteral.Literal = physicsDescriptionName;
                                    dependsArray.values[0].EntityHandle = physicsDescriptionAddress;
                                    break;
                            } //switch
                        } //foreach

                        FoxEntityPtr soundDescriptionEntityPtr = new FoxEntityPtr();
                        soundDescriptionEntityPtr.EntityPtr = address;
                        FoxStringLookupLiteral soundDescriptionStringLookupLiteral = new FoxStringLookupLiteral();
                        soundDescriptionStringLookupLiteral.Literal = soundDescriptionName;
                        dataList.map.Add(soundDescriptionStringLookupLiteral, soundDescriptionEntityPtr);

                        address += ENTITY_SIZE;
                        unknown++;
                        break;
                    default:
                        entity.Address = address;
                        entity.Unknown2 = unknown;

                        string defaultName = "";

                        foreach (FoxProperty property in entity.staticProperties)
                        {
                            switch (property.Name)
                            {
                                case "name":
                                    FoxStaticArray<FoxString> nameArray = property.Container as FoxStaticArray<FoxString>;
                                    defaultName = nameArray.values[0].StringLiteral.Literal;
                                    break;
                                case "dataSet":
                                    FoxStaticArray<FoxEntityHandle> dataSetArrary = property.Container as FoxStaticArray<FoxEntityHandle>;
                                    dataSetArrary.values[0].Handle = baseAddress;
                                    break;
                                case "depends":
                                    FoxDynamicArray<FoxEntityLink> dependsArray = property.Container as FoxDynamicArray<FoxEntityLink>;
                                    dependsArray.values[0].ArchivePathLiteral.Literal = parts.partsPath;
                                    dependsArray.values[0].NameInArchiveLiteral.Literal = modelDescriptionName;
                                    dependsArray.values[0].EntityHandle = modelDescriptionAddress;
                                    break;
                            } //switch
                        } //foreach

                        FoxEntityPtr defaultEntityPtr = new FoxEntityPtr();
                        defaultEntityPtr.EntityPtr = address;
                        FoxStringLookupLiteral defaultStringLookupLiteral = new FoxStringLookupLiteral();
                        defaultStringLookupLiteral.Literal = defaultName;
                        dataList.map.Add(defaultStringLookupLiteral, defaultEntityPtr);

                        address += ENTITY_SIZE;
                        unknown++;
                        break;
                } //switch
            } //foreach

            foreach(Sim sim in outfit.sims)
            {
                FoxEntity entity = new FoxEntity();
                entity.ClassName = SIM_DESCRIPTION_CLASS_NAME;
                entity.Version = 1;
                entity.Address = address;
                entity.Unknown1 = 120;
                entity.Unknown2 = unknown;
                entity.staticProperties = new List<FoxProperty>();

                //Name
                FoxProperty name = new FoxProperty();
                name.Name = "name";
                name.DataType = FoxDataType.FoxString;
                name.ContainerType = FoxContainerType.StaticArray;
                name.Container = new FoxStaticArray<FoxString>();
                FoxStaticArray<FoxString> nameArray = name.Container as FoxStaticArray<FoxString>;
                nameArray.values = new List<FoxString>();

                FoxString nameValue = new FoxString();
                nameValue.StringLiteral = new FoxStringLiteral();
                nameValue.StringLiteral.Literal = $"SimDescription{simDescriptionCount.ToString("0000")}";
                nameArray.values.Add(nameValue);
                entity.staticProperties.Add(name);

                //DataSet
                FoxProperty dataSet = new FoxProperty();
                dataSet.Name = "dataSet";
                dataSet.DataType = FoxDataType.FoxEntityHandle;
                dataSet.ContainerType = FoxContainerType.StaticArray;
                dataSet.Container = new FoxStaticArray<FoxEntityHandle>();
                FoxStaticArray<FoxEntityHandle> dataSetArray = dataSet.Container as FoxStaticArray<FoxEntityHandle>;
                dataSetArray.values = new List<FoxEntityHandle>();

                FoxEntityHandle dataSetValue = new FoxEntityHandle();
                dataSetValue.Handle = baseAddress;
                dataSetArray.values.Add(dataSetValue);
                entity.staticProperties.Add(dataSet);

                //Depends
                FoxProperty depends = new FoxProperty();
                depends.Name = "depends";
                depends.DataType = FoxDataType.FoxEntityLink;
                depends.ContainerType = FoxContainerType.DynamicArray;
                depends.Container = new FoxDynamicArray<FoxEntityLink>();
                FoxDynamicArray<FoxEntityLink> dependsArray = depends.Container as FoxDynamicArray<FoxEntityLink>;
                dependsArray.values = new List<FoxEntityLink>();

                FoxEntityLink dependsValue = new FoxEntityLink();
                dependsValue.PackagePathLiteral = new FoxStringLiteral();
                dependsValue.PackagePathLiteral.Literal = "";
                dependsValue.ArchivePathLiteral = new FoxStringLiteral();
                dependsValue.ArchivePathLiteral.Literal = parts.partsPath;
                dependsValue.NameInArchiveLiteral = new FoxStringLiteral();
                dependsValue.NameInArchiveLiteral.Literal = modelDescriptionName;
                dependsValue.EntityHandle = modelDescriptionAddress;
                dependsArray.values.Add(dependsValue);
                entity.staticProperties.Add(depends);

                //PartName
                FoxProperty partName = new FoxProperty();
                partName.Name = "partName";
                partName.DataType = FoxDataType.FoxString;
                partName.ContainerType = FoxContainerType.StaticArray;
                partName.Container = new FoxStaticArray<FoxString>();
                FoxStaticArray<FoxString> partNameArray = partName.Container as FoxStaticArray<FoxString>;
                partNameArray.values = new List<FoxString>();

                FoxString partNameValue = new FoxString();
                partNameValue.StringLiteral = new FoxStringLiteral();
                partNameValue.StringLiteral.Literal = sim.name;
                partNameArray.values.Add(partNameValue);
                entity.staticProperties.Add(partName);

                //BuildType
                FoxProperty buildType = new FoxProperty();
                buildType.Name = "buildType";
                buildType.DataType = FoxDataType.FoxString;
                buildType.ContainerType = FoxContainerType.StaticArray;
                buildType.Container = new FoxStaticArray<FoxString>();
                FoxStaticArray<FoxString> buildTypeArray = buildType.Container as FoxStaticArray<FoxString>;
                buildTypeArray.values = new List<FoxString>();

                FoxString buildTypeValue = new FoxString();
                buildTypeValue.StringLiteral = new FoxStringLiteral();
                buildTypeValue.StringLiteral.Literal = "";
                buildTypeArray.values.Add(buildTypeValue);
                entity.staticProperties.Add(buildType);

                //SimFile
                FoxProperty simFile = new FoxProperty();
                simFile.Name = "simFile";
                simFile.DataType = FoxDataType.FoxFilePtr;
                simFile.ContainerType = FoxContainerType.StaticArray;
                simFile.Container = new FoxStaticArray<FoxFilePtr>();
                FoxStaticArray<FoxFilePtr> simFileArray = simFile.Container as FoxStaticArray<FoxFilePtr>;
                simFileArray.values = new List<FoxFilePtr>();

                FoxFilePtr simFileValue = new FoxFilePtr();
                simFileValue.StringLiteral = new FoxStringLiteral();
                simFileValue.StringLiteral.Literal = sim.path;
                simFileArray.values.Add(simFileValue);
                entity.staticProperties.Add(simFile);

                //IsActive
                FoxProperty isActive = new FoxProperty();
                isActive.Name = "isActive";
                isActive.DataType = FoxDataType.FoxBool;
                isActive.ContainerType = FoxContainerType.StaticArray;
                isActive.Container = new FoxStaticArray<FoxBool>();
                FoxStaticArray<FoxBool> isActiveArray = isActive.Container as FoxStaticArray<FoxBool>;
                isActiveArray.values = new List<FoxBool>();

                FoxBool isActiveValue = new FoxBool();
                isActiveValue.Value = sim.isActive;
                isActiveArray.values.Add(isActiveValue);
                entity.staticProperties.Add(isActive);

                foxFile.entities.Add(entity);

                FoxEntityPtr simEntityPtr = new FoxEntityPtr();
                simEntityPtr.EntityPtr = address;
                FoxStringLookupLiteral simStringLookupLiteral = new FoxStringLookupLiteral();
                simStringLookupLiteral.Literal = nameValue.StringLiteral.Literal;
                dataList.map.Add(simStringLookupLiteral, simEntityPtr);
                
                address += ENTITY_SIZE;
                unknown++;
                simDescriptionCount++;
            } //foreach

            return foxFile;
        } //GetFoxFile
    } //class
} //namespace
