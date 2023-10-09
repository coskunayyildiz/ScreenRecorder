@echo off
setlocal enabledelayedexpansion

:: Set the input and output folder paths
set "input_folder=C:\Users\cskny\source\repos\ScreenRecorder\bin\Debug\net6.0-windows\Videos\09102023"
set "output_folder=%input_folder%\output"

:: Create the output folder if it doesn't exist
if not exist "%output_folder%" (
    mkdir "%output_folder%"
)

:: Loop through .avi files in the input folder
for %%f in ("%input_folder%\*.avi") do (
    echo Processing "%%~nxf"
    
    :: Use FFmpeg to compress the video and save it in the output folder
    ffmpeg -i "%%f" -c:v libx264 -crf 23 -c:a aac -strict experimental -b:a 128k "%output_folder%\%%~nf_compressed.mp4"
    
    echo "%%~nxf" compressed and saved as "%%~nf_compressed.mp4"
)

echo All videos processed.
pause