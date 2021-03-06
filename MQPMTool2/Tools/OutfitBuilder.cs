﻿using GzsTool.Core.Pftxs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MQPMTool2
{
    public static class OutfitBuilder
    {
        private enum OutfitType
        {
            HEAD_ARM,
            HEAD_NO_ARM,
            NO_HEAD_ARM,
            NO_HEAD_NO_ARM
        } //enum OutfitType ends

        private struct Outfit
        {
            public string name;
            public string outfitPath;
            public string fcnpPath;
            public string frdvPath;
            public string simPath;
            public string simPath2;
            public int outfitType;
        } //struct Outfit ends

        static List<Outfit> outfits = new List<Outfit>(0);

        /*
         * Build
         * Puts together the outfits using the specified pieces into a SnakeBite ready folder.
         */
        public static void Build(string outputPath, string character, string playerOutfit, string characterOutfit, string characterHead, List<string> characterHeadValues, string fcnp, List<string> sims, bool includeOutfitPftxs, bool useBody, List<string> extraList, bool includeHeadPftxs, bool useFv2)
        {
            string playerOutfitName = "";
            string fpkOutputPath = "";
            string fpkdOutputPath = "";
            string fv2Path = "";
            string headPath = "";
            bool isArmBody = false;
            List<string> arm = new List<string>(0);
            List<string> armFrdv = new List<string>(0);
            Outfit outfit = new Outfit();

            string[] faceFv2Values = { "2BEC9C7EE5A3A284", "8766FD743C88A084", "38EB424C72BDA384", "", "5F7E60E40985A284", "FCFFD59AEF2FA384", "425AEAA188A5A284" };

            GetOutfits(); //load the list of outfits.

            //determine the outfit path, fpk path and fpkd path.
            if (character == "snake")
            {
                headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";

                switch (playerOutfit)
                {
                    case "dla0":
                        playerOutfitName = "plparts_dla0_main0_def_v00";
                        break;
                    case "dla1":
                        playerOutfitName = "plparts_dla1_main0_def_v00";
                        break;
                    case "dlb0":
                        playerOutfitName = "plparts_dlb0_main0_def_v00";
                        break;
                    case "dld0":
                        playerOutfitName = "plparts_dld0_main0_def_v00";
                        break;
                    default:
                        playerOutfitName = "plparts_" + playerOutfit;
                        break;
                } //switch ends
            } //if ends
            else if (character == "female")
            {
                headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";

                switch (playerOutfit)
                {
                    case "normal":
                        playerOutfitName = "plparts_dd_female";
                        break;
                    case "dlc0":
                        playerOutfitName = "plparts_dlc0_plyf0_def_v00";
                        break;
                    case "dlc1":
                        playerOutfitName = "plparts_dlc1_plyf0_def_v00";
                        break;
                    case "dle0":
                        playerOutfitName = "plparts_dle0_plyf0_def_v00";
                        break;
                    case "dle1":
                        playerOutfitName = "plparts_dle1_plyf0_def_v00";
                        break;
                    default:
                        playerOutfitName = "plparts_ddf_" + playerOutfit;
                        break;
                } //switch ends
            } //else if ends
            else
            {
                headPath = @"\Assets\tpp\chara\dds\Scenes\dds5_head_z_cov.fmdl";

                switch (playerOutfit)
                {
                    case "normal":
                        playerOutfitName = "plparts_dd_male";
                        break;
                    case "dla0":
                        playerOutfitName = "plparts_dla0_plym0_def_v00";
                        break;
                    case "dla1":
                        playerOutfitName = "plparts_dla1_plym0_def_v00";
                        break;
                    case "dlb0":
                        playerOutfitName = "plparts_dlb0_plym0_def_v00";
                        break;
                    case "dld0":
                        playerOutfitName = "plparts_dld0_plym0_def_v00";
                        break;
                    default:
                        playerOutfitName = "plparts_ddm_" + playerOutfit;
                        break;
                } //switch ends
            } //else ends

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";
            fpkdOutputPath = fpkOutputPath + "d";
            fv2Path = fpkOutputPath + @"\Assets\tpp\fova\chara\sna";

            //find the outfit to output to.
            for (int i = 0; i < outfits.Count; i++)
                if (outfits[i].name == playerOutfitName)
                    outfit = outfits[i];

            //create the output path and copy the .fcnp there.
            Directory.CreateDirectory(Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath));
            Directory.CreateDirectory(Path.GetDirectoryName(fpkOutputPath + outfit.fcnpPath));
            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fcnp\" + fcnp + ".fcnp", fpkOutputPath + outfit.fcnpPath, true);

            //if the outfit needs a .pftxs, copy it over.
            if (includeOutfitPftxs)
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\pftxs\" + characterOutfit + ".pftxs", Path.GetDirectoryName(fpkOutputPath) + "\\" + playerOutfitName + ".pftxs", true);

            //if the head needs a .pftxs copy it over.
            if (includeHeadPftxs)
            {
                //if there's no outfit .pftxs, copy the head one. otherwise, merge the .pftxs files.
                if (!includeOutfitPftxs)
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\pftxs\" + characterHead + ".pftxs", outputPath + ".pftxs", true);
                else if (characterOutfit != characterHead)
                {
                    string mainPftxs = outputPath + ".pftxs";
                    string outputFolder = outputPath + "_pftxs";
                    string extraPftxs = Path.GetDirectoryName(outputPath) + "\\" + characterHead + ".pftxs";

                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\pftxs\" + characterHead + ".pftxs", extraPftxs, true);

                    ArchiveHandler.ExtractArchive<PftxsFile>(mainPftxs, outputFolder);
                    ArchiveHandler.ExtractArchive<PftxsFile>(extraPftxs, outputFolder);
                    ArchiveHandler.WritePftxsArchive(mainPftxs, outputFolder);

                    File.Delete(extraPftxs);
                    DeleteDirectory(outputFolder);
                } //else if ends
            } //if ends

            //determine whether we need a full model or a separate head and body model.
            if (characterOutfit == characterHead && useBody)
            {
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + characterOutfit + ".frdv", fpkOutputPath + outfit.frdvPath, true);
                characterOutfit = "full-" + characterOutfit;

                for (int i = 0; i < characterHeadValues.Count; i++)
                    characterHeadValues[i] = "empty";

                arm = extraList;
                armFrdv = extraList;
            } //if ends
            else
            {
                if (useBody)
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + characterOutfit + ".frdv", fpkOutputPath + outfit.frdvPath, true);
                    characterOutfit = "body-" + characterOutfit;

                    for (int i = 0; i < characterHeadValues.Count; i++)
                        characterHeadValues[i] = "head-" + characterHeadValues[i];

                    arm = extraList;
                    armFrdv = extraList;
                } //if ends
                else if (!useBody && outfit.outfitType != (int)OutfitType.HEAD_NO_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + characterHead + ".frdv", fpkOutputPath + outfit.frdvPath, true);
                    for (int i = 0; i < 7; i++)
                        armFrdv.Add(characterOutfit);

                    for (int i = 0; i < 9; i++)
                        if (i < 7)
                            arm.Add("body-" + characterOutfit);
                        else
                            arm.Add("empty");

                    characterOutfit = "head-" + characterHead;
                    characterHeadValues = extraList;
                    isArmBody = true;
                } //else if ends
                else
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + characterHead + ".frdv", fpkOutputPath + outfit.frdvPath, true);
                    string tempOutfit = characterOutfit;
                    characterOutfit = "head-" + characterHead;

                    for (int i = 0; i < characterHeadValues.Count; i++)
                        characterHeadValues[i] = "body-" + tempOutfit;

                    arm = extraList;
                    armFrdv = extraList;
                } //else ends
            } //else ends

            //copy the outfit to the output path.
            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + characterOutfit + ".fmdl", fpkOutputPath + outfit.outfitPath, true);

            //copy the head if one is needed.
            if (outfit.outfitType != (int)OutfitType.NO_HEAD_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fpkOutputPath + headPath));

                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + characterHeadValues[0] + ".fmdl", fpkOutputPath + headPath, true);

                //if the character is Snake, we need to copy the head a bunch of times.
                if (character == "snake")
                {
                    int headNum = 0;
                    bool singleHeadValue = true;

                    //if there are more than six head values, remove any heads after the sixth.
                    if (characterHeadValues.Count > 6)
                        characterHeadValues.RemoveRange(6, characterHeadValues.Count - 6);

                    //if all of the head values are the same, we only need a single head.
                    for (int i = 0; i < characterHeadValues.Count; i++)
                        for (int j = 0; j < characterHeadValues.Count; j++)
                            if (characterHeadValues[i] != characterHeadValues[j])
                                singleHeadValue = false;

                    //if all of the head values are the same, remove all but one head.
                    if (singleHeadValue)
                        characterHeadValues.RemoveRange(1, characterHeadValues.Count - 1);

                    if (characterHeadValues.Count > 1)
                        headNum++;

                    for (int i = 0; i < 7; i++)
                    {
                        if (useFv2)
                        {
                            Directory.CreateDirectory(fv2Path);

                            if (i != 3)
                            {
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fv2\face0.fv2", fv2Path + "\\sna0_face" + i + "_v00.fv2", true);

                                if (characterHeadValues.Count > 1)
                                    HexSwapper.Swap(fv2Path + "\\sna0_face" + i + "_v00.fv2", "2BEC9C7EE5A3A284", faceFv2Values[i]);
                            } //if ends

                        } //if ends

                        if (i != 0 && i != 3)
                        {
                            if (!useFv2 || characterHeadValues.Count > 1)
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + characterHeadValues[headNum] + ".fmdl", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_face" + i + "_cov.fmdl", true);

                            if (characterHeadValues.Count > 1)
                                headNum++;
                        } //if ends
                    } //for ends
                } //if ends
            } //if ends

            //copy the arm if one is needed.
            if (outfit.outfitType != (int)OutfitType.HEAD_NO_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
            {
                bool empty = true;

                for (int i = 0; i < arm.Count; i++)
                    if (arm[i] != "empty")
                        empty = false;

                if (!empty && !isArmBody)
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + arm[7] + ".fmdl", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_rkt1_cov.fmdl", true);
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + arm[8] + ".fmdl", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_rkt2_cov.fmdl", true);
                } //if ends

                int armNum = 0;

                for (int i = 0; i < 8; i++)
                    if (i != 5)
                    {
                        if (!empty && !isArmBody)
                        {
                            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + arm[armNum] + ".fmdl", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_arm" + i + "_cov.fmdl", true);

                            if (arm[armNum] != "empty")
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + armFrdv[armNum] + ".frdv", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_arm" + i + "_cov.frdv", true);
                        } //if ends
                        else
                        {
                            Directory.CreateDirectory(fv2Path);
                            if (i == 0)
                            {
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + arm[armNum] + ".fmdl", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_arm" + i + "_cov.fmdl", true);

                                if (!empty)
                                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + armFrdv[armNum] + ".frdv", Path.GetDirectoryName(fpkOutputPath + headPath) + "\\sna0_arm" + i + "_cov.frdv", true);
                            } //if ends

                            if(i == 1 || i == 2)
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fv2\arm1.fv2", fv2Path + "\\sna0_arm" + i + "_v00.fv2", true);
                            else
                                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fv2\arm0.fv2", fv2Path + "\\sna0_arm" + i + "_v00.fv2", true);
                        } //else ends

                        armNum++;
                    } //if ends
            } //if ends

            //if there's a .sim, copy it.
            if (sims.Count != 0)
            {
                //create the directory to copy .sims to.
                Directory.CreateDirectory(Path.GetDirectoryName(fpkdOutputPath + outfit.simPath));

                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\sim\" + sims[0] + ".sim", fpkdOutputPath + outfit.simPath, true);

                //if there's a second .sim and the outfit supports a second one, copy it.
                if (sims.Count > 1 && outfit.simPath2 != "None")
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\sim\" + sims[1] + ".sim", fpkdOutputPath + outfit.simPath2, true);
            } //if ends

            MessageBox.Show("Done!");
        } //method Build ends

        /*
         * GetOutfits
         * Loads the list of in-game player outfits and their values.
         */
        private static void GetOutfits()
        {
            Outfit plparts_normal = new Outfit();
            plparts_normal.name = "plparts_normal";
            plparts_normal.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main0_def.fmdl";
            plparts_normal.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main0_def.fcnp";
            plparts_normal.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main0_def.frdv";
            plparts_normal.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_item.sim";
            plparts_normal.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_normal.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_normal);

            Outfit plparts_normal_scarf = new Outfit();
            plparts_normal_scarf.name = "plparts_normal_scarf";
            plparts_normal_scarf.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main1_def.fmdl";
            plparts_normal_scarf.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main1_def.fcnp";
            plparts_normal_scarf.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main1_def.frdv";
            plparts_normal_scarf.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main1_item.sim";
            plparts_normal_scarf.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_normal_scarf.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_normal_scarf);

            Outfit plparts_naked = new Outfit();
            plparts_naked.name = "plparts_naked";
            plparts_naked.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna8_main0_def.fmdl";
            plparts_naked.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna8_main0_def.fcnp";
            plparts_naked.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna8_main0_def.frdv";
            plparts_naked.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_naked.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna8_main0_item.sim";
            plparts_naked.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_naked);

            Outfit plparts_venom = new Outfit();
            plparts_venom.name = "plparts_venom";
            plparts_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_main0_def.fmdl";
            plparts_venom.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna4_main0_def.fcnp";
            plparts_venom.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna4_main0_def.frdv";
            plparts_venom.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_hair.sim";
            plparts_venom.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_body.sim";
            plparts_venom.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_venom);

            Outfit plparts_battledress = new Outfit();
            plparts_battledress.name = "plparts_battledress";
            plparts_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_main0_def.fmdl";
            plparts_battledress.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna5_main0_def.fcnp";
            plparts_battledress.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna5_main0_def.frdv";
            plparts_battledress.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna5_main0_body.sim";
            plparts_battledress.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_battledress.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_battledress);

            Outfit plparts_parasite = new Outfit();
            plparts_parasite.name = "plparts_parasite";
            plparts_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_main0_def.fmdl";
            plparts_parasite.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna7_main0_def.fcnp";
            plparts_parasite.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna7_main0_def.frdv";
            plparts_parasite.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_body.sim";
            plparts_parasite.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_parasite.outfitType = (int)OutfitType.NO_HEAD_ARM;
            outfits.Add(plparts_parasite);

            Outfit plparts_gz_suit = new Outfit();
            plparts_gz_suit.name = "plparts_gz_suit";
            plparts_gz_suit.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna2_main1_def.fmdl";
            plparts_gz_suit.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna2_main1_def.fcnp";
            plparts_gz_suit.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna2_main1_def.frdv";
            plparts_gz_suit.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_hair.sim";
            plparts_gz_suit.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_gz_suit.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_gz_suit);

            Outfit plparts_mgs1 = new Outfit();
            plparts_mgs1.name = "plparts_mgs1";
            plparts_mgs1.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna6_main0_def.fmdl";
            plparts_mgs1.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna6_main0_def.fcnp";
            plparts_mgs1.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna6_main0_def.frdv";
            plparts_mgs1.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_mgs1.simPath2 = "None";
            plparts_mgs1.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_mgs1);

            Outfit plparts_ninja = new Outfit();
            plparts_ninja.name = "plparts_ninja";
            plparts_ninja.outfitPath = @"\Assets\tpp\chara\nin\Scenes\nin0_main0_def.fmdl";
            plparts_ninja.fcnpPath = @"\Assets\tpp\chara\nin\Scenes\nin0_main0_def.fcnp";
            plparts_ninja.frdvPath = @"\Assets\tpp\chara\nin\Scenes\nin0_main0_def.frdv";
            plparts_ninja.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_ninja.simPath2 = "None";
            plparts_ninja.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ninja);

            Outfit plparts_raiden = new Outfit();
            plparts_raiden.name = "plparts_raiden";
            plparts_raiden.outfitPath = @"\Assets\tpp\chara\rai\Scenes\rai0_main0_def.fmdl";
            plparts_raiden.fcnpPath = @"\Assets\tpp\chara\rai\Scenes\rai0_main0_def.fcnp";
            plparts_raiden.frdvPath = @"\Assets\tpp\chara\rai\Scenes\rai0_main0_def.frdv";
            plparts_raiden.simPath = @"\Assets\tpp\chara\rai\Fox_files\rai0_main0_asr.sim";
            plparts_raiden.simPath2 = @"\Assets\tpp\chara\rai\Fox_files\rai0_main0_hair.sim";
            plparts_raiden.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_raiden);

            Outfit plparts_ocelot = new Outfit();
            plparts_ocelot.name = "plparts_ocelot";
            plparts_ocelot.outfitPath = @"\Assets\tpp\chara\ooc\Scenes\ooc0_main1_def.fmdl";
            plparts_ocelot.fcnpPath = @"\Assets\tpp\chara\ooc\Scenes\ooc0_main1_def.fcnp";
            plparts_ocelot.frdvPath = @"\Assets\tpp\chara\ooc\Scenes\ooc0_main1_def.frdv";
            plparts_ocelot.simPath = @"\Assets\tpp\chara\oce\Fox_files\oce0_main0_hair.sim";
            plparts_ocelot.simPath2 = @"\Assets\tpp\chara\ooc\Fox_files\ooc0_main1_asr.sim";
            plparts_ocelot.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ocelot);

            Outfit plparts_quiet = new Outfit();
            plparts_quiet.name = "plparts_quiet";
            plparts_quiet.outfitPath = @"\Assets\tpp\chara\qui\Scenes\quip_main0_def0.fmdl";
            plparts_quiet.fcnpPath = @"\Assets\tpp\chara\qui\Scenes\quip_main0_def0.fcnp";
            plparts_quiet.frdvPath = @"\Assets\tpp\chara\qui\Scenes\quip_main0_def0.frdv";
            plparts_quiet.simPath = @"\Assets\tpp\chara\qui\Fox_files\quip_main0_def.sim.sim";
            plparts_quiet.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_quiet.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_quiet);

            Outfit plparts_dd_female = new Outfit();
            plparts_dd_female.name = "plparts_dd_female";
            plparts_dd_female.outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds6_main0_def.fmdl";
            plparts_dd_female.fcnpPath = @"\Assets\tpp\chara\dds\Scenes\dds6_main0_def.fcnp";
            plparts_dd_female.frdvPath = @"\Assets\tpp\chara\dds\Scenes\dds6_main0_def.frdv";
            plparts_dd_female.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dd_female.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_dd_female.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dd_female);

            Outfit plparts_ddf_venom = new Outfit();
            plparts_ddf_venom.name = "plparts_ddf_venom";
            plparts_ddf_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plyf0_def.fmdl";
            plparts_ddf_venom.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plyf0_def.fcnp";
            plparts_ddf_venom.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plyf0_def.frdv";
            plparts_ddf_venom.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_venom.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_venom.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_venom);

            Outfit plparts_ddf_battledress = new Outfit();
            plparts_ddf_battledress.name = "plparts_ddf_battledress";
            plparts_ddf_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plyf0_def.fmdl";
            plparts_ddf_battledress.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plyf0_def.fcnp";
            plparts_ddf_battledress.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plyf0_def.frdv";
            plparts_ddf_battledress.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_battledress.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_battledress.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_battledress);

            Outfit plparts_ddf_parasite = new Outfit();
            plparts_ddf_parasite.name = "plparts_ddf_parasite";
            plparts_ddf_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plyf0_def.fmdl";
            plparts_ddf_parasite.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plyf0_def.fcnp";
            plparts_ddf_parasite.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plyf0_def.frdv";
            plparts_ddf_parasite.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_parasite.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_parasite.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ddf_parasite);

            Outfit plparts_ddf_swimwear = new Outfit();
            plparts_ddf_swimwear.name = "plparts_ddf_swimwear";
            plparts_ddf_swimwear.outfitPath = @"\Assets\tpp\chara\dlf\Scenes\dlf0_main0_def_f.fmdl";
            plparts_ddf_swimwear.fcnpPath = @"\Assets\tpp\chara\dlf\Scenes\dlf0_main0_def_f.fcnp";
            plparts_ddf_swimwear.frdvPath = @"\Assets\tpp\chara\dlf\Scenes\dlf0_main0_def_f.frdv";
            plparts_ddf_swimwear.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddf_swimwear.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddf_swimwear.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_swimwear);

            Outfit plparts_ddf_swimwear_g = new Outfit();
            plparts_ddf_swimwear_g.name = "plparts_ddf_swimwear_g";
            plparts_ddf_swimwear_g.outfitPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.fmdl";
            plparts_ddf_swimwear_g.fcnpPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.fcnp";
            plparts_ddf_swimwear_g.frdvPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.frdv";
            plparts_ddf_swimwear_g.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddf_swimwear_g.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddf_swimwear_g.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_swimwear_g);

            Outfit plparts_ddf_swimwear_h = new Outfit();
            plparts_ddf_swimwear_h.name = "plparts_ddf_swimwear_h";
            plparts_ddf_swimwear_h.outfitPath = @"\Assets\tpp\chara\dlh\Scenes\dlh0_main0_def_f.fmdl";
            plparts_ddf_swimwear_h.fcnpPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.fcnp";
            plparts_ddf_swimwear_h.frdvPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.frdv";
            plparts_ddf_swimwear_h.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddf_swimwear_h.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddf_swimwear_h.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_swimwear_h);

            Outfit plparts_dd_male = new Outfit();
            plparts_dd_male.name = "plparts_dd_male";
            plparts_dd_male.outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds5_main0_def.fmdl";
            plparts_dd_male.fcnpPath = @"\Assets\tpp\chara\dds\Scenes\dds5_main0_def.fcnp";
            plparts_dd_male.frdvPath = @"\Assets\tpp\chara\dds\Scenes\dds5_main0_def.frdv";
            plparts_dd_male.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dd_male.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_dd_male.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dd_male);

            Outfit plparts_ddm_venom = new Outfit();
            plparts_ddm_venom.name = "plparts_ddm_venom";
            plparts_ddm_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plym0_def.fmdl";
            plparts_ddm_venom.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plym0_def.fcnp";
            plparts_ddm_venom.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plym0_def.frdv";
            plparts_ddm_venom.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddm_venom.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddm_venom.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddm_venom);

            Outfit plparts_ddm_battledress = new Outfit();
            plparts_ddm_battledress.name = "plparts_ddm_battledress";
            plparts_ddm_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plym0_def.fmdl";
            plparts_ddm_battledress.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plym0_def.fcnp";
            plparts_ddm_battledress.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plym0_def.frdv";
            plparts_ddm_battledress.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddm_battledress.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddm_battledress.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddm_battledress);

            Outfit plparts_ddm_parasite = new Outfit();
            plparts_ddm_parasite.name = "plparts_ddm_parasite";
            plparts_ddm_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plym0_def.fmdl";
            plparts_ddm_parasite.fcnpPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plym0_def.fcnp";
            plparts_ddm_parasite.frdvPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plym0_def.frdv";
            plparts_ddm_parasite.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddm_parasite.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddm_parasite.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ddm_parasite);

            Outfit plparts_ddm_swimwear = new Outfit();
            plparts_ddm_swimwear.name = "plparts_ddm_swimwear";
            plparts_ddm_swimwear.outfitPath = @"\Assets\tpp\chara\dlf\Scenes\dlf1_main0_def.fmdl";
            plparts_ddm_swimwear.fcnpPath = @"\Assets\tpp\chara\dlf\Scenes\dlf1_main0_def.fcnp";
            plparts_ddm_swimwear.frdvPath = @"\Assets\tpp\chara\dlf\Scenes\dlf1_main0_def.frdv";
            plparts_ddm_swimwear.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddm_swimwear.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddm_swimwear.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddm_swimwear);

            Outfit plparts_ddm_swimwear_g = new Outfit();
            plparts_ddm_swimwear_g.name = "plparts_ddm_swimwear_g";
            plparts_ddm_swimwear_g.outfitPath = @"\Assets\tpp\chara\dlg\Scenes\dlg1_main0_def.fmdl";
            plparts_ddm_swimwear_g.fcnpPath = @"\Assets\tpp\chara\dlg\Scenes\dlg1_main0_def.fcnp";
            plparts_ddm_swimwear_g.frdvPath = @"\Assets\tpp\chara\dlg\Scenes\dlg1_main0_def.frdv";
            plparts_ddm_swimwear_g.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddm_swimwear_g.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddm_swimwear_g.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddm_swimwear_g);

            Outfit plparts_ddm_swimwear_h = new Outfit();
            plparts_ddm_swimwear_h.name = "plparts_ddm_swimwear_h";
            plparts_ddm_swimwear_h.outfitPath = @"\Assets\tpp\chara\dlh\Scenes\dlh1_main0_def.fmdl";
            plparts_ddm_swimwear_h.fcnpPath = @"\Assets\tpp\chara\dlg\Scenes\dlg1_main0_def.fcnp";
            plparts_ddm_swimwear_h.frdvPath = @"\Assets\tpp\chara\dlg\Scenes\dlg1_main0_def.frdv";
            plparts_ddm_swimwear_h.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddm_swimwear_h.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddm_swimwear_h.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddm_swimwear_h);

            //Standard Fatigues (NS)
            Outfit plparts_dla0_main0_def_v00 = new Outfit();
            plparts_dla0_main0_def_v00.name = "plparts_dla0_main0_def_v00";
            plparts_dla0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla0_main0_def.fmdl";
            plparts_dla0_main0_def_v00.fcnpPath = @"\Assets\tpp\chara\dla\Scenes\dla0_main0_def.fcnp";
            plparts_dla0_main0_def_v00.frdvPath = @"\Assets\tpp\chara\dla\Scenes\dla0_main0_def.frdv";
            plparts_dla0_main0_def_v00.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_dla0_main0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dla0_main0_def_v00.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_dla0_main0_def_v00);

            Outfit plparts_dla0_plym0_def_v00 = new Outfit();
            plparts_dla0_plym0_def_v00.name = "plparts_dla0_plym0_def_v00";
            plparts_dla0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla0_plym0_def.fmdl";
            plparts_dla0_plym0_def_v00.fcnpPath = @"\Assets\tpp\chara\dla\Scenes\dla0_plym0_def.fcnp";
            plparts_dla0_plym0_def_v00.frdvPath = @"\Assets\tpp\chara\dla\Scenes\dla0_plym0_def.frdv";
            plparts_dla0_plym0_def_v00.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_dla0_plym0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dla0_plym0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dla0_plym0_def_v00);

            //Naked Fatigues (NS)
            Outfit plparts_dla1_main0_def_v00 = new Outfit();
            plparts_dla1_main0_def_v00.name = "plparts_dla1_main0_def_v00";
            plparts_dla1_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla1_main0_def.fmdl";
            plparts_dla1_main0_def_v00.fcnpPath = @"\Assets\tpp\chara\dla\Scenes\dla1_main0_def.fcnp";
            plparts_dla1_main0_def_v00.frdvPath = @"\Assets\tpp\chara\dla\Scenes\dla1_main0_def.frdv";
            plparts_dla1_main0_def_v00.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_dla1_main0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dla1_main0_def_v00.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_dla1_main0_def_v00);

            Outfit plparts_dla1_plym0_def_v00 = new Outfit();
            plparts_dla1_plym0_def_v00.name = "plparts_dla1_plym0_def_v00";
            plparts_dla1_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla1_plym0_def.fmdl";
            plparts_dla1_plym0_def_v00.fcnpPath = @"\Assets\tpp\chara\dla\Scenes\dla1_plym0_def.fcnp";
            plparts_dla1_plym0_def_v00.frdvPath = @"\Assets\tpp\chara\dla\Scenes\dla1_plym0_def.frdv";
            plparts_dla1_plym0_def_v00.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_dla1_plym0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dla1_plym0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dla1_plym0_def_v00);

            //Sneaking Suit (NS)
            Outfit plparts_dlb0_main0_def_v00 = new Outfit();
            plparts_dlb0_main0_def_v00.name = "plparts_dlb0_main0_def_v00";
            plparts_dlb0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_main0_def.fmdl";
            plparts_dlb0_main0_def_v00.fcnpPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_main0_def.fcnp";
            plparts_dlb0_main0_def_v00.frdvPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_main0_def.frdv";
            plparts_dlb0_main0_def_v00.simPath = @"\Assets\tpp\chara\dlb\Fox_files\dlb0_main0_hair.sim";
            plparts_dlb0_main0_def_v00.simPath2 = @"\Assets\tpp\chara\dlb\Fox_files\dlb0_main0_item.sim";
            plparts_dlb0_main0_def_v00.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_dlb0_main0_def_v00);

            Outfit plparts_dlb0_plym0_def_v00 = new Outfit();
            plparts_dlb0_plym0_def_v00.name = "plparts_dlb0_plym0_def_v00";
            plparts_dlb0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_plym0_def.fmdl";
            plparts_dlb0_plym0_def_v00.fcnpPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_plym0_def.fcnp";
            plparts_dlb0_plym0_def_v00.frdvPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_plym0_def.frdv";
            plparts_dlb0_plym0_def_v00.simPath = @"\Assets\tpp\chara\dlb\Fox_files\dlb0_main0_item.sim";
            plparts_dlb0_plym0_def_v00.simPath2 = @"\Assets\tpp\chara\dlb\Fox_files\dlb0_main0_asr.sim";
            plparts_dlb0_plym0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dlb0_plym0_def_v00);

            //The Boss (Closed)
            Outfit plparts_dlc0_plyf0_def_v00 = new Outfit();
            plparts_dlc0_plyf0_def_v00.name = "plparts_dlc0_plyf0_def_v00";
            plparts_dlc0_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dlc\Scenes\dlc0_plyf0_def.fmdl";
            plparts_dlc0_plyf0_def_v00.fcnpPath = @"\Assets\tpp\chara\dlc\Scenes\dlc0_plyf0_def.fcnp";
            plparts_dlc0_plyf0_def_v00.frdvPath = @"\Assets\tpp\chara\dlc\Scenes\dlc0_plyf0_def.frdv";
            plparts_dlc0_plyf0_def_v00.simPath = @"\Assets\tpp\chara\dlc\Fox_files\dlc0_body0_def.sim";
            plparts_dlc0_plyf0_def_v00.simPath2 = @"\Assets\tpp\chara\dlc\Fox_files\dlc0_bust0_def.sim";
            plparts_dlc0_plyf0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dlc0_plyf0_def_v00);

            //The Boss (Open)
            Outfit plparts_dlc1_plyf0_def_v00 = new Outfit();
            plparts_dlc1_plyf0_def_v00.name = "plparts_dlc1_plyf0_def_v00";
            plparts_dlc1_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dlc\Scenes\dlc1_plyf0_def.fmdl";
            plparts_dlc1_plyf0_def_v00.fcnpPath = @"\Assets\tpp\chara\dlc\Scenes\dlc1_plyf0_def.fcnp";
            plparts_dlc1_plyf0_def_v00.frdvPath = @"\Assets\tpp\chara\dlc\Scenes\dlc1_plyf0_def.frdv";
            plparts_dlc1_plyf0_def_v00.simPath = @"\Assets\tpp\chara\dlc\Fox_files\dlc0_body0_def.sim";
            plparts_dlc1_plyf0_def_v00.simPath2 = @"\Assets\tpp\chara\dlc\Fox_files\dlc1_belt0_def.sim";
            plparts_dlc1_plyf0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dlc1_plyf0_def_v00);

            //Tuxedo (NS)
            Outfit plparts_dld0_main0_def_v00 = new Outfit();
            plparts_dld0_main0_def_v00.name = "plparts_dld0_main0_def_v00";
            plparts_dld0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dld\Scenes\dld0_main0_def.fmdl";
            plparts_dld0_main0_def_v00.fcnpPath = @"\Assets\tpp\chara\dld\Scenes\dld0_main0_def.fcnp";
            plparts_dld0_main0_def_v00.frdvPath = @"\Assets\tpp\chara\dld\Scenes\dld0_main0_def.frdv";
            plparts_dld0_main0_def_v00.simPath = @"\Assets\tpp\chara\dld\FOX_files\dld0_hair0_def.sim";
            plparts_dld0_main0_def_v00.simPath2 = @"\Assets\tpp\chara\dld\FOX_files\dld0_body0_def.sim";
            plparts_dld0_main0_def_v00.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_dld0_main0_def_v00);

            Outfit plparts_dld0_plym0_def_v00 = new Outfit();
            plparts_dld0_plym0_def_v00.name = "plparts_dld0_plym0_def_v00";
            plparts_dld0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dld0_plym0_def.fmdl";
            plparts_dld0_plym0_def_v00.fcnpPath = @"\Assets\tpp\chara\dla\Scenes\dld0_plym0_def.fcnp";
            plparts_dld0_plym0_def_v00.frdvPath = @"\Assets\tpp\chara\dla\Scenes\dld0_plym0_def.frdv";
            plparts_dld0_plym0_def_v00.simPath = @"\Assets\tpp\chara\dld\FOX_files\dld0_body0_def.sim";
            plparts_dld0_plym0_def_v00.simPath2 = @"\Assets\tpp\chara\dld\FOX_files\dld0_asrt0_def.sim";
            plparts_dld0_plym0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dld0_plym0_def_v00);

            //EVA (Closed)
            Outfit plparts_dle0_plyf0_def_v00 = new Outfit();
            plparts_dle0_plyf0_def_v00.name = "plparts_dle0_plyf0_def_v00";
            plparts_dle0_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dle\Scenes\dle0_plyf0_def.fmdl";
            plparts_dle0_plyf0_def_v00.fcnpPath = @"\Assets\tpp\chara\dle\Scenes\dle0_plyf0_def.fcnp";
            plparts_dle0_plyf0_def_v00.frdvPath = @"\Assets\tpp\chara\dle\Scenes\dle0_plyf0_def.frdv";
            plparts_dle0_plyf0_def_v00.simPath = @"\Assets\tpp\chara\dle\Fox_files\dle0_body0_def.sim";
            plparts_dle0_plyf0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dle0_plyf0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dle0_plyf0_def_v00);

            //EVA (Open)
            Outfit plparts_dle1_plyf0_def_v00 = new Outfit();
            plparts_dle1_plyf0_def_v00.name = "plparts_dle1_plyf0_def_v00";
            plparts_dle1_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dle\Scenes\dle1_plyf0_def.fmdl";
            plparts_dle1_plyf0_def_v00.fcnpPath = @"\Assets\tpp\chara\dle\Scenes\dle1_plyf0_def.fcnp";
            plparts_dle1_plyf0_def_v00.frdvPath = @"\Assets\tpp\chara\dle\Scenes\dle1_plyf0_def.frdv";
            plparts_dle1_plyf0_def_v00.simPath = @"\Assets\tpp\chara\dle\Fox_files\dle1_body0_def.sim";
            plparts_dle1_plyf0_def_v00.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dle1_plyf0_def_v00.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dle1_plyf0_def_v00);
        } //method GetOutfits ends

        /*
         * DeleteDirectory
         * This function ensures a specified directory will be deleted.
         */
        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
                DeleteDirectory(directory);

            try
            {
                Directory.Delete(path, true);
            } //try ends
            catch (IOException)
            {
                Directory.Delete(path, true);
            } //catch ends
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            } //catch ends
        } //function DeleteDirectory ends
    } //class OutfitBuilder ends
} //namespace MQPMTool2 ends