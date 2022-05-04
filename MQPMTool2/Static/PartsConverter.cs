namespace MQPMTool2.Static
{
    using System;
    using System.Collections.Generic;
    using Xml2CSharp;

    public static class PartsConverter
    {
        const short ENTITY_SIZE = 0x70;
        const short DATA_SET_UNKNOWN1 = 232;
        const short MODEL_DESCRIPTION_UNKNOWN1 = 288;
        const short SIM_DESCRIPTION_UNKNOWN1 = 120;
        const short FOX_TARGET_DESCRIPTION_UNKNOWN1 = 112;
        const short EFFECT_DESCRIPTION_UNKNOWN1 = 232;
        const short PHYSICS_DESCRIPTION_UNKNOWN1 = 112;

        public static Fox ConvertToFox()
        {
            uint addr = 0x067B4FB0;
            int unknown2 = 37243;

            List<Entity> entities = new List<Entity>(0);

            Fox fox = new Fox();
            fox.FormatVersion = "2";
            fox.FileVersion = "0";
            fox.OriginalVersion = DateTime.Now.ToString();

            fox.Classes = new Classes();
            fox.Classes.Class = new List<Class>(0);

            Class entityCls = new Class();
            entityCls.Name = "Entity";
            entityCls.Super = "";
            entityCls.Version = "2";
            fox.Classes.Class.Add(entityCls);

            Class dataCls = new Class();
            dataCls.Name = "Data";
            dataCls.Super = "Entity";
            dataCls.Version = "2";
            fox.Classes.Class.Add(dataCls);

            Class dataSetCls = new Class();
            dataSetCls.Name = "DataSet";
            dataSetCls.Super = "";
            dataSetCls.Version = "0";
            fox.Classes.Class.Add(dataSetCls);

            Class modelDescriptionCls = new Class();
            modelDescriptionCls.Name = "ModelDescription";
            modelDescriptionCls.Super = "";
            modelDescriptionCls.Version = "12";
            fox.Classes.Class.Add(modelDescriptionCls);

            Class simDescriptionCls = new Class();
            simDescriptionCls.Name = "SimDescription";
            simDescriptionCls.Super = "";
            simDescriptionCls.Version = "1";
            fox.Classes.Class.Add(simDescriptionCls);

            Class foxTargetDescriptionCls = new Class();
            foxTargetDescriptionCls.Name = "FoxTargetDescription";
            foxTargetDescriptionCls.Super = "";
            foxTargetDescriptionCls.Version = "1";
            fox.Classes.Class.Add(foxTargetDescriptionCls);

            Class effectDescriptionCls = new Class();
            effectDescriptionCls.Name = "EffectDescription";
            effectDescriptionCls.Super = "";
            effectDescriptionCls.Version = "6";
            fox.Classes.Class.Add(effectDescriptionCls);

            Class physicsDescriptionCls = new Class();
            physicsDescriptionCls.Name = "PhysicsDescription";
            physicsDescriptionCls.Super = "";
            physicsDescriptionCls.Version = "0";
            fox.Classes.Class.Add(physicsDescriptionCls);

            fox.Entities = new Entities();
            fox.Entities.Entity = new List<Entity>(0);

            Entity dataSetEntity = new Entity();
            dataSetEntity.Class = dataSetCls.Name;
            dataSetEntity.ClassVersion = dataSetCls.Version;
            dataSetEntity.Addr = $"0x{addr.ToString("x")}";
            dataSetEntity.Unknown1 = DATA_SET_UNKNOWN1.ToString();
            dataSetEntity.Unknown2 = unknown2.ToString();

            dataSetEntity.StaticProperties = new StaticProperties();
            dataSetEntity.StaticProperties.Property = new List<Property>(0);

            {
                Property property = new Property();
                property.Name = "name";
                property.Type = "String";
                property.Container = "StaticArray";
                property.ArraySize = "1";
                property.Value = new List<Value>(0);

                Value value = new Value();
                value.Text = "";
                property.Value.Add(value);

                dataSetEntity.StaticProperties.Property.Add(property);
            } //block

            {
                Property property = new Property();
                property.Name = "dataSet";
                property.Type = "EntityHandle";
                property.Container = "StaticArray";
                property.ArraySize = "1";
                property.Value = new List<Value>(0);

                Value value = new Value();
                value.Text = "0x00000000";
                property.Value.Add(value);

                dataSetEntity.StaticProperties.Property.Add(property);
            } //block

            Property dataListProperty = new Property();
            dataListProperty.Name = "dataList";
            dataListProperty.Type = "EntityPtr";
            dataListProperty.Container = "StringMap";
            dataListProperty.Value = new List<Value>(0);

            {
                addr += (uint)ENTITY_SIZE;
                unknown2 += 1;

                Entity entity = new Entity();
                entity.Class = modelDescriptionCls.Name;
                entity.ClassVersion = modelDescriptionCls.Version;
                entity.Addr = $"0x{addr.ToString("x")}";
                entity.Unknown1 = MODEL_DESCRIPTION_UNKNOWN1.ToString();
                entity.Unknown2 = unknown2.ToString();

                entity.StaticProperties = new StaticProperties();
                entity.StaticProperties.Property = new List<Property>(0);

                {
                    Property property = new Property();
                    property.Name = "name";
                    property.Type = "String";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "ModelDescription0000";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "dataSet";
                    property.Type = "EntityHandle";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = dataSetEntity.Addr;

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "depends";
                    property.Type = "EntityLink";
                    property.Container = "DynamicArray";

                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "partName";
                    property.Type = "String";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "Body";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "buildType";
                    property.Type = "String";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "modelFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/chara/sna/Scenes/sna0_main0_def.fmdl";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "connectPointFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/chara/sna/Scenes/sna0_main0_def.fcnp";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "gameRigFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/rig/frig/human_finger.frig";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "helpBoneFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/chara/sna/Scenes/sna0_main0_def.frdv";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "lipAdjustBinaryFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/motion/lip_adjust_data/sna0.ladb";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "facialSettingFile";
                    property.Type = "FilePtr";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "/Assets/tpp/motion/facial_setting_data/tppPlayer.fsd";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "invisibleMeshNames";
                    property.Type = "String";
                    property.Container = "DynamicArray";

                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "lodFarPixelSize";
                    property.Type = "float";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "50";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "lodNearPixelSize";
                    property.Type = "float";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "400";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "lodPolygonSize";
                    property.Type = "float";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "-1";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "drawRejectionLevel";
                    property.Type = "int32";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "8";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                {
                    Property property = new Property();
                    property.Name = "drawRejectionLevel";
                    property.Type = "int32";
                    property.Container = "StaticArray";
                    property.ArraySize = "1";

                    property.Value = new List<Value>(0);

                    Value value = new Value();
                    value.Text = "2";

                    property.Value.Add(value);
                    entity.StaticProperties.Property.Add(property);
                } //block

                Value entityValue = new Value();
                entityValue.Key = entity.StaticProperties.Property.Find(x => x.Name == "name").Value[0].Text;
                entityValue.Text = entity.Addr;

                dataListProperty.Value.Add(entityValue);
                entities.Add(entity);
            } //block

            //DO AFTER EVERYTHING ELSE!
            dataListProperty.ArraySize = dataListProperty.Value.Count.ToString();
            dataSetEntity.StaticProperties.Property.Add(dataListProperty);

            fox.Entities.Entity.Add(dataSetEntity);

            foreach(Entity entity in entities)
            {
                fox.Entities.Entity.Add(entity);
            } //foreach

            return fox;
        } //ConvertToFox
    } //class
}
