using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace OthersCodex
{
    namespace CopyEx
    {
        public delegate void CopyEventHandler(CopyEngine sender, CopyEngine.CopyEventArgs e);
        public class CopyEngine
        {


            //// Delegate for CallBack Function
            //private delegate Int32 CallBackDelegate(
            //    uint TotalFileSize_
            //    , uint BytesTransfered_
            //    , uint StreamSize_
            //    , uint StreamBytesTransfered_
            //    , uint DwStreamNumber_
            //    , long dwCallbackReason_
            //    , long hSourceFile_
            //    , long hDestinationFile
            //    , long lpData);


            delegate CopyProgressResult CopyProgressRoutine(
                long TotalFileSize,
                long TotalBytesTransferred,
                long StreamSize,
                long StreamBytesTransferred,
                uint dwStreamNumber,
                CopyProgressCallbackReason dwCallbackReason,
                IntPtr hSourceFile,
                IntPtr hDestinationFile,
                IntPtr lpData);

            enum CopyProgressResult : uint
            {
                PROGRESS_CONTINUE = 0,
                PROGRESS_CANCEL = 1,
                PROGRESS_STOP = 2,
                PROGRESS_QUIET = 3
            }

            enum CopyProgressCallbackReason : uint
            {
                CALLBACK_CHUNK_FINISHED = 0x00000000,
                CALLBACK_STREAM_SWITCH = 0x00000001
            }

            enum CopyFileFlags : uint
            {
                COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
                COPY_FILE_RESTARTABLE = 0x00000002,
                COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
                COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
            }

            public event CopyEventHandler CpEvHandler;

            //Constantes API

            //Define possible return codes from the CopyFileEx callback routine
            private const Int32 PROGRESS_CONTINUE = 0;
            private const Int32 PROGRESS_CANCEL = 1;
            private const Int32 PROGRESS_STOP = 2;
            private const Int32 PROGRESS_QUIET = 3;

            // Define CopyFileEx callback routine state change values
            private const Int32 CALLBACK_CHUNK_FINISHED = 0x00000000;
            private const Int32 CALLBACK_STREAM_SWITCH = 0x00000001;

            // Define CopyFileEx option flags
            private const Int32 COPY_FILE_FAIL_IF_EXISTS = 0x00000001;
            private const Int32 COPY_FILE_RESTARTABLE = 0x00000002;
            private const Int32 COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004;
            private const Int32 COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008;


            //API Calls
            //[DllImport("kernel32.dll", EntryPoint = "CopyFileExA", SetLastError = true)]
            //private static extern Int32 CopyFileEx(
            //    string lpExistingFileName,
            //    string lpNewFileName,
            //    [MarshalAs(UnmanagedType.FunctionPtr)] CallBackDelegate CCBD,
            //    long lpData,
            //    bool pbCancel,
            //    Int32 dwCopyFlags);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
               CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref Int32 pbCancel,
               CopyFileFlags dwCopyFlags);

            [DllImport("kernel32.dll")]
            private static extern Int32 FlushFileBuffers(
                long hFile);

            // Private values for properties
            private string SourceFile;
            private string DestinationFile;
            private bool IsCopy;
            private float nPercent;
            private double txTransf;
            private DateTime StartTime;
            private TimeSpan ElapsedTime;

            // public Properties
            public string Source
            {
                get { return SourceFile; }
                set { if (!IsCopy) { SourceFile = value; } }
            }

            public string Destination
            {
                get { return DestinationFile; }
                set { if (!IsCopy) { DestinationFile = value; } }
            }

            public bool IsCopying
            {
                get { return IsCopy; }
            }

            public string Percentage
            {
                get { return nPercent.ToString(".##"); }
            }

            public string TauxTransfert
            {
                get { return txTransf.ToString(".##"); }
            }


            // Constructeur avec Arguments
            public CopyEngine(string Source, string Destination)
            {
                SourceFile = Source;
                DestinationFile = Destination;
            }

            // Constructeur sans Argument
            public CopyEngine()
            { }

            public void CopyFiles()
            {
                if ((SourceFile != "") && (DestinationFile != ""))
                {
                    try
                    {
                        IsCopy = true;
                        CopyProgressRoutine cb = new CopyProgressRoutine(CopyInProgress);
                        StartTime = DateTime.Now;

                        System.IntPtr p = (System.IntPtr)0;
                        int i = 0;
                        CopyFileEx(SourceFile, DestinationFile, cb, p, ref i, CopyFileFlags.COPY_FILE_RESTARTABLE);
                        IsCopy = false;
                    }

                    catch (Exception e)
                    {
                        IsCopy = false;
                        throw new Exception(e.Message);
                    }
                }
            }

            // CallBack Routine
            //private Int32 CopyInProgress(uint TotalFileSize, uint BytesTransfered, uint StreamSize, uint StreamBytesTransfered, uint DwStreamNumber, long dwCallbackReason, long hSourceFile, long hDestinationFile, long lpData)
            private CopyProgressResult CopyInProgress(
                long TotalFileSize,
                long TotalBytesTransferred,
                long StreamSize,
                long StreamBytesTransferred,
                uint dwStreamNumber,
                CopyProgressCallbackReason dwCallbackReason,
                IntPtr hSourceFile,
                IntPtr hDestinationFile,
                IntPtr lpData)
            {

                float t = TotalFileSize;
                float bt = TotalBytesTransferred;

                if (t == 0)
                    nPercent = 0;
                else
                    nPercent = (bt / t) * 100;									//Etat de l'avancement en pourcentage
                ElapsedTime = (DateTime.Now - StartTime);					//Temps coul depuis le lancement du transfert
                txTransf = (StreamSize / 1024) / ElapsedTime.TotalSeconds;	//Calcul du taux de transfert moyen cumul en Ko/s

                CpEvHandler(this, new CopyEventArgs(nPercent, txTransf));

                return CopyProgressResult.PROGRESS_CONTINUE;
            }


            public class CopyEventArgs : EventArgs
            {
                private float Percentage;
                private double TauxTransfert;

                //Constructeur
                public CopyEventArgs(float nPercent, double TauxDeTransfert)
                {
                    Percentage = nPercent;
                    TauxTransfert = TauxDeTransfert;
                }

                public float CurrentPercent
                {
                    get { return Percentage; }
                }

                public double CurrentTauxTransfert
                {
                    get { return TauxTransfert; }
                }

            }//End Class CopyEventHandler
        }//End Class CopyEx
    }
}//NameSpace
