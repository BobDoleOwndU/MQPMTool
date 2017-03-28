using GzsTool.Core.Common;
using GzsTool.Core.Common.Interfaces;
using GzsTool.Core.Pftxs;
using System.Collections.Generic;
using System.IO;

namespace MQPMTool2
{
    public static class ArchiveHandler
    {
        /*
         * ExtractArchive
         * Extracts files contained in TPP's archives (.dat, .fpk, .fpkd, .sbp).
         */
        public static void ExtractArchive<T>(string FileName, string OutputPath) where T : ArchiveFile, new()
        {
            using (FileStream archiveFile = new FileStream(FileName, FileMode.Open))
            {
                List<string> outFiles = new List<string>();
                T archive = new T();
                archive.Name = Path.GetFileName(FileName);
                archive.Read(archiveFile);

                // Select single file for output

                foreach (var v in archive.ExportFiles(archiveFile))
                {
                    string outDirectory = Path.Combine(OutputPath, Path.GetDirectoryName(v.FileName));
                    string outFileName = Path.Combine(OutputPath, v.FileName);
                    if (!Directory.Exists(outDirectory)) Directory.CreateDirectory(outDirectory);
                    using (FileStream outStream = new FileStream(outFileName, FileMode.Create))
                    {
                        // copy to output stream
                        v.DataStream().CopyTo(outStream);
                        outFiles.Add(v.FileName);
                    }
                } //foreach ends
            } //using ends
        } //method ExtractArchive ends

        /*
         * WritePftxsArchive
         * Gets all of the files contained in a directory and writes them to a .pftxs file.
         */
        public static void WritePftxsArchive(string FileName, string SourceDirectory)
        {
            PftxsFile p = new PftxsFile() { Name = FileName };
            foreach (string file in Directory.EnumerateFiles(SourceDirectory))
            {

                if (Path.GetExtension(file) == ".ftex")
                {
                    string nameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    PftxsFtexFile pf = new PftxsFtexFile();
                    PftxsFtexsFileEntry pfe = new PftxsFtexsFileEntry() { FilePath = file };
                    PftxsFtexsFileEntry pfe1 = new PftxsFtexsFileEntry() { FilePath = nameWithoutExtension + ".1.ftexs" };
                    pf.Entries = new List<PftxsFtexsFileEntry>(0);
                    pf.Entries.Add(pfe);
                    pf.Entries.Add(pfe1);


                    if (File.Exists(SourceDirectory + "\\" + nameWithoutExtension + ".2.ftexs"))
                    {
                        PftxsFtexsFileEntry pfe2 = new PftxsFtexsFileEntry() { FilePath = nameWithoutExtension + ".2.ftexs" };
                        pf.Entries.Add(pfe2);
                    } //if ends

                    if (File.Exists(SourceDirectory + "\\" + nameWithoutExtension + ".3.ftexs"))
                    {
                        PftxsFtexsFileEntry pfe2 = new PftxsFtexsFileEntry() { FilePath = nameWithoutExtension + ".3.ftexs" };
                        pf.Entries.Add(pfe2);
                    } //if ends

                    p.Files.Add(pf);
                } //if ends
            } //foreach ends

            using (FileStream outFile = new FileStream(FileName, FileMode.Create))
            {
                IDirectory fileDirectory = new FileSystemDirectory(SourceDirectory);
                p.Write(outFile, fileDirectory);
            } //using ends
        } //method WritePftxsArchive
    } //class ArchiveHandler ends
} //namespace MQPMTool2 ends
