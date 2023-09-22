
namespace ScreenVideoRecorder
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string folderPath = @"Videos";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private void RecordStopVideo_Bt_Click(object sender, EventArgs e)
        {
            if (RecordStopVideo_Bt.Text.Equals("Start Recording"))
            {
                recorder = new Recorder(new RecorderParams("Videos/video_1.avi", 10, CodecIds.MotionJpeg, 50));

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
                if ((recorded_video_seconds % (single_video_minute_length * 60) == 0) && !video_segment_created)
                {
                    recorder.Dispose();
                    int video_num = recorded_video_seconds / (single_video_minute_length * 60) + 1;
                    string video_name = "Videos/video_" + video_num.ToString() + ".avi";
                    recorder = new Recorder(new RecorderParams(video_name, 10, CodecIds.MotionJpeg, 50));
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
            DesktopRecorderThread.Join();
        }

        private void VideoLength_Tm_Tick(object sender, EventArgs e)
        {
            recorded_video_seconds++;

            int hour = recorded_video_seconds / 3600;
            int minute = (recorded_video_seconds - (hour * 3600)) / 60;
            int seconds = (recorded_video_seconds - (hour * 3600) - (minute * 60));
            TotalLengthValue_Lb.Text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}