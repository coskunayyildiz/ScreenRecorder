
namespace ScreenVideoRecorder
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection.Metadata;
    using System.Windows;
    using SharpAvi;
    using SharpAvi.Codecs;
    using SharpAvi.Output;

    public partial class Form1 : Form
    {
        Thread DesktopRecorderThread;
        static bool record_requested = false;
        public static Recorder recorder;
        public static int recorded_video_seconds = 0;

        public static int single_video_minute_length = 0;
        public static bool video_segment_created = false;

        public static string last_video_folder = "";
        public static string last_video_name = "";

        public Form1()
        {
            InitializeComponent();
        }

        public static string GenerateVideoName()
        {
            DateTime currentTime = DateTime.Now;
            string current_date = currentTime.ToString("ddMMyyyy");
            string current_time = currentTime.ToString("HH_mm_ss");
            string folderPath = "Videos/" + current_date;

            /*if(last_video_folder != "" && last_video_name != "")
            {
                RunABatchFileForSingle();
            }*/

            last_video_folder = folderPath;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            last_video_name = current_time + ".avi";
            return (folderPath + "/" + current_time + ".avi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string folderPath = @"Videos";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DateTime currentTime = DateTime.Now;
            string formattedTime = "Time: " + currentTime.ToString("HH:mm:ss");
            TimeOfDay_Sts.Text = formattedTime;
        }

        public static void RunABatchFileForSingle()
        {
            try
            {
                // Create a ProcessStartInfo to specify the batch file to run
                ProcessStartInfo processStartInfo = new ProcessStartInfo("decrease_size_single.bat");
                processStartInfo.Arguments = last_video_folder;
                processStartInfo.Arguments = $"{last_video_folder} {last_video_name}";

                //Environment.CurrentDirectory = last_video_folder;

                // Create a new process and start it
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.Start();

                // Wait for the batch file to finish running
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public static void RunABatchFile()
        {
            try
            {
                // Create a ProcessStartInfo to specify the batch file to run
                ProcessStartInfo processStartInfo = new ProcessStartInfo("decrease_size.bat");
                processStartInfo.Arguments = last_video_folder;

                //Environment.CurrentDirectory = last_video_folder;

                // Create a new process and start it
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.Start();

                // Wait for the batch file to finish running
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void RecordStopVideo_Bt_Click(object sender, EventArgs e)
        {
            if (RecordStopVideo_Bt.Text.Equals("Start Recording"))
            {
                recorder = new Recorder(new RecorderParams(GenerateVideoName(), 10, CodecIds.MotionJpeg, 50));

                DesktopRecorderThread = new Thread(new ThreadStart(RecordDesktop));
                DesktopRecorderThread.Start();
                record_requested = true;
                RecordStopVideo_Bt.Text = "Stop Recording";
                SingleVideoLength_Lb.Enabled = false;
                SingleVideoLengthValue_Tb.Enabled = false;
                VideoLength_Tm.Start();
                single_video_minute_length = int.Parse(SingleVideoLengthValue_Tb.Text);
            }
            else
            {
                record_requested = false;
                RecordStopVideo_Bt.Text = "Start Recording";
                SingleVideoLength_Lb.Enabled = true;
                SingleVideoLengthValue_Tb.Enabled = true;
                VideoLength_Tm.Stop();
                recorded_video_seconds = 0;
                RunABatchFile();
            }

        }

        public static void RecordDesktop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (record_requested == false)
                {
                    recorder.Dispose();
                    break;
                }
                if ( (recorded_video_seconds != 0) && (recorded_video_seconds % (single_video_minute_length * 60) == 0) && !video_segment_created)
                {
                    recorder.Dispose();
                    recorder = new Recorder(new RecorderParams(GenerateVideoName(), 10, CodecIds.MotionJpeg, 50));
                    video_segment_created = true;
                }
                if ((recorded_video_seconds % (single_video_minute_length * 60) != 0))
                {
                    video_segment_created = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            record_requested = false;
            if ((DesktopRecorderThread != null) && (DesktopRecorderThread.IsAlive))
                DesktopRecorderThread.Join();
        }

        private void VideoLength_Tm_Tick(object sender, EventArgs e)
        {
            recorded_video_seconds++;

            int hour = recorded_video_seconds / 3600;
            int minute = (recorded_video_seconds - (hour * 3600)) / 60;
            int seconds = (recorded_video_seconds - (hour * 3600) - (minute * 60));
            TotalLengthValue_Lb.Text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + seconds.ToString("00");

            DateTime currentTime = DateTime.Now;
            string formattedTime = "Time: " + currentTime.ToString("HH:mm:ss");
            TimeOfDay_Sts.Text = formattedTime;
        }
    }
}