namespace HikiComic.Management.Helpers
{
    public class WriteLog
    {
        /// <summary>
        /// LogWrite
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="processName"></param>
        public static void WriteLogger(string msg, string processName)
        {
            string folderName = "C:\\SystemLog\\DetailLogs";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            using (StreamWriter streamWriter = File.AppendText(folderName + "\\" + "System_Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
            {
                streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                streamWriter.WriteLine("{0} running", processName);
                streamWriter.WriteLine("-------------------------------");
            }
        }
    }
}
