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
            public string headPath;
            public string simPath;
            public string simPath2;
            public int outfitType;
        } //struct Outfit ends

        static List<Outfit> outfits = new List<Outfit>(0);

        public static void Build(string outputPath, bool isSnake, string playerOutfit, string quietOutfit, string quietHead, string fcnp, string[] sims, bool includePftxs, bool useBody, string extraFmdl)
        {
            string playerOutfitName = "";
            string fpkOutputPath = "";
            string fpkdOutputPath = "";
            string arm = "";
            string armFrdv = "none";
            Outfit outfit = new Outfit();

            GetOutfits(); //load the list of outfits.

            //determine the outfit path, fpk path and fpkd path.
            if (isSnake)
                playerOutfitName = "plparts_" + playerOutfit;
            else
                if(playerOutfit == "normal")
                    playerOutfitName = "plparts_dd_female";
                else
                    playerOutfitName = "plparts_ddf_" + playerOutfit;

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";
            fpkdOutputPath = fpkOutputPath + "d";

            //find the outfit to output to.
            for (int i = 0; i < outfits.Count; i++)
                if (outfits[i].name == playerOutfitName)
                    outfit = outfits[i];

            //create the output path and copy the .fcnp there.
            Directory.CreateDirectory(Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath));
            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fcnp\" + fcnp + ".fcnp", fpkOutputPath + outfit.outfitPath + ".fcnp", true);

            //if the outfit needs a .pftxs, copy it over.
            if(includePftxs)
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\pftxs\" + quietOutfit + ".pftxs", Path.GetDirectoryName(fpkOutputPath) + "\\" + playerOutfitName + ".pftxs", true);

            //determine whether we need a full model or a separate head and body model.
            if (quietOutfit == quietHead)
            {
                quietOutfit = "full-" + quietOutfit;
                quietHead = "empty";
                arm = extraFmdl;
            } //if ends
            else
            {
                if(useBody)
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + quietOutfit + ".frdv", fpkOutputPath + outfit.outfitPath + ".frdv", true);
                    quietOutfit = "body-" + quietOutfit;
                    quietHead = "head-" + quietHead;
                    arm = extraFmdl;
                } //if ends
                else if(!useBody && outfit.outfitType != (int)OutfitType.HEAD_NO_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + quietHead + ".frdv", fpkOutputPath + outfit.outfitPath + ".frdv", true);
                    armFrdv = quietOutfit;
                    arm = "body-" + quietOutfit;
                    quietOutfit = "head-" + quietHead;
                    quietHead = extraFmdl;
                } //else if ends
                else
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + quietHead + ".frdv", fpkOutputPath + outfit.outfitPath + ".frdv", true);
                    string tempOutfit = quietOutfit;
                    quietOutfit = "head-" + quietHead;
                    quietHead = "body-" + tempOutfit;
                    arm = extraFmdl;
                } //else ends
            } //else ends

            //if the arm lacks an .fmdl, use the empty one.
            if(arm == "none")
                arm = "empty";
            else if (quietHead == "none")
                quietHead = "empty";

            //copy the outfit to the output path.
            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + quietOutfit + ".fmdl", fpkOutputPath + outfit.outfitPath + ".fmdl", true);

            //copy the head if one is needed.
            if(outfit.outfitType != (int)OutfitType.NO_HEAD_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fpkOutputPath + outfit.headPath));
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + quietHead + ".fmdl", fpkOutputPath + outfit.headPath, true);

                //if the character is Snake, we need to copy the head a bunch of times.
                if(isSnake)
                    for (int i = 1; i < 7; i++)
                        if (i != 3)
                            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + quietHead + ".fmdl", Path.GetDirectoryName(fpkOutputPath + outfit.headPath) + "\\sna0_face" + i + "_cov.fmdl", true);
            } //if ends

            //copy the arm if one is needed.
            if(outfit.outfitType != (int)OutfitType.HEAD_NO_ARM && outfit.outfitType != (int)OutfitType.NO_HEAD_NO_ARM)
            {
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\empty.fmdl", Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath) + "\\sna0_rkt1_cov.fmdl", true);
                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\empty.fmdl", Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath) + "\\sna0_rkt2_cov.fmdl", true);

                for (int i = 0; i < 8; i++)
                    if (i != 5)
                    {
                        File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\fmdl\" + arm + ".fmdl", Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath) + "\\sna0_arm" + i + "_cov.fmdl", true);

                        if(arm != "empty")
                            File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\frdv\" + armFrdv + ".frdv", Path.GetDirectoryName(fpkOutputPath + outfit.outfitPath) + "\\sna0_arm" + i + "_cov.frdv", true);
                    } //if ends
            } //if ends

            //if there's a .sim, copy it.
            if(sims.Length != 0)
            {
                //create the directory to copy .sims to.
                Directory.CreateDirectory(Path.GetDirectoryName(fpkdOutputPath + outfit.simPath));

                File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\sim\" + sims[0] + ".sim", fpkdOutputPath + outfit.simPath, true);

                //if there's a second .sim and the outfit supports a second one, copy it.
                if(sims.Length > 1 && outfit.simPath2 != "None")
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\sim\" + sims[1] + ".sim", fpkdOutputPath + outfit.simPath2, true);
            } //if ends

            MessageBox.Show("Done!");
        } //method Build ends

        private static void GetOutfits()
        {
            Outfit plparts_normal = new Outfit();
            plparts_normal.name = "plparts_normal";
            plparts_normal.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main0_def";
            plparts_normal.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_normal.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_item.sim";
            plparts_normal.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_normal.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_normal);

            Outfit plparts_normal_scarf = new Outfit();
            plparts_normal_scarf.name = "plparts_normal_scarf";
            plparts_normal_scarf.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main1_def";
            plparts_normal_scarf.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_normal_scarf.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main1_item.sim";
            plparts_normal_scarf.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_normal_scarf.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_normal_scarf);

            Outfit plparts_naked = new Outfit();
            plparts_naked.name = "plparts_naked";
            plparts_naked.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna8_main0_def";
            plparts_naked.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_naked.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_hair.sim";
            plparts_naked.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna8_main0_item.sim";
            plparts_naked.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_naked);

            Outfit plparts_venom = new Outfit();
            plparts_venom.name = "plparts_venom";
            plparts_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_main0_def";
            plparts_venom.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_venom.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_hair.sim";
            plparts_venom.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_body.sim";
            plparts_venom.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_venom);

            Outfit plparts_battledress = new Outfit();
            plparts_battledress.name = "plparts_battledress";
            plparts_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_main0_def";
            plparts_battledress.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_battledress.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna5_main0_body.sim";
            plparts_battledress.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_battledress.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_battledress);

            Outfit plparts_parasite = new Outfit();
            plparts_parasite.name = "plparts_parasite";
            plparts_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_main0_def";
            plparts_parasite.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_parasite.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_body.sim";
            plparts_parasite.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_parasite.outfitType = (int)OutfitType.NO_HEAD_ARM;
            outfits.Add(plparts_parasite);

            Outfit plparts_gz_suit = new Outfit();
            plparts_gz_suit.name = "plparts_gz_suit";
            plparts_gz_suit.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna2_main1_def";
            plparts_gz_suit.headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
            plparts_gz_suit.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_hair.sim";
            plparts_gz_suit.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_gz_suit.outfitType = (int)OutfitType.HEAD_ARM;
            outfits.Add(plparts_gz_suit);

            Outfit plparts_mgs1 = new Outfit();
            plparts_mgs1.name = "plparts_mgs1";
            plparts_mgs1.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna6_main0_def";
            plparts_mgs1.headPath = "None";
            plparts_mgs1.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_mgs1.simPath2 = "None";
            plparts_mgs1.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_mgs1);

            Outfit plparts_ninja = new Outfit();
            plparts_ninja.name = "plparts_ninja";
            plparts_ninja.outfitPath = @"\Assets\tpp\chara\nin\Scenes\sna6_main0_def";
            plparts_ninja.headPath = "None";
            plparts_ninja.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna2_main0_asr.sim";
            plparts_ninja.simPath2 = "None";
            plparts_ninja.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ninja);

            Outfit plparts_raiden = new Outfit();
            plparts_raiden.name = "plparts_raiden";
            plparts_raiden.outfitPath = @"\Assets\tpp\chara\rai\Scenes\rai0_main0_def";
            plparts_raiden.headPath = "None";
            plparts_raiden.simPath = @"\Assets\tpp\chara\rai\Fox_files\rai0_main0_asr.sim";
            plparts_raiden.simPath2 = @"\Assets\tpp\chara\rai\Fox_files\rai0_main0_hair.sim";
            plparts_raiden.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_raiden);

            Outfit plparts_dd_female = new Outfit();
            plparts_dd_female.name = "plparts_dd_female";
            plparts_dd_female.outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds6_main0_def";
            plparts_dd_female.headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
            plparts_dd_female.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_dd_female.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_dd_female.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_dd_female);

            Outfit plparts_ddf_venom = new Outfit();
            plparts_ddf_venom.name = "plparts_ddf_venom";
            plparts_ddf_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plyf0_def";
            plparts_ddf_venom.headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
            plparts_ddf_venom.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_venom.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_venom.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_venom);

            Outfit plparts_ddf_battledress = new Outfit();
            plparts_ddf_battledress.name = "plparts_ddf_venom";
            plparts_ddf_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plyf0_def";
            plparts_ddf_battledress.headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
            plparts_ddf_battledress.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_battledress.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_battledress.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_battledress);

            Outfit plparts_ddf_parasite = new Outfit();
            plparts_ddf_parasite.name = "plparts_ddf_parasite";
            plparts_ddf_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plyf0_def";
            plparts_ddf_parasite.headPath = "None";
            plparts_ddf_parasite.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_item.sim";
            plparts_ddf_parasite.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna4_main0_asr.sim";
            plparts_ddf_parasite.outfitType = (int)OutfitType.NO_HEAD_NO_ARM;
            outfits.Add(plparts_ddf_parasite);

            Outfit plparts_ddf_swimwear = new Outfit();
            plparts_ddf_swimwear.name = "plparts_ddf_swimwear";
            plparts_ddf_swimwear.outfitPath = @"\Assets\tpp\chara\dlf\Scenes\dlf0_main0_def_f";
            plparts_ddf_swimwear.headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
            plparts_ddf_swimwear.simPath = @"\Assets\tpp\chara\sna\Fox_files\sna0_main0_asr.sim";
            plparts_ddf_swimwear.simPath2 = @"\Assets\tpp\chara\sna\Fox_files\sna0_broken_arm_r.sim";
            plparts_ddf_swimwear.outfitType = (int)OutfitType.HEAD_NO_ARM;
            outfits.Add(plparts_ddf_swimwear);
        } //method GetOutfits ends
    } //class OutfitBuilder ends
} //namespace MQPMTool2 ends