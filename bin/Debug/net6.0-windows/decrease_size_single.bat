@echo off
setlocal enabledelayedexpansion

:: Set the input and output folder paths
set "ffmpeg_path=.\ffmpeg.exe"
set "input_folder=%1"
set "video_name=%2"
set "output_folder=%input_folder%\output"

:: Create the output folder if it doesn't exist
if not exist "%output_folder%" (
    mkdir "%output_folder%"
)

echo Processing %video_name%

    :: Use FFmpeg to compress the video and save it in the output folder
"%ffmpeg_path%" -i "%input_folder%/%video_name%" -c:v libx264 -crf 18 -c:a aac -strict experimental -b:a 128k %output_folder%/%video_name%

del "%input_folder%\%video_name%"