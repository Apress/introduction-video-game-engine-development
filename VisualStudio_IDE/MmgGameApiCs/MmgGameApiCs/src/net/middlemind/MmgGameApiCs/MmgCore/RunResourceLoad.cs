using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A worker thread that handles loading the game resources.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class RunResourceLoad
    {
        /// <summary>
        /// A bool result of the loading process.
        /// </summary>
        public bool readResult;

        /// <summary>
        /// A bool result of the last read operation.
        /// </summary>
        public bool readComplete;

        /// <summary>
        /// Helper variables for the read process.
        /// </summary>
        public int readPos;

        /// <summary>
        /// Helper variables for the read process.
        /// </summary>
        public int readLen;

        /// <summary>
        /// A value used to increase the size of the steps to process. 
        /// In case there are only a few load operations to perform this number will change that
        /// value to 1000's so that the progress bar math stays away from small number division.
        /// </summary>
        public int loadMultiplier = 1000;

        /// <summary>
        /// An event handler for receiving update messages from the DAT loader.
        /// </summary>
        public LoadResourceUpdateHandler update;

        /// <summary>
        /// A private class field used to track the total number of files to process in a processing loop.
        /// </summary>
        private int tlen;

        /// <summary>
        /// A private class field used to track each loop iteration when processing resource files.
        /// </summary>
        private int i;

        /// <summary>
        /// The number of milliseconds to apply as a slow down to the resource loading process.
        /// </summary>
        public long slowDown;

        /// <summary>
        /// A bool flag inidcating if the resource loading should exit.
        /// </summary>
        public bool exitLoad;

        /// <summary>
        /// A cross thread writing class, used to store cross thread commands.
        /// </summary>
        public CrossThreadWrite xTrdW;

        /// <summary>
        /// A temporary variable used to hold the contents of a file loaded in a thread and passed, using a cross thread write class, for prep as a game image.
        /// </summary>
        private byte[] fileData;

        /// <summary>
        /// A constructor that sets the thin load option, don't load binary image or sound data yet, and sets the source byte array to parse.
        /// </summary>
        public RunResourceLoad()
        {
            readPos = 0;
            readLen = 0;
            readResult = false;
            readComplete = false;
            exitLoad = false;
            slowDown = 0;
            xTrdW = new CrossThreadWrite();
        }

        /// <summary>
        /// A method for passing on LoadDatUpdate events.
        /// </summary>
        /// <param name="Update">Update The handler subscribing to events.</param>
        public void SetUpdateHandler(LoadResourceUpdateHandler Update)
        {
            update = Update;
        }

        /// <summary>
        /// A method used to read the contents of a file.
        /// </summary>
        /// <param name="file">The file to read the contents of.</param>
        /// <returns>A byte array representation of the file.</returns>
        private byte[] ReadFileData(string file)
        {
            byte[] ret = null;
            FileInfo fInf = new FileInfo(file);
            FileStream fs = new FileStream(file, FileMode.Open);
            int len = (int)fInf.Length;
            ret = new byte[len];
            fs.Read(ret, 0, len);
            fs.Close();
            return ret;
        }

        /// <summary>
        /// The run method for this worker thread.
        /// </summary>
        public virtual void run()
        {
            readLen = 1;
            readPos = 1;
            readResult = false;
            readComplete = false;

            DirectoryInfo asld = null;
            DirectoryInfo adld = null;
            FileInfo[] srcFiles = null;
            List<FileInfo> clnFiles = null;
            List<FileInfo> asFiles = null;
            List<FileInfo> adFiles = null;
            int j = 0;

            try
            {
                asFiles = new List<FileInfo>();
                adFiles = new List<FileInfo>();

                //load core auto loading audio files
                asld = new DirectoryInfo(GameSettings.AUTO_SOUND_LOAD_DIR);
                if (asld.Exists)
                {
                    srcFiles = asld.GetFiles();
                    clnFiles = new List<FileInfo>();

                    for (j = 0; j < srcFiles.Length; j++)
                    {
                        if (srcFiles[j].Name.ToCharArray()[0] != '.' && srcFiles[j].Name.ToLower().IndexOf(".wav") != -1)
                        {
                            clnFiles.Add(srcFiles[j]);
                        }
                    }

                    asFiles.AddRange(clnFiles);
                    if (asFiles != null && asFiles.Count > 0)
                    {
                        readLen = (asFiles.Count - 1) * loadMultiplier;
                    }
                }

                //load core auto loading image files            
                adld = new DirectoryInfo(GameSettings.AUTO_IMAGE_LOAD_DIR);
                if (adld.Exists)
                {
                    srcFiles = adld.GetFiles();
                    clnFiles = new List<FileInfo>();

                    for (j = 0; j < srcFiles.Length; j++)
                    {
                        if (srcFiles[j].Name.ToCharArray()[0] != '.' && (srcFiles[j].Name.ToLower().IndexOf(".png") != -1 || srcFiles[j].Name.ToLower().IndexOf(".jpg") != -1 || srcFiles[j].Name.ToLower().IndexOf(".bmp") != -1))
                        {
                            clnFiles.Add(srcFiles[j]);
                        }
                    }

                    adFiles.AddRange(clnFiles);
                    if (adFiles != null && adFiles.Count > 0)
                    {
                        readLen = (adFiles.Count - 1) * loadMultiplier;
                    }
                }

                //load core auto loading audio files            
                asld = new DirectoryInfo(GameSettings.PROGRAM_SOUND_LOAD_DIR);
                if (asld.Exists)
                {
                    srcFiles = asld.GetFiles();
                    clnFiles = new List<FileInfo>();

                    for (j = 0; j < srcFiles.Length; j++)
                    {
                        if (srcFiles[j].Name.ToCharArray()[0] != '.' && srcFiles[j].Name.ToLower().IndexOf(".wav") != -1)
                        {
                            clnFiles.Add(srcFiles[j]);
                        }
                    }

                    asFiles.AddRange(clnFiles);
                    if (asFiles != null && asFiles.Count > 0)
                    {
                        readLen = (asFiles.Count - 1) * loadMultiplier;
                    }
                }

                //load core auto loading image files            
                adld = new DirectoryInfo(GameSettings.PROGRAM_IMAGE_LOAD_DIR);
                if (adld.Exists)
                {
                    srcFiles = adld.GetFiles();
                    clnFiles = new List<FileInfo>();

                    for (j = 0; j < srcFiles.Length; j++)
                    {
                        if (srcFiles[j].Name.ToCharArray()[0] != '.' && (srcFiles[j].Name.ToLower().IndexOf(".png") != -1 || srcFiles[j].Name.ToLower().IndexOf(".jpg") != -1 || srcFiles[j].Name.ToLower().IndexOf(".bmp") != -1))
                        {
                            clnFiles.Add(srcFiles[j]);
                        }
                    }

                    adFiles.AddRange(clnFiles);
                    if (adFiles != null && adFiles.Count > 0)
                    {
                        readLen = (adFiles.Count - 1) * loadMultiplier;
                    }
                }

                readPos = 0;
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            fileData = null;
            try
            {
                //auto load audio files
                if (asFiles != null && asFiles.Count > 0)
                {
                    tlen = asFiles.Count;

                    for (i = 0; i < tlen; i++)
                    {
                        MmgHelper.wr("Found auto_load file: " + asFiles[i].Name + " Path: " + asFiles[i].FullName);
                        //MmgHelper.GetBasicCachedSound(asFiles[i].FullName, asFiles[i].Name);
                        fileData = ReadFileData(asFiles[i].FullName);
                        xTrdW.AddCommand("GetBasicCachedSound", new object[] { asFiles[i].Name, fileData });
                        readPos = i * loadMultiplier;

                        if (update != null)
                        {
                            update.HandleUpdate(new LoadResourceUpdateMessage(readPos, readLen));
                        }

                        try
                        {
                            Thread.Sleep((int)slowDown);
                        }
                        catch (Exception e)
                        {
                            MmgHelper.wrErr(e);
                        }

                        if (exitLoad)
                        {
                            break;
                        }
                    }
                }
                readResult = true;

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            try
            {
                if (adFiles != null && adFiles.Count > 0)
                {
                    readLen = (adFiles.Count - 1) * loadMultiplier;
                    readPos = 0;
                    tlen = adFiles.Count;

                    for (i = 0; i < tlen; i++)
                    {
                        MmgHelper.wr("Found auto_load file: " + adFiles[i].Name + " Path: " + adFiles[i].FullName);
                        //MmgHelper.GetBasicCachedBmp(adFiles[i].FullName, adFiles[i].Name);
                        fileData = ReadFileData(adFiles[i].FullName);
                        xTrdW.AddCommand("GetBasicCachedBmp", new object[] { adFiles[i].Name, fileData });
                        readPos = i * loadMultiplier;

                        if (update != null)
                        {
                            update.HandleUpdate(new LoadResourceUpdateMessage(readPos, readLen));
                        }

                        try
                        {
                            Thread.Sleep((int)slowDown);
                        }
                        catch (Exception e)
                        {
                            MmgHelper.wrErr(e);
                        }

                        if (exitLoad)
                        {
                            break;
                        }
                    }
                }
                readResult = true;

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            readComplete = true;

            if (update != null)
            {
                update.HandleUpdate(new LoadResourceUpdateMessage(readPos, readLen));
            }
        }

        /// <summary>
        /// Gets the slow down value that will slow down the loading process when there are only a few resources to load.
        /// </summary>
        /// <returns>The slow down time in milliseconds.</returns>
        public long GetSlowDown()
        {
            return slowDown;
        }

        /// <summary>
        /// Sets the slow down value that will slow down the loading process when there are only a few resources to load.
        /// </summary>
        /// <param name="l">The slow down time in milliseconds.</param>
        public void SetSlowDown(long l)
        {
            slowDown = l;
        }

        /// <summary>
        /// Stops the current DAT load.
        /// </summary>
        public void StopLoad()
        {
            i = tlen;
            exitLoad = true;
        }

        /// <summary>
        /// Gets the current read length.
        /// </summary>
        /// <returns>Integer representing the read length.</returns>
        public virtual int GetLen()
        {
            return readLen;
        }

        /// <summary>
        /// Gets the current read position.
        /// </summary>
        /// <returns>The current read position.</returns>
        public virtual int GetPos()
        {
            return readPos;
        }

        /// <summary>
        /// Gets the result of the last read operation.
        /// </summary>
        /// <returns>The result of the last read operation.</returns>
        public virtual bool GetReadResult()
        {
            return readResult;
        }

        /// <summary>
        /// Gets and indication if the DAT load completed.
        /// </summary>
        /// <returns>A bool flag indicates that the loading process has completed.</returns>
        public virtual bool GetReadComplete()
        {
            return readComplete;
        }
    }
}