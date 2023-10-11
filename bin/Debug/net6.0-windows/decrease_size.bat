@echo off
setlocal enabledelayedexpansion

:: Set the input and output folder paths
set "ffmpeg_path=.\ffmpeg.exe"
set "input_folder=%1"
set "output_folder=%input_folder%\output"

:: Create the output folder if it doesn't exist
if not exist "%output_folder%" (
    mkdir "%output_folder%"
)

:: Loop through .avi files in the input folder
for %%f in ("%input_folder%\*.avi") do (
    echo Processing "%%~nxf"
    
    :: Use FFmpeg to compress the video and save it in the output folder
    "%ffmpeg_path%" -i "%%f" -c:v libx264 -crf 18 -c:a aac -strict experimental -b:a 128k "%output_folder%\%%~nf.avi"
    
    echo "%%~nxf" compressed and saved as "%%~nf.avi"

    del "%%f"
)
